using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using quick_formatter_wpf.Commands;

namespace quick_formatter_wpf
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public List<string> AvailableFormatters { get; set; }
        public ICommand FormatCommand { get; set; }
        public ICommand CopyToClipCommand { get; set; }

        private string _inputText;

        public string InputText
        {
            get => _inputText;
            set
            {
                _inputText = value;
                OnPropertyChanged();
            }
        }

        private string _outputText;

        public string OutputText
        {
            get => _outputText;
            set
            {
                _outputText = value;
                OnPropertyChanged();
            }
        }

        public string SelectedFormatter { get; set; }

        private string _statusBarText;

        public string StatusBarText
        {
            get => _statusBarText;
            set
            {
                _statusBarText = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            AvailableFormatters = new List<string>()
            {
                "JSON",
                "XML"
            };
            FormatCommand = new FormatCommand(this);
            CopyToClipCommand = new CopyToClipCommand(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            if (name == "OutputText" || name == "InputText")
            {
                UpdateStatusBarText();
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void UpdateStatusBarText()
        {
            var statusBarTextBuilder = new StringBuilder();
            if (InputText != null)
            {
                statusBarTextBuilder.Append($"Input lines: {CountLines(InputText)}");
            }

            if (InputText != null && OutputText != null)
            {
                statusBarTextBuilder.Append(" | ");
            }

            if (OutputText != null)
            {
                statusBarTextBuilder.Append($"Output lines: {CountLines(OutputText)}");
            }

            StatusBarText = statusBarTextBuilder.ToString();
        }

        private int CountLines(string text)
        {
            return Regex.Matches(text, "\n|\n\r").Count;
        }
    }
}