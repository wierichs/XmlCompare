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
using System.Xml;
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
      if (dlgOpenFile.ShowDialog() == DialogResult.OK)
      {
        txtBaseFile.Text = dlgOpenFile.FileName;
        cboIdentifier.Items.Clear();
        cboIdentifier.Items.AddRange(GetAttributeNames(XDocument.Load(txtBaseFile.Text).Root));
        if (cboIdentifier.Items.Contains("ID")) { cboIdentifier.SelectedIndex = cboIdentifier.Items.IndexOf("ID"); }
        else if (cboIdentifier.Items.Contains("Name")) { cboIdentifier.SelectedIndex = cboIdentifier.Items.IndexOf("Name"); }
      }
    }

    private string[] GetAttributeNames(XElement xElement)
    {
      List<string> slAttributes = new List<string>();
      slAttributes.AddRange(xElement.Attributes().Select(a => a.Name.ToString()));
      foreach (XElement xSub in xElement.Elements())
      {
        slAttributes.AddRange(GetAttributeNames(xSub).Where(i => !slAttributes.Contains(i)));
      }
      return slAttributes.ToArray();
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
      XDocument xCompare = XDocument.Load(txtFileToCompare.Text);

      XmlComparer xComparer = new XmlComparer(xBase, xCompare, cboIdentifier.Text);

      System.Xml.Xsl.XslCompiledTransform xTrans = new System.Xml.Xsl.XslCompiledTransform();
      xTrans.Load(".\\Resources\\Defaults.xslt");
      StringReader sr = new StringReader(xComparer.ResultDocument.ToString());
      XmlReader xReader = XmlReader.Create(sr);

      //Apply / transform the XML data
      System.IO.MemoryStream ms = new MemoryStream();
      xTrans.Transform(xReader, null, ms);

      // Reset the position
      ms.Position = 0;

      webResult.DocumentStream = ms;
      webResult.Refresh();
    }
  }
}
