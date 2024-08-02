using dz8.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace dz8.ViewModels
{
    public class DataGridViewModel : INotifyPropertyChanged
    {
        public DataGridViewModel()
        {
            GetUsers();
        }
        private ObservableCollection<User>? _usersList;
        public ObservableCollection<User>? UsersList
        {
            get { return _usersList; }
            set 
            {
                _usersList = value;
                OnPropertyChanged(nameof(UsersList));
            }
        }
        private async void GetUsers()
        {
            GetHttpUsersService users = new();
            UsersList = new ObservableCollection<User>(await users.GetJSONUsers());
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
