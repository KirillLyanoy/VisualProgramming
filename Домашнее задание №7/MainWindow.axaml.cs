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
        }       
        private void AddUser(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            NewUserWindow newUserWindow = new();
            newUserWindow.ShowDialog(this);                    
        }
        private void DeleteUser(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            DataContextWithUsers dataContextWithUsers = new();
            User user = dataGrid.SelectedItem as User;
            dataContextWithUsers.UsersList.Remove(user);        
        }
    }
}
