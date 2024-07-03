using System;
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
            if (GetDirectories.GetPath() != "" && Collection == null) Collection = new ObservableCollection<TypeWithImage>(GetDirectories.GetCurrentDirectories().Concat((TypeWithImage[])(GetDirectories.GetCurrentFiles())));
            if (CollectionBelowAbove == null) DirectoriesBelowAbove();              
        }
        public ObservableCollection<TypeWithImage> Collection
        {
            get => _collection;
            set => _ = SetField(ref _collection, value);
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        static private ObservableCollection<TypeWithImage> _collection;
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
        static private bool gotLock = true;
        public ObservableCollection<TypeWithImage> GetBelowAboveDirectories(string name)
        {
            if (gotLock)
            {
                gotLock = false;
                int temp = 0;
                foreach (var directory in Collection)
                {
                    if (directory.FileName == name) break;
                    else temp++;
                }
                Collection = CollectionBelowAbove[temp];
                gotLock = true;
                return Collection;
            }
            else
            {
                GetBelowAboveDirectories(name);
                return Collection;
            }
        }

        public void DirectoriesBelowAbove()
        {
            if (GetDirectories.GetPath() != "")
            {
                CollectionBelowAbove = new ObservableCollection<TypeWithImage>[GetDirectories.GetCurrentDirectories().Length + 1];
                int i = 1;
                string _getParentPath = Convert.ToString(Directory.GetParent(GetDirectories.GetPath()));

                if (_getParentPath != "") CollectionBelowAbove[0] = new ObservableCollection<TypeWithImage>(GetDirectories.GetCurrentDirectories(_getParentPath).Concat((TypeWithImage[])(GetDirectories.GetCurrentFiles(_getParentPath))));
                else CollectionBelowAbove[0] = new ObservableCollection<TypeWithImage>(GetDirectories.GetLogicalDrives());

                foreach (var directory in Collection)
                {
                    if (Directory.Exists(directory.FilePath) && directory.FilePath != "..")
                    {
                        CollectionBelowAbove[i] = new ObservableCollection<TypeWithImage>(GetDirectories.GetCurrentDirectories(GetDirectories.GetPath() + "\\" + directory.FileName).Concat((TypeWithImage[])(GetDirectories.GetCurrentFiles(GetDirectories.GetPath() + "\\" + directory.FileName))));
                        i++;
                    }
                }
            }
            else
            {
                ObservableCollection<TypeWithImage> temp = new(GetDirectories.GetLogicalDrives());
                CollectionBelowAbove = new ObservableCollection<TypeWithImage>[temp.Count];
                int i = 0;                
                foreach (var directory in temp)
                {
                    CollectionBelowAbove[i] = new ObservableCollection<TypeWithImage>(GetDirectories.GetCurrentDirectories(directory.FileName).Concat((TypeWithImage[])GetDirectories.GetCurrentFiles(directory.FileName)));
                    i++;    
                }
            }
        }
    }
}