using System;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace quick_formatter_wpf.Formatters
{
    public class XmlTextFormatter : ITextFormatter
    {
        public string Format(string inputText)
        {
            var stringBuilder = new StringBuilder();

            XElement element;
            try
            {
                element = XElement.Parse(inputText);
            }
            catch (XmlException e)
            {
                throw new TextFormatterException(e);
            }

            var settings = new XmlWriterSettings {OmitXmlDeclaration = true, Indent = true, NewLineOnAttributes = true};

            using (var xmlWriter = XmlWriter.Create(stringBuilder, settings))
            {
                element.Save(xmlWriter);
            }

            return stringBuilder.ToString();
        }
    }
}