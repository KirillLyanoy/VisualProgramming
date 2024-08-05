using System.ComponentModel;

namespace dz8.ViewModels.Pages
{
    public class DataGridViewModel : BasePageViewModel, INotifyPropertyChanged
    {
        public DataGridViewModel()
        {
            GetUsers();
        }
        public override string GetName()
        {
            return "Data Grid";
        }
    }
}
