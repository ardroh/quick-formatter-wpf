using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace quick_formatter_wpf.Commands
{
    class CopyToClipCommand : ICommand
    {
        private readonly object _receiver;

        public CopyToClipCommand(object receiver)
        {
            _receiver = receiver;
            if (_receiver is INotifyPropertyChanged propertyChanged)
            {
                propertyChanged.PropertyChanged += (sender, args) =>
                {
                    CanExecuteChanged?.Invoke(this, args);
                };
            }
        }

        public bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(parameter as string);
        }

        public void Execute(object parameter)
        {
            if (!(parameter is string text))
            {
                return;
            }
            Clipboard.SetText(text);
        }

        public event EventHandler CanExecuteChanged;
    }
}
