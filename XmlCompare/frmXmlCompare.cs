using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace XmlCompare
{
    public partial class frmXmlCompare : Form
    {
        public frmXmlCompare()
        {
            InitializeComponent();
            this.Text = string.Format("{0} ({1})", Application.ProductName, Application.ProductVersion.ToString());
            cboFilter.SelectedIndex = 0;
            cboIdentifier.SelectedIndex = 0;
        }

        private void btnBaseFile_Click(object sender, EventArgs e)
        {
            if(dlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                txtBaseFile.Text = dlgOpenFile.FileName;
            }
        }

        private void btnFileToCompare_Click(object sender, EventArgs e)
        {
            if (dlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                txtFileToCompare.Text = dlgOpenFile.FileName;
            }
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            string sMessageText = string.Empty;
            if (!File.Exists(txtBaseFile.Text))
            {
                sMessageText = string.Format("{0} ({1}) doesn't exist!"
                    , lblBaseFile.Text.Substring(0, lblBaseFile.Text.Length - 1)
                    , txtBaseFile.Text);
                MessageBox.Show(sMessageText);
                return;
            }
            if (!File.Exists(txtFileToCompare.Text))
            {
                sMessageText = string.Format("{0} ({1}) doesn't exist!"
                    , lblFileToCompare.Text.Substring(0, lblFileToCompare.Text.Length - 1)
                    , txtFileToCompare.Text);
                MessageBox.Show(sMessageText);
                return;
            }

            XDocument xBase = XDocument.Load(txtBaseFile.Text);
            webResult.DocumentText = xBase.Document.ToString();
            webResult.Refresh();
        }
    }
}
