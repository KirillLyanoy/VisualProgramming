using Avalonia.Controls;
using dz7.model;
using System.Collections.Generic;
using System.Data;

namespace dz7
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContextWithUsers dataContextWithUsers = new DataContextWithUsers(); 
           


            UserListTracker factory = new UserListTracker();
            factory.Subscribe(dataContextWithUsers.UsersList);
        }

        private void AddUser(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            DataContextWithUsers dataContextWithUsers = new();
            dataContextWithUsers.UsersList.Add(new User()
            {
                Id = 0,
                Name = "",
                Username = "",
                Email = "",
                Phone = "",
                Website = "",
                Address = new Address()
                {
                    Street = "",
                    Suite = "",
                    City = "",
                    Geo = new Geo()
                    {
                        Lat = "",
                        Lng = ""
                    }
                },
                Company = new Company()
                {
                    Name = "",
                    CatchPhrase = "",
                    Bs = ""
                }
            } );
        }
        private void DeleteUser(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            DataContextWithUsers dataContextWithUsers = new();
            User user = dataGrid.SelectedItem as User;
            dataContextWithUsers.UsersList.Remove(user);        
        }
    }
}
