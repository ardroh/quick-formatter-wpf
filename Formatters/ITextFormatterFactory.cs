using System;
using System.Collections.Generic;
using System.Text;

namespace quick_formatter_wpf.Formatters
{
    public interface ITextFormatterFactory
    {
        ITextFormatter Create(string formatterType);
    }
}