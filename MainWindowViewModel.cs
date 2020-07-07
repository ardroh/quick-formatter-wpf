using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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
            set {
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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}