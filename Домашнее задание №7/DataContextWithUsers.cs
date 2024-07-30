using dz7.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;

namespace dz7
{
    internal class DataContextWithUsers : INotifyPropertyChanged
    {
        public DataContextWithUsers() 
        {
            if (usersList == null)
            {
                GetUsers();
            }            
        }
        private async void GetUsers()
        {
            GetHttpUsersService users = new();
            UsersList = new ObservableCollection<User> ( await users.GetJSONUsers());
            UserListTracker userListTracker = new UserListTracker();
            userListTracker.FactoryMethod(usersList);
        }
        private static ObservableCollection<User>? usersList;
        public ObservableCollection<User>? UsersList
        {
            get { return usersList; }
            set { _ = SetField(ref usersList, value); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
