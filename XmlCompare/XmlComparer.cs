using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XmlCompare
{
  class XmlComparer
  {
    private XDocument m_docBase = new XDocument();
    private XDocument m_docCompare = new XDocument();
    private XDocument m_docResult = new XDocument();
    private string m_attribIdentifier = "ID";

    public XmlComparer(XDocument xBaseDocument, XDocument xDocumentToCompare, string IdentifyingAttribute)
    {
      m_docBase = xBaseDocument;
      m_docCompare = xDocumentToCompare;
      m_attribIdentifier = IdentifyingAttribute;
      CompareDocuments();
    }
    public XmlComparer(string BaseDocument, string DocumentToCompare, string IdentifyingAttribute)
    {
      m_docBase = XDocument.Load(BaseDocument, LoadOptions.PreserveWhitespace);
      m_docCompare = XDocument.Load(DocumentToCompare, LoadOptions.PreserveWhitespace);
      m_attribIdentifier = IdentifyingAttribute;
      CompareDocuments();
    }
    public XmlComparer(XDocument xBaseDocument, XDocument xDocumentToCompare)
    {
      m_docBase = xBaseDocument;
      m_docCompare = xDocumentToCompare;
      CompareDocuments();
    }
    public XmlComparer(string BaseDocument, string DocumentToCompare)
    {
      m_docBase = XDocument.Load(BaseDocument, LoadOptions.PreserveWhitespace);
      m_docCompare = XDocument.Load(DocumentToCompare, LoadOptions.PreserveWhitespace);
      CompareDocuments();
    }

    public XDocument ResultDocument { get { return m_docResult; } }

    private void CompareDocuments()
    {
      m_docResult = new XDocument(new XProcessingInstruction("xml-stylesheet", "version=\"1.0\" xmlns:xsl=\"http://www.w3.org/1999/XSL/Transform\""), new XElement(m_docBase.Root.Name));
      CompareElements(m_docResult.Root, m_docBase.Root, m_docCompare.Root);
    }

    private void CompareElements(XElement xResultElement, XElement xBaseElement, XElement xElementToCompare)
    {
      foreach (XNode xNode in xBaseElement.Nodes())
      {
        switch (xNode.NodeType)
        {
          case System.Xml.XmlNodeType.Text:
            if (xElementToCompare != null)
            {
              XText xBaseText = (XText)xNode;
              CompareText(xResultElement, xBaseText, xElementToCompare);
            }
            break;
          case System.Xml.XmlNodeType.Element:
            XElement xBaseSubElement = (XElement)xNode;
            xResultElement.Add(new XElement(xBaseSubElement.Name));
            XElement xResultSubElement = (XElement)xResultElement.LastNode;
            XElement xCompareSub = GetSubElement(xBaseSubElement, xElementToCompare);
            CompareElements(xResultSubElement, xBaseSubElement, xCompareSub);
            break;
        }
      }
      CompareAttributes(xResultElement, xBaseElement, xElementToCompare);
    }

    private XElement GetSubElement(XElement xReference, XElement xElementToSearch)
    {
      XElement xResult = null;
      string sIdentifier = m_attribIdentifier;
      if (xElementToSearch != null)
      {
        if (xReference.Attribute(sIdentifier) == null)
        {
          sIdentifier = "ID";
          if (xReference.Attribute(sIdentifier) == null)
          {
            sIdentifier = "Name";
            if (xReference.Attribute(sIdentifier) == null)
            {
              if (xReference.Attributes().FirstOrDefault() != null)
              {
                sIdentifier = xReference.Attributes().FirstOrDefault().Name.ToString();
              }
              if (xResult == null && xElementToSearch != null)
              {
                xResult = xElementToSearch.Elements().ElementAt(xReference.ElementsBeforeSelf().Count());
              }
            }
          }
        }
      }
      if(xResult == null && xElementToSearch != null)
      {
        xResult = xElementToSearch.Elements()
                  .Where(e => e.Name.Equals(xReference.Name)
                  && e.Attribute(sIdentifier) != null
                  && e.Attribute(sIdentifier).Value.Equals(xReference.Attribute(sIdentifier).Value)).FirstOrDefault();
      }
      return xResult;
    }

    private void CompareText(XElement xResultElement, XText xBaseText, XElement xElementToCompare)
    {
      if(xElementToCompare == null)
      {
        xResultElement.Add(new XAttribute("MissingText", xBaseText.Value));
      }
      else if (!string.IsNullOrWhiteSpace(xBaseText.Value.Trim()))
      {
        var xTexts = xElementToCompare.Nodes().Where(n => n.NodeType == System.Xml.XmlNodeType.Text);
        foreach (XText xtCompare in xTexts)
        {
          if (xtCompare.Value.Equals(xBaseText.Value))
          {
            return;
          }
        }
        xResultElement.Add(new XAttribute("MissingText", xBaseText.Value));
      }

    }

    private void CompareAttributes(XElement xResultElement, XElement xBaseElement, XElement xElementToCompare)
    {
      XAttribute xaResultMissing = xResultElement.Attribute("MissingAttribute");
      XAttribute xaResultDiffers = xResultElement.Attribute("DifferentAttribute");
      XAttribute xaResultAdditional = xResultElement.Attribute("AdditionalAttribute");
      if (xaResultMissing == null) { xaResultMissing = new XAttribute("MissingAttribute", string.Empty); }
      if (xaResultDiffers == null) { xaResultDiffers = new XAttribute("DifferentAttribute", string.Empty); }
      if (xaResultAdditional == null) { xaResultAdditional = new XAttribute("AdditionalAttribute", string.Empty); }
      foreach (XAttribute xBaseAttribute in xBaseElement.Attributes())
      {
        xResultElement.Add(new XAttribute(xBaseAttribute.Name, xBaseAttribute.Value));
        if (xElementToCompare == null)
        {
          xaResultMissing.Value += string.Format("[{0}={1}]", xBaseAttribute.Name, xBaseAttribute.Value);
        }
        else
        {
          XAttribute xaCurrent = xElementToCompare.Attribute(xBaseAttribute.Name);

          if (xaCurrent == null)
          {
            xaResultMissing.Value += string.Format("[{0}={1}]", xBaseAttribute.Name, xBaseAttribute.Value);
          }
          else
          {
            XAttribute xaCompare = new XAttribute(xBaseAttribute.Name, xaCurrent.Value);
            if (!xBaseAttribute.Value.Equals(xaCompare.Value))
            {
              xaResultDiffers.Value += string.Format("[{0}={1}]", xBaseAttribute.Name, xBaseAttribute.Value);
            }
          }
        }
      }

      if (xElementToCompare != null)
      {
        foreach (XAttribute xCompareAttribute in xElementToCompare.Attributes())
        {
          if (xBaseElement.Attribute(xCompareAttribute.Name) == null)
          {
            xaResultAdditional.Value += string.Format("[{0}={1}]", xCompareAttribute.Name, xCompareAttribute.Value);
            xResultElement.Add(new XAttribute(xCompareAttribute.Name, xCompareAttribute.Value));
          }
        }
      }
    }
  }
}
