using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignatureMaker
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void XADeSButton_Click(object sender, EventArgs e)
        {
            OpenForm<XAdES.MainForm>();
        }

        private void OpenForm<TForm>() where TForm : Form, new()
        {
            Hide();
            var form = new TForm();
            form.ShowDialog();
            Close();
        }
    }
}
