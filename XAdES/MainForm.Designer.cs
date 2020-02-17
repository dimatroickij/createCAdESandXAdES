namespace SignatureMaker.XAdES
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
            this.XAdESTRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.selectCertificateButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SourceFileTextBox = new System.Windows.Forms.TextBox();
            this.saveFileTextBox = new System.Windows.Forms.TextBox();
            this.SourceFileButton = new System.Windows.Forms.Button();
            this.saveFilebutton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.SignatureValueIdTextBox = new System.Windows.Forms.TextBox();
            this.SigningTimeTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ObjectIdPrefixTextBox = new System.Windows.Forms.TextBox();
            this.SignatureIdTextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TimestampURITextBox = new System.Windows.Forms.TextBox();
            this.SignatureTimestampIDTextBox = new System.Windows.Forms.TextBox();
            this.SubscribeButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.CertificateDetailsLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.SubscribeProgressBar = new System.Windows.Forms.ProgressBar();
            this.endLabel = new System.Windows.Forms.Label();
            this.WSDLCheckBox = new System.Windows.Forms.CheckBox();
            this.XAdESRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // XAdESTRadioButton
            // 
            this.XAdESTRadioButton.AutoSize = true;
            this.XAdESTRadioButton.Location = new System.Drawing.Point(6, 42);
            this.XAdESTRadioButton.Name = "XAdESTRadioButton";
            this.XAdESTRadioButton.Size = new System.Drawing.Size(69, 17);
            this.XAdESTRadioButton.TabIndex = 1;
            this.XAdESTRadioButton.TabStop = true;
            this.XAdESTRadioButton.Text = "XAdES-T";
            this.XAdESTRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.XAdESRadioButton);
            this.groupBox1.Controls.Add(this.XAdESTRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 67);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выберите тип подписи";
            // 
            // selectCertificateButton
            // 
            this.selectCertificateButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.selectCertificateButton.Location = new System.Drawing.Point(348, 11);
            this.selectCertificateButton.Name = "selectCertificateButton";
            this.selectCertificateButton.Size = new System.Drawing.Size(186, 51);
            this.selectCertificateButton.TabIndex = 3;
            this.selectCertificateButton.Text = "Выберите сертификат";
            this.selectCertificateButton.UseVisualStyleBackColor = true;
            this.selectCertificateButton.Click += new System.EventHandler(this.selectCertificate_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Папка с документами для подписи";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "Папка с подписанными документами";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.77264F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.22736F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Controls.Add(this.SourceFileTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.saveFileTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.SourceFileButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.saveFilebutton, 2, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 177);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(588, 62);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // SourceFileTextBox
            // 
            this.SourceFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SourceFileTextBox.Location = new System.Drawing.Point(157, 5);
            this.SourceFileTextBox.Name = "SourceFileTextBox";
            this.SourceFileTextBox.ReadOnly = true;
            this.SourceFileTextBox.Size = new System.Drawing.Size(377, 20);
            this.SourceFileTextBox.TabIndex = 8;
            // 
            // saveFileTextBox
            // 
            this.saveFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.saveFileTextBox.Location = new System.Drawing.Point(157, 36);
            this.saveFileTextBox.Name = "saveFileTextBox";
            this.saveFileTextBox.ReadOnly = true;
            this.saveFileTextBox.Size = new System.Drawing.Size(377, 20);
            this.saveFileTextBox.TabIndex = 7;
            // 
            // SourceFileButton
            // 
            this.SourceFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SourceFileButton.Location = new System.Drawing.Point(540, 4);
            this.SourceFileButton.Name = "SourceFileButton";
            this.SourceFileButton.Size = new System.Drawing.Size(45, 23);
            this.SourceFileButton.TabIndex = 9;
            this.SourceFileButton.Text = "...";
            this.SourceFileButton.UseVisualStyleBackColor = true;
            this.SourceFileButton.Click += new System.EventHandler(this.SourceFileButton_Click);
            // 
            // saveFilebutton
            // 
            this.saveFilebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.saveFilebutton.Location = new System.Drawing.Point(540, 35);
            this.saveFilebutton.Name = "saveFilebutton";
            this.saveFilebutton.Size = new System.Drawing.Size(45, 23);
            this.saveFilebutton.TabIndex = 10;
            this.saveFilebutton.Text = "...";
            this.saveFilebutton.UseVisualStyleBackColor = true;
            this.saveFilebutton.Click += new System.EventHandler(this.saveFilebutton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Location = new System.Drawing.Point(12, 245);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(588, 94);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Данные для подписи";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.07407F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.92593F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 198F));
            this.tableLayoutPanel2.Controls.Add(this.SignatureValueIdTextBox, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.SigningTimeTextBox, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.ObjectIdPrefixTextBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.SignatureIdTextBox, 1, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(576, 66);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // SignatureValueIdTextBox
            // 
            this.SignatureValueIdTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SignatureValueIdTextBox.Location = new System.Drawing.Point(380, 39);
            this.SignatureValueIdTextBox.Name = "SignatureValueIdTextBox";
            this.SignatureValueIdTextBox.Size = new System.Drawing.Size(193, 20);
            this.SignatureValueIdTextBox.TabIndex = 5;
            this.SignatureValueIdTextBox.Text = "SignatureValueId";
            // 
            // SigningTimeTextBox
            // 
            this.SigningTimeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SigningTimeTextBox.Location = new System.Drawing.Point(380, 6);
            this.SigningTimeTextBox.Name = "SigningTimeTextBox";
            this.SigningTimeTextBox.Size = new System.Drawing.Size(193, 20);
            this.SigningTimeTextBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Object Id prefix";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Signature Id";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(277, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Signing time";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(277, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Signature Value Id";
            // 
            // ObjectIdPrefixTextBox
            // 
            this.ObjectIdPrefixTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ObjectIdPrefixTextBox.Location = new System.Drawing.Point(96, 6);
            this.ObjectIdPrefixTextBox.Name = "ObjectIdPrefixTextBox";
            this.ObjectIdPrefixTextBox.Size = new System.Drawing.Size(175, 20);
            this.ObjectIdPrefixTextBox.TabIndex = 4;
            this.ObjectIdPrefixTextBox.Text = "ObjectId-";
            // 
            // SignatureIdTextBox
            // 
            this.SignatureIdTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SignatureIdTextBox.Location = new System.Drawing.Point(96, 39);
            this.SignatureIdTextBox.Name = "SignatureIdTextBox";
            this.SignatureIdTextBox.Size = new System.Drawing.Size(175, 20);
            this.SignatureIdTextBox.TabIndex = 5;
            this.SignatureIdTextBox.Text = "SignatureId";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.tableLayoutPanel3);
            this.groupBox3.Location = new System.Drawing.Point(12, 345);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(588, 111);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Данные для XAdES-T";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.30541F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.69459F));
            this.tableLayoutPanel3.Controls.Add(this.label8, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.TimestampURITextBox, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.SignatureTimestampIDTextBox, 1, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(576, 86);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Signature timestamp ID";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Timestamp Authority URI";
            // 
            // TimestampURITextBox
            // 
            this.TimestampURITextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TimestampURITextBox.Location = new System.Drawing.Point(148, 11);
            this.TimestampURITextBox.Name = "TimestampURITextBox";
            this.TimestampURITextBox.Size = new System.Drawing.Size(425, 20);
            this.TimestampURITextBox.TabIndex = 5;
            this.TimestampURITextBox.Text = "http://www.cryptopro.ru/tsp/tsp.srf";
            // 
            // SignatureTimestampIDTextBox
            // 
            this.SignatureTimestampIDTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SignatureTimestampIDTextBox.Location = new System.Drawing.Point(148, 54);
            this.SignatureTimestampIDTextBox.Name = "SignatureTimestampIDTextBox";
            this.SignatureTimestampIDTextBox.Size = new System.Drawing.Size(425, 20);
            this.SignatureTimestampIDTextBox.TabIndex = 6;
            this.SignatureTimestampIDTextBox.Text = "SignatureTimeStampId";
            // 
            // SubscribeButton
            // 
            this.SubscribeButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SubscribeButton.Location = new System.Drawing.Point(6, 493);
            this.SubscribeButton.Name = "SubscribeButton";
            this.SubscribeButton.Size = new System.Drawing.Size(588, 57);
            this.SubscribeButton.TabIndex = 9;
            this.SubscribeButton.Text = "Подписать";
            this.SubscribeButton.UseVisualStyleBackColor = true;
            this.SubscribeButton.Click += new System.EventHandler(this.SubscribeButton_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.selectCertificateButton, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(588, 73);
            this.tableLayoutPanel4.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 26);
            this.label9.TabIndex = 11;
            this.label9.Text = "Данные сертификата";
            // 
            // CertificateDetailsLabel
            // 
            this.CertificateDetailsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CertificateDetailsLabel.AutoSize = true;
            this.CertificateDetailsLabel.Location = new System.Drawing.Point(91, 33);
            this.CertificateDetailsLabel.Name = "CertificateDetailsLabel";
            this.CertificateDetailsLabel.Size = new System.Drawing.Size(494, 13);
            this.CertificateDetailsLabel.TabIndex = 12;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.96599F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.03401F));
            this.tableLayoutPanel5.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.CertificateDetailsLabel, 1, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(12, 91);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(588, 80);
            this.tableLayoutPanel5.TabIndex = 13;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.17829F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.82171F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableLayoutPanel6.Controls.Add(this.SubscribeProgressBar, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.endLabel, 2, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(9, 556);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(588, 29);
            this.tableLayoutPanel6.TabIndex = 15;
            // 
            // SubscribeProgressBar
            // 
            this.SubscribeProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SubscribeProgressBar.Location = new System.Drawing.Point(70, 3);
            this.SubscribeProgressBar.Name = "SubscribeProgressBar";
            this.SubscribeProgressBar.Size = new System.Drawing.Size(442, 23);
            this.SubscribeProgressBar.TabIndex = 15;
            // 
            // endLabel
            // 
            this.endLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.endLabel.AutoSize = true;
            this.endLabel.Location = new System.Drawing.Point(545, 8);
            this.endLabel.Name = "endLabel";
            this.endLabel.Size = new System.Drawing.Size(13, 13);
            this.endLabel.TabIndex = 16;
            this.endLabel.Text = "0";
            // 
            // WSDLCheckBox
            // 
            this.WSDLCheckBox.AutoSize = true;
            this.WSDLCheckBox.Location = new System.Drawing.Point(12, 462);
            this.WSDLCheckBox.Name = "WSDLCheckBox";
            this.WSDLCheckBox.Size = new System.Drawing.Size(165, 17);
            this.WSDLCheckBox.TabIndex = 16;
            this.WSDLCheckBox.Text = "Формат файлов для WSDL";
            this.WSDLCheckBox.UseVisualStyleBackColor = true;
            // 
            // XAdESRadioButton
            // 
            this.XAdESRadioButton.AutoSize = true;
            this.XAdESRadioButton.Location = new System.Drawing.Point(6, 19);
            this.XAdESRadioButton.Name = "XAdESRadioButton";
            this.XAdESRadioButton.Size = new System.Drawing.Size(59, 17);
            this.XAdESRadioButton.TabIndex = 2;
            this.XAdESRadioButton.TabStop = true;
            this.XAdESRadioButton.Text = "XAdES";
            this.XAdESRadioButton.UseVisualStyleBackColor = true;
            this.XAdESRadioButton.CheckedChanged += new System.EventHandler(this.XAdESRadioButton_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 597);
            this.Controls.Add(this.WSDLCheckBox);
            this.Controls.Add(this.tableLayoutPanel6);
            this.Controls.Add(this.tableLayoutPanel5);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Controls.Add(this.SubscribeButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XAdESForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton XAdESTRadioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button selectCertificateButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox saveFileTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox SignatureValueIdTextBox;
        private System.Windows.Forms.TextBox SigningTimeTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ObjectIdPrefixTextBox;
        private System.Windows.Forms.TextBox SignatureIdTextBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TimestampURITextBox;
        private System.Windows.Forms.TextBox SignatureTimestampIDTextBox;
        private System.Windows.Forms.Button SubscribeButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TextBox SourceFileTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label CertificateDetailsLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button SourceFileButton;
        private System.Windows.Forms.Button saveFilebutton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.ProgressBar SubscribeProgressBar;
        private System.Windows.Forms.Label endLabel;
        private System.Windows.Forms.CheckBox WSDLCheckBox;
        private System.Windows.Forms.RadioButton XAdESRadioButton;
    }
}