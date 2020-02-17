using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace SignatureMaker.WinForm.Cades
{
	public partial class CertSelectForm : Form
	{
		public CertSelectForm()
		{
			InitializeComponent();
		}

		private readonly Dictionary<string, X509Certificate2> _cDict = new Dictionary<string, X509Certificate2>();

		private void AddCertToList(X509Certificate2 cc)
		{
			if (cc.HasPrivateKey)
			{
				if (_cDict.ContainsKey(cc.GetCertHashString())) return;
				var ii = lvCertificates.Items.Add(cc.Subject);
				ii.SubItems.Add(cc.Issuer);
				ii.SubItems.Add(cc.GetKeyAlgorithm());
				ii.SubItems.Add(cc.GetCertHashString());
				ii.SubItems.Add(cc.SerialNumber);
				ii.SubItems.Add(cc.NotBefore.ToString("yyyy-MM-dd HH:mm:ss"));
				ii.SubItems.Add(cc.NotAfter.ToString("yyyy-MM-dd HH:mm:ss"));
				ii.Tag = cc;
				_cDict.Add(cc.GetCertHashString(), cc);
			}
		}

		private void frmCertSelect_Load(object sender, EventArgs e)
		{
			lvCertificates.Columns.Add("Кому выдан").Width = 256;
			lvCertificates.Columns.Add("Кем выдан").Width = 256;
			lvCertificates.Columns.Add("Алгоритм").Width = 128;
			lvCertificates.Columns.Add("Отпечаток").Width = 320;
			lvCertificates.Columns.Add("Номер").Width = 320;
			lvCertificates.Columns.Add("Действует с").Width = 128;
			lvCertificates.Columns.Add("Действует до").Width = 128;

			var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
			store.Open(OpenFlags.ReadOnly);

			foreach (var cc in store.Certificates)
				AddCertToList(cc);

			store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
			store.Open(OpenFlags.ReadOnly);

			foreach (var cc in store.Certificates)
				AddCertToList(cc);
		}

		private void lvCertificates_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (lvCertificates.SelectedItems.Count == 1)
			{
				if (lvCertificates.SelectedItems[0].Bounds.Contains(e.Location))
					DialogResult = DialogResult.OK;
			}
		}

		private void lvCertificates_SelectedIndexChanged(object sender, EventArgs e)
		{
			cmdOk.Enabled = lvCertificates.SelectedItems.Count == 1;
		}

		private void lvCertificates_KeyPressEvent(object sender, KeyEventArgs e)
		{
			if (lvCertificates.SelectedItems.Count != 1)
				return;

			if (e.Control && e.KeyCode == Keys.C)
			{
				var cer = lvCertificates.SelectedItems[0].Tag as X509Certificate2;
				Clipboard.SetText(cer.SerialNumber);
			}
		}
	}
}