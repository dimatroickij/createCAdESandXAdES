using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.Tsp;
using Org.BouncyCastle.X509;
using SignatureMaker.WinForm.Cades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Voskhod.CAdES;

namespace SignatureMaker.CAdES
{
    public partial class MainForm : Form
    {
        private CmsSignedData _cms;

        public class LbSigItem
        {
            public SignerInformation Sig;
            public string Caption;

            public override string ToString()
            {
                return Caption;
            }
        }

        public static byte[] CreateSignature(byte[] data, X509Certificate2 certificate, bool detached)
        {
            var contentInfo = new System.Security.Cryptography.Pkcs.ContentInfo(data);
            var signedCms = new System.Security.Cryptography.Pkcs.SignedCms(contentInfo, detached);
            var cmsSigner = new System.Security.Cryptography.Pkcs.CmsSigner(certificate);
            cmsSigner.SignedAttributes.Add(new System.Security.Cryptography.Pkcs.Pkcs9SigningTime());
            signedCms.ComputeSignature(cmsSigner);
            return signedCms.Encode();
        }

        public MainForm()
        {
            InitializeComponent();
            BouncyCastleHelper.Init();
        }

		private void frmMain_Load(object sender, EventArgs e)
		{
			cmbTSAuri.SelectedIndex = 0;
		}

		private void cmdLoadCMS_Click(object sender, EventArgs e)
		{
			var dlg = new OpenFileDialog();
			if (!string.IsNullOrEmpty(txtCMSfilename.Text))
			{
				dlg.InitialDirectory = Path.GetDirectoryName(txtCMSfilename.Text);
				dlg.FileName = Path.GetFileName(txtCMSfilename.Text);
			}

			dlg.Filter = "Pkcs7|*.p7s;*.sig;*.bin|All files|*.*";
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				try
				{
					var data = File.ReadAllBytes(dlg.FileName);
					byte[] wdata;

					if (Base64.FromBase64ToByteArray(data, out var res, null))
					{
						wdata = new byte[res];
						Base64.FromBase64ToByteArray(data, out res, wdata);
					}
					else
						wdata = data;

					_cms = new CmsSignedData(wdata);
					txtCMSfilename.Text = dlg.FileName;
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Ошибка \"{ex.Message}\" при попытке открыть файл \"{dlg.FileName}\"",
						"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				UpdateInfo();
				if (_cms.SignedContent == null)
					_dataFileName = null;
			}
		}

