using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using quick_formatter_wpf.Formatters;

namespace quick_formatter_wpf.Commands
{
    public class FormatCommand : ICommand
    {
        private readonly object _receiver;
        private readonly ITextFormatterFactory _textFormatterFactory = new TextFormatterFactory();

        public FormatCommand(object receiver)
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
            if (!(_receiver is MainWindowViewModel mainWindowViewModel)) return;

            var formatter = _textFormatterFactory.Create(mainWindowViewModel.SelectedFormatter);
            try
            {
                mainWindowViewModel.OutputText = formatter?.Format(parameter as string);
            }
            catch (TextFormatterException)
            {
                MessageBox.Show("Incorrect format of the input text.", "Incorrect format", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
