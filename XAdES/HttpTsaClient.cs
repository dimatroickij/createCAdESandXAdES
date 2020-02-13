// HttpTsaClient.cs
//
// XAdES Starter Kit for Microsoft .NET 3.5 (and above)
// 2010 Microsoft France
// Published under the CECILL-B Free Software license agreement.
// (http://www.cecill.info/licences/Licence_CeCILL-B_V1-en.txt)
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
// THE ENTIRE RISK OF USE OR RESULTS IN CONNECTION WITH THE USE OF THIS CODE 
// AND INFORMATION REMAINS WITH THE USER. 
//

using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Xml;
using Microsoft.Xades;

namespace SignatureMaker.WinForm.Xades
{
	/// <summary>
	/// Summary description for HttpTsaClient.
	/// </summary>
	public class HttpTsaClient
	{
		public HttpTsaClient()
		{
			RequestTsaCertificate = true;
			Credentials = CredentialCache.DefaultCredentials;
			RawTsaResponse = null;
			TsaTimeStamp = null;
		}

		public bool RequestTsaCertificate { get; set; }

		public ICredentials Credentials { get; set; }

		public byte[] RawTsaResponse { get; private set; }

		public byte[] TsaTimeStamp { get; private set; }

		public void SendTsaWebRequest(string tsaUri, byte[] hashToTimestamp)
		{
			WebRequest tsaWebRequest;
			Stream requestStream;
			WebResponse tsaWebResponse;
			Stream responseStream;
			byte[] requestToSend;
			string responseContentType;
			int rawResponseLength;
			int bytesRead;

			RawTsaResponse = null;
			requestToSend = BuildTsaRequest(hashToTimestamp);
			tsaWebRequest = WebRequest.Create(tsaUri);
			tsaWebRequest.Credentials = Credentials;
			tsaWebRequest.Method = "POST";
			tsaWebRequest.ContentType = "application/timestamp-query";
			tsaWebRequest.ContentLength = requestToSend.Length;
			requestStream = tsaWebRequest.GetRequestStream();
			requestStream.Write(requestToSend, 0, requestToSend.Length);
			requestStream.Close();

			tsaWebResponse = tsaWebRequest.GetResponse();
			responseContentType = tsaWebResponse.ContentType;
			responseStream = tsaWebResponse.GetResponseStream();
			rawResponseLength = (int) tsaWebResponse.ContentLength;

			RawTsaResponse = new byte[rawResponseLength];
			bytesRead = responseStream.Read(RawTsaResponse, 0, rawResponseLength);
			responseStream.Close();
			tsaWebResponse.Close();
		}

		public KnownTsaResponsePkiStatus ParseTsaResponse()
		{
			Asn1Parser asn1Parser;
			XmlNode pkiStatusXmlNode;
			string pkiStatusValue;
			XmlNode timeStampXmlNode;
			KnownTsaResponsePkiStatus retVal;

			retVal = KnownTsaResponsePkiStatus.Waiting;
			if (RawTsaResponse == null)
			{
				throw new Exception("There is no response to parse, call SendTsaWebRequest first");
			}

			asn1Parser = new Asn1Parser();
			asn1Parser.ParseAsn1(RawTsaResponse);
			pkiStatusXmlNode = asn1Parser.ParseTree.SelectSingleNode(
				"//Universal_Constructed_Sequence/Universal_Constructed_Sequence/Universal_Primitive_Integer");
			if (pkiStatusXmlNode != null)
			{
				pkiStatusValue = pkiStatusXmlNode.Attributes["Value"].Value;
				retVal = (KnownTsaResponsePkiStatus) (int.Parse(pkiStatusValue));
			}
			else
			{
				throw new Exception("Parse error TSA response: can't find PkiStatus");
			}

			if (retVal == KnownTsaResponsePkiStatus.Granted)
			{
				timeStampXmlNode = asn1Parser.ParseTree.SelectSingleNode(
					"//Universal_Constructed_Sequence/Universal_Constructed_Sequence/ContextSpecific_Constructed_A0/RawData[../../Universal_Primitive_Oid/@Value=\"1.2.840.113549.1.7.2\"]");
				if (timeStampXmlNode != null)
				{
					var n = timeStampXmlNode.ParentNode.ParentNode;
					n = n.SelectSingleNode("RawData");
					var hh = new byte[] {0x30, 0x82, 0x00, 0x00};
					var tmp = Convert.FromBase64String(n.InnerText);
					hh[2] = (byte) (tmp.Length / 256);
					hh[3] = (byte) (tmp.Length % 256);
					var res = new byte[hh.Length + tmp.Length];
					Array.Copy(hh, 0, res, 0, hh.Length);
					Array.Copy(tmp, 0, res, hh.Length, tmp.Length);
					TsaTimeStamp = res;
				}
				else
				{
					throw new Exception(
						"Parse error TSA response: can't find TSA TimeStamp (OID=1.2.840.113549.1.7.2)");
				}
			}

			return retVal;
		}

