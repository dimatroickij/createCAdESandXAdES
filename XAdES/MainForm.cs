using Microsoft.Xades;
using SignatureMaker.WinForm.Xades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Windows.Forms;
using System.Xml;

namespace SignatureMaker.XAdES
{
    public partial class MainForm : Form
    {
        private X509Certificate2 _certificate;
        private X509Chain _chain;
        private XmlDocument _envelopedSignatureXmlDocument;
        private XadesSignedXml _xadesSignedXml;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.XAdESTRadioButton.Checked = true;
            this.SigningTimeTextBox.Text = DateTime.Now.ToString("s");
            this.TSACheckBox.Checked = true;
        }

        private void selectCertificate_Click(object sender, EventArgs e)
        {
            _certificate = LetUserChooseCertificate();

            if (_certificate != null)
            {
                _chain = new X509Chain();

                _chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
                _chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
                _chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 0, 30);
                _chain.ChainPolicy.VerificationFlags = X509VerificationFlags.NoFlag;

                if (_chain.Build(_certificate) == true)
                {
                    this.CertificateDetailsLabel.Text = _certificate.SubjectName.Name + _certificate.IssuerName.Name;

                    //issuerSerialLabel.Text = _certificate.SerialNumber;


                    //digestMethodLabel.Text = SignedXml.XmlDsigSHA1Url;
                    //digestValueLabel.Text = _certificate.Thumbprint;
                }
                else
                {
                    _certificate = null;
                    _chain = null;
                    MessageBox.Show("Certificate chain status isn't verified");
                }

            }
        }

        private X509Certificate2 LetUserChooseCertificate()
        {
            X509Certificate2 cert = null;
            try
            {
                var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

                var collection = store.Certificates;
                var fcollection =
                    collection.Find(X509FindType.FindByTimeValid, DateTime.Now, false);
                var scollection = X509Certificate2UI.SelectFromCollection(fcollection,
                    "Сертификат", "Выберите сертификат", X509SelectionFlag.SingleSelection);

                if (scollection != null && scollection.Count == 1)
                {
                    cert = scollection[0];

                    if (cert.HasPrivateKey == false)
                    {
                        MessageBox.Show("This certificate does not have a private key associated with it");
                        cert = null;
                    }
                }

                store.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to get the private key");
                cert = null;
            }

            return cert;
        }

        private void AddCertificateInfoToSignature()
        {
            _xadesSignedXml.SigningCertificate = _certificate;

            var keyInfo = new KeyInfo();
            keyInfo.AddClause(new KeyInfoX509Data(_certificate));
            _xadesSignedXml.KeyInfo = keyInfo;
        }

        private void SubscribeButton_Click(object sender, EventArgs e)
        {
            // Добавить проверку на пустоту всех полей
            if (_certificate != null)
            {
                if ((SourceFileTextBox.Text != "") && (saveFileTextBox.Text != ""))
                {
                    IEnumerable<string> allfiles = Directory.EnumerateFiles(SourceFileTextBox.Text);
                    foreach (string filename in allfiles)
                    {
                        connectFile(filename);
                        AddCertificateInfoToSignature();
                        signedFile(filename);
                    }

                    // выдать сообщение, что подпись создана и очистить поля
                    MessageBox.Show(
                            "Создание подписи",
                            "Файл подписан",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.DefaultDesktopOnly);
                }
            }
            else
            {
                MessageBox.Show(
                    "Выберите сертификат для подписи документов",
                    "Не выбран сертификат",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void connectFile(string filename)
        {
            XmlDsigEnvelopedSignatureTransform xmlDsigEnvelopedSignatureTransform;
            Reference reference;

            reference = new Reference();

            _envelopedSignatureXmlDocument = new XmlDocument();

            _envelopedSignatureXmlDocument.PreserveWhitespace = true;
            _envelopedSignatureXmlDocument.Load(filename);
            _xadesSignedXml = new XadesSignedXml(_envelopedSignatureXmlDocument);

            reference.Uri = "";
            var xmlDsigC14NTransform = new XmlDsigC14NTransform();
            reference.AddTransform(xmlDsigC14NTransform);
            xmlDsigEnvelopedSignatureTransform = new XmlDsigEnvelopedSignatureTransform();
            reference.AddTransform(xmlDsigEnvelopedSignatureTransform);

            _xadesSignedXml.AddReference(reference);
        }

        private void signedFile(string filename)
        {
            try
            {
                _xadesSignedXml.Signature.Id = SignatureIdTextBox.Text;

                var xadesObject = new XadesObject();
                xadesObject.Id = "XadesObject";
                xadesObject.QualifyingProperties.Target = "#" + SignatureIdTextBox.Text;
                AddSignedSignatureProperties(
                    xadesObject.QualifyingProperties.SignedProperties.SignedSignatureProperties,
                    xadesObject.QualifyingProperties.SignedProperties.SignedDataObjectProperties,
                    xadesObject.QualifyingProperties.UnsignedProperties.UnsignedSignatureProperties);

                _xadesSignedXml.AddXadesObject(xadesObject);
                //
                // Формирование файла
                //
                try
                {
                    _xadesSignedXml.ComputeSignature();
                    _xadesSignedXml.SignatureValueId = SignatureValueIdTextBox.Text;

                    

                    //if (XAdESRadioButton.Checked)
                    //{
                        //ShowSignature(true, filename);
                        // дописать
                        //ShowSignature(false);
                    //}

                    if (XAdESTRadioButton.Checked)
                    {
                        ShowSignature(false, filename);
                        transformXAdEST(filename);
                    }
                  
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Problem during signature computation (Did you select a valid certificate?): " +
                                    exception.Message);
                    
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error occurred: " + exception.ToString());
               
            }
        }

        private void AddSignedSignatureProperties(SignedSignatureProperties signedSignatureProperties,
            SignedDataObjectProperties signedDataObjectProperties,
            UnsignedSignatureProperties unsignedSignatureProperties)
        {
            var xmlDocument = new XmlDocument();

            var cert = new Cert();
            cert.IssuerSerial.X509IssuerName = _certificate.IssuerName.Name;
            cert.IssuerSerial.X509SerialNumber = _certificate.SerialNumber;
            cert.CertDigest.DigestMethod.Algorithm = SignedXml.XmlDsigSHA1Url;
            cert.CertDigest.DigestValue = _certificate.GetCertHash();
            signedSignatureProperties.SigningCertificate.CertCollection.Add(cert);

            signedSignatureProperties.SigningTime = DateTime.Parse(this.SigningTimeTextBox.Text);

            signedSignatureProperties.SignaturePolicyIdentifier.SignaturePolicyImplied = true;
        }

        private void ShowSignature(bool flag, string filename)
        {

            _envelopedSignatureXmlDocument.DocumentElement.AppendChild(
                _envelopedSignatureXmlDocument.ImportNode(_xadesSignedXml.GetXml(), true));

            if (flag)
            {
                XmlElement xRoot = _envelopedSignatureXmlDocument.DocumentElement;
                xRoot.RemoveChild(xRoot["ds:Signature"]);
                string[] paths = filename.Split(new char[] { '\\' });
                string z = paths[paths.Length - 1].ToString();
                string zz = saveFileTextBox.Text + "/" + z;
                _envelopedSignatureXmlDocument.Save(saveFileTextBox.Text + "\\" + z);
            }
        }

        private void transformXAdEST(string filename)
        {
            TimeStamp signatureTimeStamp;
            HttpTsaClient httpTsaClient;
            KnownTsaResponsePkiStatus tsaResponsePkiStatus;
            ArrayList signatureValueElementXpaths;
            byte[] signatureValueHash;

            if (_xadesSignedXml.SignatureStandard == KnownSignatureStandard.Xades)
            {
                try
                {
                    httpTsaClient = new HttpTsaClient();
                    httpTsaClient.RequestTsaCertificate = TSACheckBox.Checked;
                    signatureValueElementXpaths = new ArrayList();
                    signatureValueElementXpaths.Add("ds:SignatureValue");
                    var elementIdValues = new ArrayList();
                    signatureValueHash = httpTsaClient.ComputeHashValueOfElementList(_xadesSignedXml.GetXml(),
                        signatureValueElementXpaths, ref elementIdValues);
                    httpTsaClient.SendTsaWebRequest(TimestampURITextBox.Text, signatureValueHash);
                    tsaResponsePkiStatus = httpTsaClient.ParseTsaResponse();
                    if (tsaResponsePkiStatus == KnownTsaResponsePkiStatus.Granted)
                    {
                        signatureTimeStamp = new TimeStamp("SignatureTimeStamp");
                        signatureTimeStamp.EncapsulatedTimeStamp.Id = SignatureTimestampIDTextBox.Text;
                        signatureTimeStamp.EncapsulatedTimeStamp.PkiData = httpTsaClient.TsaTimeStamp;
                        var hashDataInfo = new HashDataInfo();
                        hashDataInfo.UriAttribute = "#" + elementIdValues[0];
                        signatureTimeStamp.HashDataInfoCollection.Add(hashDataInfo);
                        var unsignedProperties = _xadesSignedXml.UnsignedProperties;
                        unsignedProperties.UnsignedSignatureProperties.SignatureTimeStampCollection.Add(
                            signatureTimeStamp);
                        _xadesSignedXml.UnsignedProperties = unsignedProperties;

                        var xml = _xadesSignedXml.XadesObject.GetXml();
                        var xml1 = _xadesSignedXml.GetXml();

                        ShowSignature(true, filename);
                    }
                    else
                    {
                        MessageBox.Show("TSA timestamp request not granted: " + tsaResponsePkiStatus.ToString());
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Exception occurred during TSA timestamp request: " + exception.ToString());
                }
            }
            else
            {
                MessageBox.Show(
                    "Signature standard should be XAdES. (You need to add XAdES info before computing the signature to be able to inject a timestamp)");
            }
        }

        private void SourceFileButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                SourceFileTextBox.Text = FBD.SelectedPath;
            }
        }

        private void saveFilebutton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                saveFileTextBox.Text = FBD.SelectedPath;
            }
        }
    }
}
