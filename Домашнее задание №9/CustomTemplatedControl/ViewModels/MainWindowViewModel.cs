using ReactiveUI;

namespace dz9.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private bool fullSizeIndex = false;
        public bool FullSizeIndex 
        {
            get => fullSizeIndex;
            set => this.RaiseAndSetIfChanged(ref fullSizeIndex, value);
        }
        public void VolumeClick()
        {
            if (!FullSizeIndex) FullSizeIndex = true;
            else FullSizeIndex = false;
        }
    }
}
