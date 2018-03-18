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

        public XmlComparer(XDocument xBaseDocument, XDocument xDocumentToCompare)
        {
            m_docBase = xBaseDocument;
            m_docCompare = xDocumentToCompare;
        }
        public XmlComparer(string BaseDocument, string DocumentToCompare)
        {
            m_docBase = XDocument.Load(BaseDocument, LoadOptions.PreserveWhitespace);
            m_docCompare = XDocument.Load(DocumentToCompare, LoadOptions.PreserveWhitespace);
        }

        public XDocument ResultDocument { get { return m_docResult; } }

        private void CompareDocuments()
        {
            m_docResult = new XDocument();

            m_docResult.Add(new XElement(m_docBase.Root.Name));
            CompareElements(m_docResult.Root, m_docBase.Root, m_docCompare.Root);
        }

        private void CompareElements(XElement xResultElement, XElement xBaseElment, XElement xElementToCompare)
        {
            foreach(XNode xNode in xBaseElment.Nodes())
            {
                switch(xNode.NodeType)
                {
                    case System.Xml.XmlNodeType.Text:
                        XText xBaseText = (XText)xNode;
                        CompareText(xResultElement, xBaseText, xElementToCompare);
                        break;
                    case System.Xml.XmlNodeType.Element:
                        XElement xBaseSubElement = (XElement)xNode;
                        xResultElement.Add(new XElement(xBaseSubElement.Name));
                        XElement xResultSubElement = (XElement)xResultElement.LastNode;
                        CompareElements(xResultSubElement, xBaseSubElement, xElementToCompare);
                        break;
                }
            }
            foreach(XAttribute xBaseAttribute in xBaseElment.Attributes())
            {
                CompareAttributes(xResultElement, xBaseAttribute, xElementToCompare);
            }
        }

        private void CompareText(XElement xResultElement, XText xBaseText, XElement xElementToCompare)
        {
            if(!string.IsNullOrWhiteSpace(xBaseText.Value.Trim()))
            {
                var xTexts = xElementToCompare.Nodes().Where(n => n.NodeType == System.Xml.XmlNodeType.Text);
                foreach (XText xtCompare in xTexts)
                {
                    if(xtCompare.Value.Equals(xBaseText.Value))
                    {
                        return;
                    }
                }
                xResultElement.Add(new XAttribute("MissingText", xBaseText.Value));
            }

        }

        private void CompareAttributes(XElement xResultElement, XAttribute xBaseAttribute, XElement xElementToCompare)
        {
            XAttribute xaResultMissing = xResultElement.Attribute("MissingAttribute");
            XAttribute xaResultDiffers = xResultElement.Attribute("DifferentAttribute");
            XAttribute xaCompare = new XAttribute(xBaseAttribute.Name, xResultElement.Attribute(xBaseAttribute.Name).Value);

            if (xaCompare == null)
            {
                xaResultMissing.Value += string.Format("[{0}={1}]", xBaseAttribute.Name, xBaseAttribute.Value);
            }
        }
    }
}
