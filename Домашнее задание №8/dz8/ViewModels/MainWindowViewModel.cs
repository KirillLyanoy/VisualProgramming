using dz8.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace dz8.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        // public DataGridViewModel DataGridViewModel { get; } = new DataGridViewModel();


        public MainWindowViewModel()
        {
            UsersList = new ObservableCollection<User>()
            {
                new User()
                {
                    Id = 1,
                    Email="2312",
                     Phone="asds",
                      Website="asdsd",
                       Username="sdasd",
                        Name="sads",
                         Company = new Company()
                         {
                              Bs = "231",
                              Name="ssa",
                              CatchPhrase="sdasd",
                         },

                     Address = new Address()
                     {
                          City="asdas",
                            Street="sds",
                             Suite="sdasd",
                              Zipcode="sdas",
                               Geo = new Geo()
                               {
                                    Lat = "232",
                                    Lng = "22",
                               }
                     }

                },
                new User()
                {
                    Id = 2,
                    Email="2312",
                     Phone="asds",
                      Website="asdsd",
                       Username="sdasd",
                        Name="sads",
                         Company = new Company()
                         {
                              Bs = "231",
                              Name="ssa",
                              CatchPhrase="sdasd",
                         },

                     Address = new Address()
                     {
                          City="asdas",
                            Street="sds",
                             Suite="sdasd",
                              Zipcode="sdas",
                               Geo = new Geo()
                               {
                                    Lat = "232",
                                    Lng = "22",
                               }
                     }

                }
            };
            // GetUsers();
        }
        private ObservableCollection<User>? _usersList;
        public ObservableCollection<User>? UsersList
        {
            get => _usersList; 
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