		private void cmdSaveCMS_Click(object sender, EventArgs e)
		{
			var dlg = new SaveFileDialog();
			if (!string.IsNullOrEmpty(txtCMSfilename.Text))
			{
				dlg.InitialDirectory = Path.GetDirectoryName(txtCMSfilename.Text);
				dlg.FileName = Path.GetFileName(txtCMSfilename.Text);
			}

			dlg.Filter = "Pkcs7|*.p7s;*.sig;*.bin|All files|*.*";
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				try
				{
					File.WriteAllBytes(dlg.FileName, _cms.GetEncoded());
					txtCMSfilename.Text = dlg.FileName;
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Ошибка \"{ex.Message}\" при попытке записать файл \"{dlg.FileName}\"",
						"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void cmdCreateCMSdetached_Click(object sender, EventArgs e)
		{
			var dlg = new CertSelectForm();
			if (dlg.ShowDialog() != DialogResult.OK)
				return;

			if (dlg.lvCertificates.SelectedItems.Count != 1)
				return;

			var data = GetData();

			if (data == null)
				return;

			var cur = Cursor;
			Cursor = Cursors.WaitCursor;
			try
			{
				var cc = dlg.lvCertificates.SelectedItems[0].Tag as X509Certificate2;
				_cms = new CmsSignedData(CreateSignature(data, cc, true));

				UpdateInfo();
				lbSignatures.SelectedIndex = lbSignatures.Items.Count - 1;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					$"Ошибка \"{ex.Message}\" при попытке создать detached-подпись\r\n{ex.StackTrace}",
					"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				Cursor = cur;
			}
		}

		private void cmdCreateCMSattached_Click(object sender, EventArgs e)
		{
			var dlg = new CertSelectForm();

			if (dlg.ShowDialog() != DialogResult.OK)
				return;

			if (dlg.lvCertificates.SelectedItems.Count != 1)
				return;

			var data = GetData();

			if (data == null)
				return;

			var cur = Cursor;
			Cursor = Cursors.WaitCursor;
			try
			{
				var cc = dlg.lvCertificates.SelectedItems[0].Tag as X509Certificate2;
				_cms = new CmsSignedData(CreateSignature(data, cc, false));

				UpdateInfo();
				lbSignatures.SelectedIndex = lbSignatures.Items.Count - 1;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					$"Ошибка \"{ex.Message}\" при попытке создать detached-подпись\r\n{ex.StackTrace}",
					"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				Cursor = cur;
			}
		}

		private void UpdateInfo()
		{
			txtSigInfo.Clear();
			lbSignatures.Items.Clear();
			lbCertificates.Items.Clear();

			if (_cms != null)
			{
				labelCMSinfo.Text = _cms.SignedContent != null
					? "Присоединенная подпись (attached)"
					: "Отсоединенная подпись (detached)";

				cmdSaveCMS.Enabled = true;
				cmdAddSignature.Enabled = true;

				var i = 0;
				foreach (SignerInformation si in _cms.GetSignerInfos().GetSigners())
				{
					var emd = $"{i++:d2}. {si.ToSignerInfo().EncryptedDigest.ToString()}";
					lbSignatures.Items.Add(new LbSigItem() { Caption = emd, Sig = si });
				}

				cmdExtendToLT1.Enabled = lbSignatures.SelectedIndex >= 0;
				cmdAddAv3.Enabled = cmdSaveMsgDigest.Enabled = cmdSaveAttr.Enabled =
					cmdCryptoProVerify.Enabled =
						cmdAddTimestamp.Enabled = cmdUpdateAttr.Enabled = cmdExtendToLT1.Enabled;

				var store = _cms.GetCertificates("Collection").GetMatches(null);
				var k = 0;
				foreach (Org.BouncyCastle.X509.X509Certificate cc in store)
					lbCertificates.Items.Add($"{k++:d2} {cc.SubjectDN.ToString()}");
			}
			else
			{
				labelCMSinfo.Text = "???";
			}
		}

		private string ParseTsa(Org.BouncyCastle.Asn1.Cms.Attribute at)
		{
			try
			{
				var ts = new TimeStampToken(Org.BouncyCastle.Asn1.Cms.ContentInfo.GetInstance(at.AttrValues[0]));
				return
					$"\tответ от TSA: {(new DateTime(ts.TimeStampInfo.GenTime.Ticks, DateTimeKind.Utc)).ToLocalTime():yyyy-MM-dd HH:mm:ss}";
			}
			catch (Exception ex)
			{
				return $"\tответ от TSA: Exception \"{ex.Message}\"";
			}
		}

		private string MakeDescriptiion(Org.BouncyCastle.Asn1.Cms.Attribute at)
		{
			var res = new StringBuilder();
			res.AppendFormat("{0}", at.AttrType.Id);

			switch (at.AttrType.Id)
			{
				case "1.2.840.113549.1.9.4":
					res.Append("\tmessageDigest");
					break;
				case "1.2.840.113549.1.9.16.2.47":
					res.Append("\tid-aa-signingCertificateV2");
					break;
				case "1.2.840.113549.1.9.5":
					res.Append("\tSigning Time");
					res.AppendFormat(" = {0:yyyy-MM-dd HH:mm:ss}",
						((DerUtcTime)at.AttrValues[0]).ToDateTime().ToLocalTime());
					break;
				case "1.2.840.113549.1.9.3":
					res.Append("\tcontentType");
					break;
				case "1.2.840.113549.1.9.16.2.23":
					res.Append("\tid-aa-ets-certValues");
					break;
				case "1.2.840.113549.1.9.16.2.24":
					res.Append("\tid-aa-ets-revocationValues");
					break;
				case "1.2.840.113549.1.9.16.2.14":
					res.Append("\tid-aa-timeStampToken");
					res.Append(ParseTsa(at));
					break;
				case "1.2.840.113549.1.9.16.2.25":
					res.Append("\tid-aa-ets-escTimeStamp");
					res.Append(ParseTsa(at));
					break;
				case "1.2.840.113549.1.9.16.2.21":
					res.Append("\tid-aa-ets-CertificateRefs");
					break;
				case "1.2.840.113549.1.9.16.2.22":
					res.Append("\taa-ets-revocationRefs");
					break;
				case "0.4.0.1733.2.4":
					res.Append("\t\tarchiveTimestampV3");
					res.Append(ParseTsa(at));
					break;
				default:
					break;
			}

			return res.ToString();
		}

		private void lbSignatures_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (_cms != null && lbSignatures.SelectedIndex >= 0)
			{
				try
				{
					var ii = lbSignatures.SelectedItem as LbSigItem;
					var sb = new StringBuilder();
					sb.AppendLine(ii.Caption);
					sb.AppendLine($"DigestAlgOid: {ii.Sig.DigestAlgOid.ToString()}");
					sb.AppendLine(
						$"Digest: {Asn1OctetString.GetInstance(ii.Sig.SignedAttributes[Org.BouncyCastle.Asn1.Cms.CmsAttributes.MessageDigest].AttrValues[0]).ToString()}");
					sb.AppendLine($"EncryptionAlgOid: {ii.Sig.EncryptionAlgOid.ToString()}");
					sb.AppendLine("=== Сертификат подписи ===");
					var cc = Utils.GetFirstFromCollection<Org.BouncyCastle.X509.X509Certificate>(
						_cms.GetCertificates("Collection").GetMatches(ii.Sig.SignerID));
					if (cc != null)
					{
						sb.AppendLine($"\tSubject: {cc.SubjectDN.ToString()}");
						sb.AppendLine($"\tIssuer: {cc.IssuerDN.ToString()}");
						sb.AppendLine($"\tSerialNumber: {cc.SerialNumber.ToString(16)}");
						sb.AppendLine(
							$"\tДействителен с {cc.NotBefore:yyyy-MM-dd HH:mm:ss} и до {cc.NotAfter:yyyy-MM-dd HH:mm:ss}");

						var data = cc.GetEncoded();
						var dg = new Org.BouncyCastle.Crypto.Digests.Sha1Digest();
						dg.BlockUpdate(data, 0, data.Length);
						var res = new byte[dg.GetDigestSize()];
						dg.DoFinal(res, 0);
						sb.Append("\tОтпечаток: ");
						for (var i = 0; i < res.Length; i++) sb.AppendFormat("{0:x2}", res[i]);
						sb.AppendLine();
					}
					else
						sb.AppendLine(
							$"\t!!! Отсутсвует в коллекции !!!\r\n\t{ii.Sig.SignerID.Issuer.ToString()}\r\n\t{ii.Sig.SignerID.SerialNumber}");

					sb.AppendLine("=== Подписанные атрибуты ===");
					if (ii.Sig.SignedAttributes != null)
						foreach (Org.BouncyCastle.Asn1.Cms.Attribute at in
							ii.Sig.SignedAttributes.ToAsn1EncodableVector())
							sb.AppendLine($"\t{MakeDescriptiion(at)}");
					sb.AppendLine("=== Неподписанные атрибуты ===");
					if (ii.Sig.UnsignedAttributes != null)
						foreach (Org.BouncyCastle.Asn1.Cms.Attribute at in ii.Sig.UnsignedAttributes
							.ToAsn1EncodableVector())
							sb.AppendLine($"\t{MakeDescriptiion(at)}");

					txtSigInfo.Text = sb.ToString();
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Ошибка \"{ex.Message}\" при попытке разобрать подпись",
						"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					lbSignatures.SelectedIndex = -1;
					return;
				}
			}

			cmdExtendToLT1.Enabled = lbSignatures.SelectedIndex >= 0;
			cmdAddAv3.Enabled = cmdSaveMsgDigest.Enabled = cmdSaveAttr.Enabled =
				cmdCryptoProVerify.Enabled =
					cmdAddTimestamp.Enabled = cmdUpdateAttr.Enabled = cmdExtendToLT1.Enabled;
		}

		private string _dataFileName;

		private byte[] GetData()
		{
			var dlg = new OpenFileDialog();
			dlg.Title = "Выберите файл с данными для подписи";
			if (!string.IsNullOrEmpty(txtCMSfilename.Text))
			{
				dlg.InitialDirectory = Path.GetDirectoryName(_dataFileName);
				dlg.FileName = Path.GetFileName(_dataFileName);
			}

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				_dataFileName = dlg.FileName;
				return File.ReadAllBytes(dlg.FileName);
			}
			else
				return null;
		}

