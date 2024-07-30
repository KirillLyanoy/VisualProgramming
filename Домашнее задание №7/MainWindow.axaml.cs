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
        private void DataGrid_RowEditEnded(object? sender, Avalonia.Controls.DataGridRowEditEndedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;     
            DataContextWithUsers dataContextWithUsers = new();
            dataContextWithUsers.UsersList[dataGrid.SelectedIndex] = dataContextWithUsers.UsersList[dataGrid.SelectedIndex];
        }
    }
}
