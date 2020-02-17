namespace SignatureMaker.CAdES
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtCMSfilename = new System.Windows.Forms.TextBox();
            this.cmdLoadCMS = new System.Windows.Forms.Button();
            this.cmdCreateCMSattached = new System.Windows.Forms.Button();
            this.cmdSaveCMS = new System.Windows.Forms.Button();
            this.cmdCreateCMSdetached = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdAddTimestamp = new System.Windows.Forms.Button();
            this.cmdUpdateAttr = new System.Windows.Forms.Button();
            this.cmdCryptoProVerify = new System.Windows.Forms.Button();
            this.txtAttrOID = new System.Windows.Forms.TextBox();
            this.cmdSaveAttr = new System.Windows.Forms.Button();
            this.cmdSaveMsgDigest = new System.Windows.Forms.Button();
            this.cmdAddAv3 = new System.Windows.Forms.Button();
            this.cmbTSAuri = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdExtendToLT1 = new System.Windows.Forms.Button();
            this.cmdAddSignature = new System.Windows.Forms.Button();
            this.txtSigInfo = new System.Windows.Forms.TextBox();
            this.lbSignatures = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpBuildChain = new System.Windows.Forms.DateTimePicker();
            this.lbCertificates = new System.Windows.Forms.ListBox();
            this.labelCMSinfo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCMSfilename
            // 
            this.txtCMSfilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCMSfilename.Location = new System.Drawing.Point(8, 10);
            this.txtCMSfilename.Margin = new System.Windows.Forms.Padding(2);
            this.txtCMSfilename.Name = "txtCMSfilename";
            this.txtCMSfilename.ReadOnly = true;
            this.txtCMSfilename.Size = new System.Drawing.Size(629, 20);
            this.txtCMSfilename.TabIndex = 0;
            this.txtCMSfilename.TabStop = false;
            // 
            // cmdLoadCMS
            // 
            this.cmdLoadCMS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdLoadCMS.Location = new System.Drawing.Point(641, 8);
            this.cmdLoadCMS.Margin = new System.Windows.Forms.Padding(2);
            this.cmdLoadCMS.Name = "cmdLoadCMS";
            this.cmdLoadCMS.Size = new System.Drawing.Size(119, 21);
            this.cmdLoadCMS.TabIndex = 1;
            this.cmdLoadCMS.Text = "Загрузить CMS";
            this.cmdLoadCMS.UseVisualStyleBackColor = true;
            this.cmdLoadCMS.Click += new System.EventHandler(this.cmdLoadCMS_Click);
            // 
            // cmdCreateCMSattached
            // 
            this.cmdCreateCMSattached.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCreateCMSattached.Location = new System.Drawing.Point(641, 32);
            this.cmdCreateCMSattached.Margin = new System.Windows.Forms.Padding(2);
            this.cmdCreateCMSattached.Name = "cmdCreateCMSattached";
            this.cmdCreateCMSattached.Size = new System.Drawing.Size(119, 21);
            this.cmdCreateCMSattached.TabIndex = 4;
            this.cmdCreateCMSattached.Text = "Создать CMS (att.)";
            this.cmdCreateCMSattached.UseVisualStyleBackColor = true;
            this.cmdCreateCMSattached.Click += new System.EventHandler(this.cmdCreateCMSattached_Click);
            // 
            // cmdSaveCMS
            // 
            this.cmdSaveCMS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSaveCMS.Enabled = false;
            this.cmdSaveCMS.Location = new System.Drawing.Point(763, 8);
            this.cmdSaveCMS.Margin = new System.Windows.Forms.Padding(2);
            this.cmdSaveCMS.Name = "cmdSaveCMS";
            this.cmdSaveCMS.Size = new System.Drawing.Size(119, 21);
            this.cmdSaveCMS.TabIndex = 5;
            this.cmdSaveCMS.Text = "Сохранить CMS";
            this.cmdSaveCMS.UseVisualStyleBackColor = true;
            this.cmdSaveCMS.Click += new System.EventHandler(this.cmdSaveCMS_Click);
            // 
            // cmdCreateCMSdetached
            // 
            this.cmdCreateCMSdetached.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCreateCMSdetached.Location = new System.Drawing.Point(763, 32);
            this.cmdCreateCMSdetached.Margin = new System.Windows.Forms.Padding(2);
            this.cmdCreateCMSdetached.Name = "cmdCreateCMSdetached";
            this.cmdCreateCMSdetached.Size = new System.Drawing.Size(119, 21);
            this.cmdCreateCMSdetached.TabIndex = 6;
            this.cmdCreateCMSdetached.Text = "Создать CMS (det.)";
            this.cmdCreateCMSdetached.UseVisualStyleBackColor = true;
            this.cmdCreateCMSdetached.Click += new System.EventHandler(this.cmdCreateCMSdetached_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cmdAddTimestamp);
            this.groupBox1.Controls.Add(this.cmdUpdateAttr);
            this.groupBox1.Controls.Add(this.cmdCryptoProVerify);
            this.groupBox1.Controls.Add(this.txtAttrOID);
            this.groupBox1.Controls.Add(this.cmdSaveAttr);
            this.groupBox1.Controls.Add(this.cmdSaveMsgDigest);
            this.groupBox1.Controls.Add(this.cmdAddAv3);
            this.groupBox1.Controls.Add(this.cmbTSAuri);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmdExtendToLT1);
            this.groupBox1.Controls.Add(this.cmdAddSignature);
            this.groupBox1.Controls.Add(this.txtSigInfo);
            this.groupBox1.Controls.Add(this.lbSignatures);
            this.groupBox1.Location = new System.Drawing.Point(8, 57);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(874, 296);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Подписи";
            // 
            // cmdAddTimestamp
            // 
            this.cmdAddTimestamp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdAddTimestamp.Enabled = false;
            this.cmdAddTimestamp.Location = new System.Drawing.Point(295, 246);
            this.cmdAddTimestamp.Margin = new System.Windows.Forms.Padding(2);
            this.cmdAddTimestamp.Name = "cmdAddTimestamp";
            this.cmdAddTimestamp.Size = new System.Drawing.Size(384, 21);
            this.cmdAddTimestamp.TabIndex = 8;
            this.cmdAddTimestamp.Text = "Добавить / обновить метку «1.2.840.113549.1.9.16.2.14»";
            this.cmdAddTimestamp.UseVisualStyleBackColor = true;
            this.cmdAddTimestamp.Click += new System.EventHandler(this.cmdAddTimestamp_Click);
            // 
            // cmdUpdateAttr
            // 
            this.cmdUpdateAttr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdUpdateAttr.Enabled = false;
            this.cmdUpdateAttr.Location = new System.Drawing.Point(350, 268);
            this.cmdUpdateAttr.Margin = new System.Windows.Forms.Padding(2);
            this.cmdUpdateAttr.Name = "cmdUpdateAttr";
            this.cmdUpdateAttr.Size = new System.Drawing.Size(131, 21);
            this.cmdUpdateAttr.TabIndex = 12;
            this.cmdUpdateAttr.Text = "<=Изменить атрибут";
            this.cmdUpdateAttr.UseVisualStyleBackColor = true;
            this.cmdUpdateAttr.Click += new System.EventHandler(this.cmdUpdateAttr_Click);
            // 
            // cmdCryptoProVerify
            // 
            this.cmdCryptoProVerify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdCryptoProVerify.Enabled = false;
            this.cmdCryptoProVerify.Location = new System.Drawing.Point(682, 222);
            this.cmdCryptoProVerify.Margin = new System.Windows.Forms.Padding(2);
            this.cmdCryptoProVerify.Name = "cmdCryptoProVerify";
            this.cmdCryptoProVerify.Size = new System.Drawing.Size(188, 44);
            this.cmdCryptoProVerify.TabIndex = 9;
            this.cmdCryptoProVerify.Text = "Проверить подпись X-LongType1 через COM-объект \"КриптоПРО\"";
            this.cmdCryptoProVerify.UseVisualStyleBackColor = true;
            this.cmdCryptoProVerify.Click += new System.EventHandler(this.cmdCryptoProVerify_Click);
            // 
            // txtAttrOID
            // 
            this.txtAttrOID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAttrOID.Location = new System.Drawing.Point(4, 270);
            this.txtAttrOID.Margin = new System.Windows.Forms.Padding(2);
            this.txtAttrOID.Name = "txtAttrOID";
            this.txtAttrOID.Size = new System.Drawing.Size(208, 20);
            this.txtAttrOID.TabIndex = 10;
            // 
            // cmdSaveAttr
            // 
            this.cmdSaveAttr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdSaveAttr.Enabled = false;
            this.cmdSaveAttr.Location = new System.Drawing.Point(215, 268);
            this.cmdSaveAttr.Margin = new System.Windows.Forms.Padding(2);
            this.cmdSaveAttr.Name = "cmdSaveAttr";
            this.cmdSaveAttr.Size = new System.Drawing.Size(131, 21);
            this.cmdSaveAttr.TabIndex = 11;
            this.cmdSaveAttr.Text = "<= Сохранить атрибут";
            this.cmdSaveAttr.UseVisualStyleBackColor = true;
            this.cmdSaveAttr.Click += new System.EventHandler(this.cmdSaveAttr_Click);
            // 
            // cmdSaveMsgDigest
            // 
            this.cmdSaveMsgDigest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdSaveMsgDigest.Enabled = false;
            this.cmdSaveMsgDigest.Location = new System.Drawing.Point(548, 222);
            this.cmdSaveMsgDigest.Margin = new System.Windows.Forms.Padding(2);
            this.cmdSaveMsgDigest.Name = "cmdSaveMsgDigest";
            this.cmdSaveMsgDigest.Size = new System.Drawing.Size(131, 21);
            this.cmdSaveMsgDigest.TabIndex = 5;
            this.cmdSaveMsgDigest.Text = "Сохранить дайджест";
            this.cmdSaveMsgDigest.UseVisualStyleBackColor = true;
            this.cmdSaveMsgDigest.Click += new System.EventHandler(this.cmdSaveMsgDigest_Click);
            // 
            // cmdAddAv3
            // 
            this.cmdAddAv3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdAddAv3.Enabled = false;
            this.cmdAddAv3.Location = new System.Drawing.Point(337, 222);
            this.cmdAddAv3.Margin = new System.Windows.Forms.Padding(2);
            this.cmdAddAv3.Name = "cmdAddAv3";
            this.cmdAddAv3.Size = new System.Drawing.Size(207, 21);
            this.cmdAddAv3.TabIndex = 4;
            this.cmdAddAv3.Text = "Добавить атрибут CAdES-A v3";
            this.cmdAddAv3.UseVisualStyleBackColor = true;
            this.cmdAddAv3.Click += new System.EventHandler(this.cmdAddAv3_Click);
            // 
            // cmbTSAuri
            // 
            this.cmbTSAuri.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbTSAuri.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbTSAuri.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl;
            this.cmbTSAuri.FormattingEnabled = true;
            this.cmbTSAuri.Items.AddRange(new object[] {
            "http://ep.uat.guc.voskhod.ru:8882/tsp/tsp.srf",
            "http://10.0.2.51/TSP/tsp.srf",
            "http://tsp.e-notary.ru",
            "http://www.cryptopro.ru/tsp/tsp.srf",
            "http://ra.voskhod.ru/TSP/TSP.srf"});
            this.cmbTSAuri.Location = new System.Drawing.Point(49, 248);
            this.cmbTSAuri.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTSAuri.Name = "cmbTSAuri";
            this.cmbTSAuri.Size = new System.Drawing.Size(244, 21);
            this.cmbTSAuri.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 250);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "TSA uri";
            // 
            // cmdExtendToLT1
            // 
            this.cmdExtendToLT1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdExtendToLT1.Enabled = false;
            this.cmdExtendToLT1.Location = new System.Drawing.Point(127, 222);
            this.cmdExtendToLT1.Margin = new System.Windows.Forms.Padding(2);
            this.cmdExtendToLT1.Name = "cmdExtendToLT1";
            this.cmdExtendToLT1.Size = new System.Drawing.Size(207, 21);
            this.cmdExtendToLT1.TabIndex = 3;
            this.cmdExtendToLT1.Text = "Расширить до CAdES-X LongType 1";
            this.cmdExtendToLT1.UseVisualStyleBackColor = true;
            this.cmdExtendToLT1.Click += new System.EventHandler(this.cmdExtendToLT1_Click);
            // 
            // cmdAddSignature
            // 
            this.cmdAddSignature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdAddSignature.Enabled = false;
            this.cmdAddSignature.Location = new System.Drawing.Point(4, 222);
            this.cmdAddSignature.Margin = new System.Windows.Forms.Padding(2);
            this.cmdAddSignature.Name = "cmdAddSignature";
            this.cmdAddSignature.Size = new System.Drawing.Size(119, 21);
            this.cmdAddSignature.TabIndex = 2;
            this.cmdAddSignature.Text = "Добавить";
            this.cmdAddSignature.UseVisualStyleBackColor = true;
            this.cmdAddSignature.Click += new System.EventHandler(this.cmdAddSignature_Click);
            // 
            // txtSigInfo
            // 
            this.txtSigInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSigInfo.Location = new System.Drawing.Point(295, 16);
            this.txtSigInfo.Margin = new System.Windows.Forms.Padding(2);
            this.txtSigInfo.Multiline = true;
            this.txtSigInfo.Name = "txtSigInfo";
            this.txtSigInfo.ReadOnly = true;
            this.txtSigInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSigInfo.Size = new System.Drawing.Size(575, 204);
            this.txtSigInfo.TabIndex = 1;
            this.txtSigInfo.TabStop = false;
            this.txtSigInfo.WordWrap = false;
            // 
            // lbSignatures
            // 
            this.lbSignatures.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbSignatures.FormattingEnabled = true;
            this.lbSignatures.IntegralHeight = false;
            this.lbSignatures.Location = new System.Drawing.Point(4, 16);
            this.lbSignatures.Margin = new System.Windows.Forms.Padding(2);
            this.lbSignatures.Name = "lbSignatures";
            this.lbSignatures.ScrollAlwaysVisible = true;
            this.lbSignatures.Size = new System.Drawing.Size(289, 204);
            this.lbSignatures.TabIndex = 0;
            this.lbSignatures.SelectedIndexChanged += new System.EventHandler(this.lbSignatures_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dtpBuildChain);
            this.groupBox2.Controls.Add(this.lbCertificates);
            this.groupBox2.Location = new System.Drawing.Point(8, 357);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(874, 94);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Сертификаты";
            // 
            // dtpBuildChain
            // 
            this.dtpBuildChain.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpBuildChain.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBuildChain.Location = new System.Drawing.Point(4, 16);
            this.dtpBuildChain.Margin = new System.Windows.Forms.Padding(2);
            this.dtpBuildChain.Name = "dtpBuildChain";
            this.dtpBuildChain.Size = new System.Drawing.Size(193, 20);
            this.dtpBuildChain.TabIndex = 1;
            // 
            // lbCertificates
            // 
            this.lbCertificates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCertificates.FormattingEnabled = true;
            this.lbCertificates.IntegralHeight = false;
            this.lbCertificates.Location = new System.Drawing.Point(4, 36);
            this.lbCertificates.Margin = new System.Windows.Forms.Padding(2);
            this.lbCertificates.Name = "lbCertificates";
            this.lbCertificates.ScrollAlwaysVisible = true;
            this.lbCertificates.Size = new System.Drawing.Size(867, 49);
            this.lbCertificates.TabIndex = 0;
            this.lbCertificates.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbCertificates_MouseDoubleClick);
            // 
            // labelCMSinfo
            // 
            this.labelCMSinfo.AutoSize = true;
            this.labelCMSinfo.Location = new System.Drawing.Point(9, 29);
            this.labelCMSinfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCMSinfo.Name = "labelCMSinfo";
            this.labelCMSinfo.Size = new System.Drawing.Size(25, 13);
            this.labelCMSinfo.TabIndex = 9;
            this.labelCMSinfo.Text = "???";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 466);
            this.Controls.Add(this.labelCMSinfo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdCreateCMSdetached);
            this.Controls.Add(this.cmdSaveCMS);
            this.Controls.Add(this.cmdCreateCMSattached);
            this.Controls.Add(this.cmdLoadCMS);
            this.Controls.Add(this.txtCMSfilename);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CAdESForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCMSfilename;
        private System.Windows.Forms.Button cmdLoadCMS;
        private System.Windows.Forms.Button cmdCreateCMSattached;
        private System.Windows.Forms.Button cmdSaveCMS;
        private System.Windows.Forms.Button cmdCreateCMSdetached;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdAddTimestamp;
        private System.Windows.Forms.Button cmdUpdateAttr;
        private System.Windows.Forms.Button cmdCryptoProVerify;
        private System.Windows.Forms.TextBox txtAttrOID;
        private System.Windows.Forms.Button cmdSaveAttr;
        private System.Windows.Forms.Button cmdSaveMsgDigest;
        private System.Windows.Forms.Button cmdAddAv3;
        private System.Windows.Forms.ComboBox cmbTSAuri;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdExtendToLT1;
        private System.Windows.Forms.Button cmdAddSignature;
        private System.Windows.Forms.TextBox txtSigInfo;
        private System.Windows.Forms.ListBox lbSignatures;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpBuildChain;
        private System.Windows.Forms.ListBox lbCertificates;
        private System.Windows.Forms.Label labelCMSinfo;
    }
}