		private void cmdAddSignature_Click(object sender, EventArgs e)
		{
			var dlg = new CertSelectForm();
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				if (dlg.lvCertificates.SelectedItems.Count == 1)
				{
					try
					{
						var cc = dlg.lvCertificates.SelectedItems[0].Tag as X509Certificate2;

						byte[] data;
						bool detached;
						if (_cms.SignedContent != null)
						{
							using (var m = new MemoryStream())
							{
								_cms.SignedContent.Write(m);
								data = m.ToArray();
							}

							detached = false;
						}
						else
						{
							data = GetData();
							if (data == null) return;
							detached = true;
						}

						var newCms = new CmsSignedData(CreateSignature(data, cc, detached));

						var newSigners = new ArrayList();
						foreach (SignerInformation si in _cms.GetSignerInfos().GetSigners())
							newSigners.Add(si);

						foreach (SignerInformation si in newCms.GetSignerInfos().GetSigners())
							newSigners.Add(si);

						var newSignerInformationStore = new SignerInformationStore(newSigners);
						_cms = CmsSignedData.ReplaceSigners(_cms, newSignerInformationStore);

						_cms = CAdES_A_v3.ExtendCertificateAndCRLcollectionsIfNeeded(_cms,
							CAdES_A_v3.GetCMScertificatesCollection(newCms),
							CAdES_A_v3.GetCMScrlsCollection(newCms));

						UpdateInfo();
						lbSignatures.SelectedIndex = lbSignatures.Items.Count - 1;
					}
					catch (Exception ex)
					{
						MessageBox.Show(
							$"Ошибка \"{ex.Message}\" при попытке создать подпись\r\n{ex.StackTrace}",
							"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

		private void cmdExtendToLT1_Click(object sender, EventArgs e)
		{
			if (lbSignatures.SelectedIndex >= 0)
			{
				var cur = Cursor;
				Cursor = Cursors.WaitCursor;
				try
				{
					var ii = lbSignatures.SelectedItem as LbSigItem;
					var tsAuri = cmbTSAuri.Text;
					var oldIndex = lbSignatures.SelectedIndex;

					var newSigners = new ArrayList();
					var store = _cms.GetCertificates("Collection");
					foreach (SignerInformation si in _cms.GetSignerInfos().GetSigners())
						if (ReferenceEquals(si, ii.Sig))
							newSigners.Add(CAdES_X_LongType1.ExtendSignatureToCAdES_XLongType1(ii.Sig, store, tsAuri));
						else
							newSigners.Add(si);
					var newSignerInformationStore = new SignerInformationStore(newSigners);
					_cms = CmsSignedData.ReplaceSigners(_cms, newSignerInformationStore);

					UpdateInfo();
					lbSignatures.SelectedIndex = oldIndex;
				}
				catch (Exception ex)
				{
					MessageBox.Show(
						$"Ошибка \"{ex.Message}\" при попытке дополнить подпись до CAdES-X LongType 1\r\n{ex.StackTrace}",
						"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					Cursor = cur;
				}
			}
		}

		private void cmdAddAv3_Click(object sender, EventArgs e)
		{
			if (lbSignatures.SelectedIndex >= 0)
			{
				var cur = Cursor;
				Cursor = Cursors.WaitCursor;
				try
				{
					var ii = lbSignatures.SelectedItem as LbSigItem;
					var tsAuri = cmbTSAuri.Text;
					var oldIndex = lbSignatures.SelectedIndex;

					var certs = new Dictionary<string, Org.BouncyCastle.X509.X509Certificate>();
					var crls = new Dictionary<string, X509Crl>();

					var newSigners = new ArrayList();
					foreach (SignerInformation si in _cms.GetSignerInfos().GetSigners())
						if (ReferenceEquals(si, ii.Sig))
							newSigners.Add(CAdES_A_v3.ExtendSignatureToCAdES_Av3(_cms, ii.Sig, tsAuri, certs, crls));
						else
							newSigners.Add(si);
					var newSignerInformationStore = new SignerInformationStore(newSigners);
					_cms = CmsSignedData.ReplaceSigners(_cms, newSignerInformationStore);
					_cms = CAdES_A_v3.ExtendCertificateAndCRLcollectionsIfNeeded(_cms, certs, crls);

					UpdateInfo();
					lbSignatures.SelectedIndex = oldIndex;
				}
				catch (Exception ex)
				{
					MessageBox.Show(
						$"Ошибка \"{ex.Message}\" при попытке добавить атрибут CAdES-A v3\r\n{ex.StackTrace}",
						"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					Cursor = cur;
				}
			}
		}

		private void lbCertificates_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			try
			{
				if (lbCertificates.SelectedIndex >= 0)
				{
					var store = _cms.GetCertificates("Collection");
					var k = lbCertificates.SelectedIndex;
					Org.BouncyCastle.X509.X509Certificate fc = null;
					foreach (Org.BouncyCastle.X509.X509Certificate cc in store.GetMatches(null))
					{
						fc = cc;
						if (k-- == 0) break;
					}

					if (fc != null)
					{
						var ch = BuildCertificateChain.BuildByBC(fc, store, dtpBuildChain.Value);
						var sb = new StringBuilder();
						var tc = 0;
						foreach (var el in ch)
						{
							var pos = el.Subject.IndexOf("CN");
							var pos2 = pos >= 0 ? el.Subject.IndexOf(',', pos) : -1;
							if (pos >= 0 && pos2 >= 0) sb.Append(el.Subject.Substring(pos + 2, pos2 - pos - 3));
							else if (pos >= 0) sb.Append(el.Subject.Substring(pos + 2));
							else sb.Append(el.Subject);
							sb.AppendLine();
							for (var j = 0; j <= tc; j++) sb.Append('\t');
							tc++;
						}

						MessageBox.Show(sb.ToString(), "Цепочка сертификатов", MessageBoxButtons.OK,
							MessageBoxIcon.Information);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					$"Ошибка \"{ex.Message}\" при попытке построить цепочку сертификатов\r\n{ex.StackTrace}",
					"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void cmdSaveMsgDigest_Click(object sender, EventArgs e)
		{
			if (lbSignatures.SelectedIndex >= 0)
			{
				var dlg = new SaveFileDialog();
				if (!string.IsNullOrEmpty(txtCMSfilename.Text))
				{
					dlg.InitialDirectory = Path.GetDirectoryName(txtCMSfilename.Text);
					dlg.FileName = Path.GetFileName(txtCMSfilename.Text) + ".hash";
				}

				dlg.Filter = "Дайджесты для подписей|*.hash|All files|*.*";
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					var cur = Cursor;
					Cursor = Cursors.WaitCursor;
					try
					{
						var ii = lbSignatures.SelectedItem as LbSigItem;
						if (ii.Sig.SignedAttributes != null)
							foreach (Org.BouncyCastle.Asn1.Cms.Attribute at in ii.Sig.SignedAttributes
								.ToAsn1EncodableVector())
								if (at.AttrType.Id == "1.2.840.113549.1.9.4")
								{
									var bin = at.AttrValues[0].GetEncoded();
									var hash = new byte[bin.Length - 2];
									Array.Copy(bin, 2, hash, 0, hash.Length);
									File.WriteAllBytes(dlg.FileName, hash);
								}
					}
					catch (Exception ex)
					{
						MessageBox.Show(
							$"Ошибка \"{ex.Message}\" при попытке сохранить дайджест сообщения\r\n{ex.StackTrace}",
							"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					finally
					{
						Cursor = cur;
					}
				}
			}
		}

		private void cmdSaveAttr_Click(object sender, EventArgs e)
		{

		}

		private void cmdCryptoProVerify_Click(object sender, EventArgs e)
		{
			var cur = Cursor;
			Cursor = Cursors.WaitCursor;
			// КриптоПро ЭЦП Browser plug-in не поддерживает подписи CMS (не CAdES BES) !!!
			try
			{
				bool detached;
				byte[] data = null;
				if (_cms.SignedContent != null)
					detached = false;
				else
				{
					detached = true;
					if (string.IsNullOrEmpty(_dataFileName))
						data = GetData();
					else
						data = File.ReadAllBytes(_dataFileName);
				}

				var comType = Type.GetTypeFromProgID("CAdESCOM.CadesSignedData");
				dynamic instance = Activator.CreateInstance(comType);

				if (detached)
					instance.Content = data;

				instance.VerifyCades(_cms.GetEncoded(),
					93, // <= CADESCOM_CADES_X_LONG_TYPE_1
					detached);

				Cursor = cur;
				MessageBox.Show("Эта подпись является CAdES X LongType1 (результат COM-объекта \"КриптоПРО\")",
					"Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				Cursor = cur;
				MessageBox.Show(
					$"Ошибка \"{ex.Message}\" при попытке проверить подпись через COM-объект \"КриптоПРО\"\r\n{ex.StackTrace}",
					"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private delegate Org.BouncyCastle.Asn1.Cms.AttributeTable AddToUnsignedAttributesCadEsT(
			byte[] timeStampHash, string tsaUri,
			Org.BouncyCastle.Asn1.Cms.AttributeTable aTable,
			Utils.GetCertificateChainMethod makeChain,
			out DateTime? timestampFromTsa,
			out Org.BouncyCastle.X509.X509Certificate cert);

		private void cmdAddTimestamp_Click(object sender, EventArgs e)
		{
			if (lbSignatures.SelectedIndex >= 0)
			{
				var cur = Cursor;
				Cursor = Cursors.WaitCursor;
				try
				{
					var ii = lbSignatures.SelectedItem as LbSigItem;
					var sigCertColl = _cms.GetCertificates("BC").GetMatches(ii.Sig.SignerID);
					if (sigCertColl.Count > 0)
					{
						var en = sigCertColl.GetEnumerator();
						en.MoveNext();
						var sigCert = (Org.BouncyCastle.X509.X509Certificate)en.Current;
						var sigCert2 = new X509Certificate2(sigCert.GetEncoded());

						var timeStampHash = SPS.Crypto.CMS.ComputeHash(sigCert2, ii.Sig.GetSignature());

						var newSigners = new ArrayList();
						for (var i = 0; i < lbSignatures.Items.Count; i++)
						{
							if (lbSignatures.Items[i] is LbSigItem ti)
							{
								if (ReferenceEquals(ti, ii))
								{
									var timeStampToken = Utils.GetTimeStampTokenFromTSA(cmbTSAuri.Text, timeStampHash);
									var un = Utils.ReplaceAttributes(ii.Sig.UnsignedAttributes,
										new Org.BouncyCastle.Asn1.Cms.Attribute(
											PkcsObjectIdentifiers.IdAASignatureTimeStampToken,
											new DerSet(Asn1Object.FromByteArray(timeStampToken.GetEncoded()))));

									newSigners.Add(SignerInformation.ReplaceUnsignedAttributes(ii.Sig, un));
								}
								else
									newSigners.Add(ti.Sig);
							}
						}

						var newSignerInformationStore = new SignerInformationStore(newSigners);
						_cms = CmsSignedData.ReplaceSigners(_cms, newSignerInformationStore);
						var idx = lbSignatures.SelectedIndex;
						UpdateInfo();
						lbSignatures.SelectedIndex = idx;
					}

					Cursor = cur;
				}
				catch (Exception ex)
				{
					Cursor = cur;
					MessageBox.Show(
						$"Ошибка \"{ex.Message}\" при попытке добавить штамп времени\r\n{ex.StackTrace}",
						"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void cmdUpdateAttr_Click(object sender, EventArgs e)
		{
			if (lbSignatures.SelectedIndex >= 0)
			{
				var dlg = new OpenFileDialog();
				dlg.Title = "Выберите файл с новым значением атрибута";
				dlg.Filter = "Атрибуты из подписей|*.attr|All files|*.*";
				if (dlg.ShowDialog() != DialogResult.OK)
					return;

				var cur = Cursor;
				Cursor = Cursors.WaitCursor;
				try
				{
					var attr = File.ReadAllBytes(dlg.FileName);
					var value0 = //Org.BouncyCastle.Asn1.Cms.Attribute.GetInstance(Asn1Object.FromByteArray(attr));
						Asn1Sequence.GetInstance(Asn1Object.FromByteArray(attr));

					var ii = lbSignatures.SelectedItem as LbSigItem;

					var newSigners = new ArrayList();
					for (var i = 0; i < lbSignatures.Items.Count; i++)
					{
						if (!(lbSignatures.Items[i] is LbSigItem ti))
							continue;

						if (ReferenceEquals(ti, ii))
						{
							var un = Utils.ReplaceAttributes(ii.Sig.UnsignedAttributes,
								new Org.BouncyCastle.Asn1.Cms.Attribute(
									new DerObjectIdentifier(txtAttrOID.Text.Trim()),
									new DerSet(value0)));
							newSigners.Add(SignerInformation.ReplaceUnsignedAttributes(ii.Sig, un));
						}
						else
							newSigners.Add(ti.Sig);
					}

					var newSignerInformationStore = new SignerInformationStore(newSigners);
					_cms = CmsSignedData.ReplaceSigners(_cms, newSignerInformationStore);
					var idx = lbSignatures.SelectedIndex;
					UpdateInfo();
					lbSignatures.SelectedIndex = idx;
					Cursor = cur;
				}
				catch (Exception ex)
				{
					Cursor = cur;
					MessageBox.Show(
						$"Ошибка \"{ex.Message}\" при попытке изменить атрибут\r\n{ex.StackTrace}",
						"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
	}
}