		private byte[] BuildTsaRequest(byte[] hashToTimestamp)
		{
			if (hashToTimestamp.Length != 20)
			{
				throw new Exception("SHA1 hash should be 20 bytes long (" + hashToTimestamp.Length + ")");
			}

			byte[] requestTemplate =
			{
				0x30, 0x27, //Request SEQUENCE (length: 39)
				0x02, 0x01, 0x01, //Version INTEGER (length: 1) value: 1
				0x30, 0x1f, //MessageImprint SEQUENCE (length: 31)
				0x30, 0x07, //AlgorithmOID SEQUENCE (length: 7)
				0x06, 0x05, //OID (length: 5)
				0x2b, 0x0e, 0x03, 0x02, 0x1a, //OIDSHA1 value: 1 3 14 3 2 26 -> 1*40+3=2B 14=0E 3=03 2=02 26=1A
				0x04, 0x14, //Hash OCTET STRING (length: 20)
				0x00, 0x00, 0x00, 0x00, 0x00, //Placeholders for hash
				0x00, 0x00, 0x00, 0x00, 0x00,
				0x00, 0x00, 0x00, 0x00, 0x00,
				0x00, 0x00, 0x00, 0x00, 0x00,
				0x01, 0x01, 0xff //RequestCertificate BOOLEAN (length: 1) value: true
			};

			for (var byteCounter = 0; byteCounter < hashToTimestamp.Length; byteCounter++)
			{
				requestTemplate[18 + byteCounter] = hashToTimestamp[byteCounter];
			}

			if (RequestTsaCertificate)
			{
				requestTemplate[40] = 0xff;
			}
			else
			{
				requestTemplate[40] = 0x00;
			}

			return requestTemplate;
		}

		public byte[] ComputeHashValueOfElementList(XmlElement signatureXmlElement, ArrayList elementXpaths,
			ref ArrayList elementIdValues)
		{
			XmlDocument xmlDocument;
			XmlNamespaceManager xmlNamespaceManager;
			XmlNodeList searchXmlNodeList;
			XmlElement composedXmlElement;
			XmlDsigC14NTransform xmlDsigC14NTransform;
			Stream canonicalizedStream;
			SHA1 sha1Managed;
			byte[] retVal;

			xmlDocument = signatureXmlElement.OwnerDocument;
			composedXmlElement = xmlDocument.CreateElement("ComposedElement", SignedXml.XmlDsigNamespaceUrl);
			xmlNamespaceManager = new XmlNamespaceManager(xmlDocument.NameTable);
			xmlNamespaceManager.AddNamespace("ds", SignedXml.XmlDsigNamespaceUrl);
			xmlNamespaceManager.AddNamespace("xsd", XadesSignedXml.XadesNamespaceUri);
			foreach (string elementXpath in elementXpaths)
			{
				searchXmlNodeList = signatureXmlElement.SelectNodes(elementXpath, xmlNamespaceManager);
				if (searchXmlNodeList.Count == 0)
				{
					throw new CryptographicException("Element " + elementXpath + " not found while calculating hash");
				}

				foreach (XmlNode xmlNode in searchXmlNodeList)
				{
					if (((XmlElement) xmlNode).HasAttribute("Id"))
					{
						elementIdValues.Add(((XmlElement) xmlNode).Attributes["Id"].Value);
						composedXmlElement.AppendChild(xmlNode);
					}
					else
					{
						throw new CryptographicException("Id attribute missing on " + xmlNode.LocalName + " element");
					}
				}
			}

			xmlDsigC14NTransform = new XmlDsigC14NTransform(false);
			var nodeStream = new MemoryStream();
			var xw = XmlWriter.Create(nodeStream);
			for (var i = 0; i < composedXmlElement.ChildNodes.Count; i++)
				composedXmlElement.ChildNodes[i].WriteTo(xw);
			xw.Flush();
			nodeStream.Position = 0;
			xmlDsigC14NTransform.LoadInput(nodeStream);

			canonicalizedStream = (Stream) xmlDsigC14NTransform.GetOutput(typeof(Stream));
			sha1Managed = new SHA1Managed();
			retVal = sha1Managed.ComputeHash(canonicalizedStream);
			canonicalizedStream.Close();

			return retVal;
		}
	}

	public enum KnownTsaResponsePkiStatus
	{
		Granted = 0,
		GrantedWithMods = 1,
		Rejection = 2,
		Waiting = 3,
		RevocationWarning = 4, //This message contains a warning that a revocation is imminent
		RevocationNotification = 5 //Notification that a revocation has occurred
	}
}