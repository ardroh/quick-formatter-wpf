using System;
using Newtonsoft.Json;

namespace quick_formatter_wpf.Formatters
{
    internal class JsonTextFormatter : ITextFormatter
    {
        public string Format(string inputText)
        {
            try
            {
                dynamic parsedJson = JsonConvert.DeserializeObject(inputText);
                return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
            }
            catch (Exception e)
            {
                throw new TextFormatterException(e);
            }
        }
    }
}