﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;


namespace dz5
{
    internal class DataContextWithCollection : INotifyPropertyChanged
    {
        public DataContextWithCollection()
        {
            Collection = new ObservableCollection<TypeWithImage>(GetDirectories.GetCurrentDirectories().Concat((TypeWithImage[])(GetDirectories.GetCurrentFiles())));
        }
        public ObservableCollection<TypeWithImage> Collection
        {
            get => _collection;
            set => _ = SetField(ref _collection, value);
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        private ObservableCollection<TypeWithImage> _collection;
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