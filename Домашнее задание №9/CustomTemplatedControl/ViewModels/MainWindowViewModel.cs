using ReactiveUI;
using System.Reactive;

namespace dz9.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            TextArea = "Hello";
        }

        private string textArea;
        public string TextArea
        {
            get => textArea;
            set => this.RaiseAndSetIfChanged(ref textArea, value);
        }
    }
}
