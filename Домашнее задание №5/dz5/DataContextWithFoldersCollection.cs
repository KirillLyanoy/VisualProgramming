﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Runtime.CompilerServices;

namespace dz5
{
    internal class DataContextWithCollection : INotifyPropertyChanged
    {
        public DataContextWithCollection()
        {
            if (GetDirectories.GetPath() != "") Collection = new ObservableCollection<TypeWithImage>(GetDirectories.GetCurrentDirectories().Concat((TypeWithImage[])(GetDirectories.GetCurrentFiles())));
            else Collection = new ObservableCollection<TypeWithImage>(GetDirectories.GetLogicalDrives());
            //       Thread t = new Thread(DirectoriesBelowAbove);   
            //       t.Start();
            DirectoriesBelowAbove();
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

        static public ObservableCollection<TypeWithImage>[] CollectionBelowAbove;

        public ObservableCollection<TypeWithImage> GetBelowAboveDirectories(string name)
        {
            int temp = 0;
            foreach (var directory in Collection)
            {
                if (directory.FileName == name) break;
                else temp++;
            }
            Collection = CollectionBelowAbove[temp];
            return Collection;
        }
        public void DirectoriesBelowAbove()
        {
            if (GetDirectories.GetPath() != "") CollectionBelowAbove = new ObservableCollection<TypeWithImage>[GetDirectories.GetCurrentDirectories().Length + 1];
            else CollectionBelowAbove = new ObservableCollection<TypeWithImage>[GetDirectories.GetLogicalDrives().Count + 1];
            int i = 1;
            string _getParentPath;
            if (GetDirectories.GetPath() != "") _getParentPath = Convert.ToString(Directory.GetParent(GetDirectories.GetPath()));
            else _getParentPath = "";

            if (_getParentPath != "") CollectionBelowAbove[0] = new ObservableCollection<TypeWithImage>(GetDirectories.GetCurrentDirectories(_getParentPath).Concat((TypeWithImage[])(GetDirectories.GetCurrentFiles(_getParentPath))));
            else CollectionBelowAbove[0] = new ObservableCollection<TypeWithImage>(GetDirectories.GetLogicalDrives());

            foreach (var directory in Collection)
            {
                if (Directory.Exists(directory.FilePath) && directory.FilePath != "..")
                {
                    try
                    {
                        CollectionBelowAbove[i] = new ObservableCollection<TypeWithImage>(GetDirectories.GetCurrentDirectories(GetDirectories.GetPath() + "\\" + directory.FileName).Concat((TypeWithImage[])(GetDirectories.GetCurrentFiles(GetDirectories.GetPath() + "\\" + directory.FileName))));
                    }
                    catch (System.ArgumentNullException)
                    {
                        CollectionBelowAbove[i] = null;
                    }
                    i++;
                }
            }        
        }
    }
}