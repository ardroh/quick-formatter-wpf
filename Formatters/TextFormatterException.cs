using System;

namespace quick_formatter_wpf.Formatters
{
    internal class TextFormatterException : Exception
    {
        public TextFormatterException(Exception innerException)
            : base("Failed to format. Check inner exception for details.", innerException)
        {
        }
    }
}