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
            
        }
        private void DeleteUser(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            DataContextWithUsers dataContextWithUsers = new();
            foreach (var item in dataContextWithUsers.UsersList)
            {
                if (item == dataGrid.SelectedItem)
                {
                    dataContextWithUsers.UsersList.Remove(item);
                    return;
                }
            }         
        }
        private void EditUser(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
        }
    }
}
