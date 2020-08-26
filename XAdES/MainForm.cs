using Microsoft.Xades;
using SignatureMaker.WinForm.Xades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Threading;
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

        string XAdES = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:esv=\"http://esv.server.rt.ru\">" +
                "<soapenv:Header/><soapenv:Body><esv:VerifyXAdES><esv:message></esv:message><esv:verifySignatureOnly>false</esv:verifySignatureOnly>" +
                "</esv:VerifyXAdES></soapenv:Body></soapenv:Envelope>";

        string XAdESWithSignedReport = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:esv=\"http://esv.server.rt.ru\">" +
            "<soapenv:Header/><soapenv:Body><esv:VerifyXAdESWithSignedReport><esv:message></esv:message><esv:verifySignatureOnly>false</esv:verifySignatureOnly>" +
            "</esv:VerifyXAdESWithSignedReport></soapenv:Body></soapenv:Envelope>";

        string XMLDSig = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:esv=\"http://esv.server.rt.ru\">" +
            "<soapenv:Header/><soapenv:Body><esv:VerifyXMLSignature><esv:message></esv:message><esv:verifySignatureOnly>false</esv:verifySignatureOnly>" +
            "</esv:VerifyXMLSignature></soapenv:Body></soapenv:Envelope>";

        string XMLDSigWithSignedReport = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:esv=\"http://esv.server.rt.ru\">" +
            "<soapenv:Header/><soapenv:Body><esv:VerifyXMLSignatureWithSignedReport><esv:message></esv:message><esv:verifySignatureOnly>false</esv:verifySignatureOnly>" +
            "</esv:VerifyXMLSignatureWithSignedReport></soapenv:Body></soapenv:Envelope>";
        string csvXAdES = "VerifyXAdES_simple.csv";
        string csvXAdESSignedReport = "VerifyXAdES_withSignedReport.csv";
        string csvXML = "VerifyXML_simple.csv";
        string csvXMLSignedReport = "VerifyXML_withSignedReport.csv";
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.XAdESTRadioButton.Checked = true;
            this.SigningTimeTextBox.Text = DateTime.Now.ToString("s");
            this.WSDLCheckBox.Checked = true;
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
                    this.CertificateDetailsLabel.Text = _certificate.SubjectName.Name + _certificate.IssuerName.Name + "\n" + _certificate.SerialNumber;

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
                if (
                    (SourceFileTextBox.Text != "") && (saveFileTextBox.Text != "") &&
                    (ObjectIdPrefixTextBox.Text != "") && (SignatureIdTextBox.Text != "") &&
                    (SigningTimeTextBox.Text != "") && (SignatureValueIdTextBox.Text != ""))
                {
                    if (XAdESRadioButton.Checked || ((TimestampURITextBox.Text != "") && (SignatureTimestampIDTextBox.Text != "")))
                    {
                        if (XAdESRadioButton.Checked)
                        {
                            using (StreamWriter writer = new StreamWriter(new FileStream(saveFileTextBox.Text + "\\" + csvXML, FileMode.Create, FileAccess.Write)))
                            {
                                writer.WriteLine("file,response");
                            }
                            using (StreamWriter writer = new StreamWriter(new FileStream(saveFileTextBox.Text + "\\" + csvXMLSignedReport, FileMode.Create, FileAccess.Write)))
                            {
                                writer.WriteLine("file,response");
                            }
                        }
                        else
                        {
                            using (StreamWriter writer = new StreamWriter(new FileStream(saveFileTextBox.Text + "\\" + csvXAdES, FileMode.Create, FileAccess.Write)))
                            {
                                writer.WriteLine("file,response");
                            }
                            using (StreamWriter writer = new StreamWriter(new FileStream(saveFileTextBox.Text + "\\" + csvXAdESSignedReport, FileMode.Create, FileAccess.Write)))
                            {
                                writer.WriteLine("file,response");
                            }
                        }
                        SubscribeProgressBar.Value = 0;
                        IEnumerable<string> allfiles = Directory.EnumerateFiles(SourceFileTextBox.Text);
                        Thread t = new Thread(new ThreadStart(delegate
                        {
                            foreach (string filename in allfiles)
                            {
                                this.Invoke(new ThreadStart(delegate
                                {
                                    connectFile(filename);
                                    AddCertificateInfoToSignature();
                                    signedFile(filename);
                                    SubscribeProgressBar.Value++;
                                }));
                            }
                            // выдать сообщение, что подпись создана и очистить поля
                            //MessageBox.Show(
                            //            "Создание подписи",
                            //            "Файл подписан",
                            //            MessageBoxButtons.OK,
                            //            MessageBoxIcon.Information,
                            //            MessageBoxDefaultButton.Button1,
                            //            MessageBoxOptions.DefaultDesktopOnly);
                        }));
                        t.Start();
                    }
                    else
                    {
                        MessageBox.Show(
                    "Заполните все поля для XAdES-T!",
                    "Ошибка при создании подписи",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                    }
                }
                else
                {
                    MessageBox.Show(
                    "Заполните все поля!",
                    "Ошибка при создании подписи",
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



                    if (XAdESRadioButton.Checked)
                    {
                        addSignature(true, filename, true);
                    }

                    if (XAdESTRadioButton.Checked)
                    {
                        addSignature(false, filename);
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

        private void addSignature(bool flag, string filename, bool xades = false)
        {

            _envelopedSignatureXmlDocument.DocumentElement.AppendChild(
                _envelopedSignatureXmlDocument.ImportNode(_xadesSignedXml.GetXml(), true));

            if (flag)
            {
                if (!xades)
                {
                    XmlElement xRoot = _envelopedSignatureXmlDocument.DocumentElement;
                    xRoot.RemoveChild(xRoot["ds:Signature"]);
                }

                string[] paths = filename.Split(new char[] { '\\' });
                string name = paths[paths.Length - 1].ToString();
                if (WSDLCheckBox.Checked)
                {
                    if (xades)
                    {
                        transformXML(_envelopedSignatureXmlDocument, saveFileTextBox.Text + "\\", name, "VerifyXML_simple");
                        transformXML(_envelopedSignatureXmlDocument, saveFileTextBox.Text + "\\", name, "VerifyXML_withSignedReport");
                        
                    }
                    else
                    {
                        transformXML(_envelopedSignatureXmlDocument, saveFileTextBox.Text + "\\", name, "VerifyXAdES_simple");
                        transformXML(_envelopedSignatureXmlDocument, saveFileTextBox.Text + "\\", name, "VerifyXAdES_withSignedReport");
                    }
                }
                else
                    _envelopedSignatureXmlDocument.Save(saveFileTextBox.Text + "\\" + name);
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
                    httpTsaClient.RequestTsaCertificate = true;
                    signatureValueElementXpaths = new ArrayList();
                    signatureValueElementXpaths.Add("ds:SignatureValue");
                    var elementIdValues = new ArrayList();
                    signatureValueHash = httpTsaClient.ComputeHashValueOfElementList(_xadesSignedXml.GetXml(),
                        signatureValueElementXpaths, ref elementIdValues);

                    httpTsaClient.SendTsaWebRequest(TimestampURITextBox.Text, signatureValueHash);
                    try
                    {
                        tsaResponsePkiStatus = httpTsaClient.ParseTsaResponse();
                    }
                    catch (Exception)
                    {
                        Thread.Sleep(2000);
                        tsaResponsePkiStatus = httpTsaClient.ParseTsaResponse();
                    }
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

                        addSignature(true, filename);
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

        private void transformXML(XmlDocument xml, string path, string file, string type)
        {
            XmlDocument xDoc = new XmlDocument();
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(xml.InnerXml);
            var type2 = "";
            switch (type)
            {
                case "VerifyXAdES_simple":
                    xDoc.LoadXml(XAdES);
                    type2 = "VerifyXAdES";
                    break;
                case "VerifyXAdES_withSignedReport":
                    xDoc.LoadXml(XAdESWithSignedReport);
                    type2 = "VerifyXAdESWithSignedReport";
                    break;
                case "VerifyXML_simple":
                    xDoc.LoadXml(XMLDSig);
                    type2 = "VerifyXMLSignature";
                    break; ;
                case "VerifyXML_withSignedReport":
                    type2 = "VerifyXMLSignatureWithSignedReport";
                    xDoc.LoadXml(XMLDSigWithSignedReport);
                    break;
            }
            XmlElement xRoot = xDoc.DocumentElement;
            xRoot["soapenv:Body"]["esv:" + type2]["esv:message"].InnerXml = System.Convert.ToBase64String(plainTextBytes);
            xDoc.Save(path + type + "_" + file);

            if (XAdESRadioButton.Checked)
            {
                using (StreamWriter writer = new StreamWriter(new FileStream(saveFileTextBox.Text + "\\" + type + ".csv", FileMode.Append, FileAccess.Write)))
                {
                    writer.WriteLine(type + "_" + file + ",<Code>0</Code>");
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(new FileStream(saveFileTextBox.Text + "\\" + type + ".csv", FileMode.Append, FileAccess.Write)))
                {
                    writer.WriteLine(type + "_" + file + ",<Code>0</Code>");
                }
            }
        }

        private void SourceFileButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                SourceFileTextBox.Text = FBD.SelectedPath;
                int count = System.IO.Directory.GetFiles(FBD.SelectedPath).Length;
                endLabel.Text = count.ToString();
                SubscribeProgressBar.Maximum = count;
                SubscribeProgressBar.Value = 0;
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

        private void XAdESRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (XAdESRadioButton.Checked)
            {
                groupBox3.Enabled = false;
            }
            else
            {
                groupBox3.Enabled = true;
            }
        }
    }
}
