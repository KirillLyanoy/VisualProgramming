
using dz8.ViewModels.Pages;
using ReactiveUI;
using System.Collections.ObjectModel;

namespace dz8.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private object content;
        public object Content
        {
            get => content;
            set
            {
                this.RaiseAndSetIfChanged(ref content, value);
            }
        }
        public MainWindowViewModel()
        {
            vmbaseCollection = [new DataGridViewModel(), new TreeViewModel()];
            Content = vmbaseCollection[0];
        }
        private ObservableCollection<BasePageViewModel> vmbaseCollection;
        public ObservableCollection<BasePageViewModel> VmbaseCollection
        {
            get => vmbaseCollection;
            set
            {
                this.RaiseAndSetIfChanged(ref vmbaseCollection, value);
            }
        }
    }
}
