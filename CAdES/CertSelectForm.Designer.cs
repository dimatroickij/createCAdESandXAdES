using System.Windows.Forms;

namespace SignatureMaker.WinForm.Cades
{
	partial class CertSelectForm
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
			this.lvCertificates = new System.Windows.Forms.ListView();
			this.cmdOk = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lvCertificates
			// 
			this.lvCertificates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lvCertificates.FullRowSelect = true;
			this.lvCertificates.GridLines = true;
			this.lvCertificates.Location = new System.Drawing.Point(12, 12);
			this.lvCertificates.MultiSelect = false;
			this.lvCertificates.Name = "lvCertificates";
			this.lvCertificates.Size = new System.Drawing.Size(738, 417);
			this.lvCertificates.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lvCertificates.TabIndex = 0;
			this.lvCertificates.UseCompatibleStateImageBehavior = false;
			this.lvCertificates.View = System.Windows.Forms.View.Details;
			this.lvCertificates.KeyDown += new KeyEventHandler(this.lvCertificates_KeyPressEvent);
			this.lvCertificates.SelectedIndexChanged += new System.EventHandler(this.lvCertificates_SelectedIndexChanged);
			this.lvCertificates.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvCertificates_MouseDoubleClick);
			// 
			// cmdOk
			// 
			this.cmdOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.cmdOk.Enabled = false;
			this.cmdOk.Location = new System.Drawing.Point(554, 435);
			this.cmdOk.Name = "cmdOk";
			this.cmdOk.Size = new System.Drawing.Size(95, 32);
			this.cmdOk.TabIndex = 1;
			this.cmdOk.Text = "Готово";
			this.cmdOk.UseVisualStyleBackColor = true;
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(655, 435);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(95, 32);
			this.cmdCancel.TabIndex = 2;
			this.cmdCancel.Text = "Отмена";
			this.cmdCancel.UseVisualStyleBackColor = true;
			// 
			// frmCertSelect
			// 
			this.AcceptButton = this.cmdOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(762, 479);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOk);
			this.Controls.Add(this.lvCertificates);
			this.Name = "CertSelectForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Выберите сертификат для подписи";
			this.Load += new System.EventHandler(this.frmCertSelect_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button cmdOk;
		private System.Windows.Forms.Button cmdCancel;
		public System.Windows.Forms.ListView lvCertificates;
	}
}