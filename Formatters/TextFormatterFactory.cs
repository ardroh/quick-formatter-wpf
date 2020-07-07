namespace quick_formatter_wpf.Formatters
{
    class TextFormatterFactory : ITextFormatterFactory
    {
        public ITextFormatter Create(string formatterType)
        {
            if (formatterType == "JSON")
            {
                return new JsonTextFormatter();
            }

            if (formatterType == "XML")
            {
                return new XmlTextFormatter();
            }

            return null;
        }
    }
}