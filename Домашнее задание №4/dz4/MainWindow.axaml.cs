using Avalonia.Controls;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace dz4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();             
        }

        private void ListBox_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs RoutedEventArgs)
        {
            //определение источника, для того чтобы функция вызывалась при нажатии даже на пустом поле возле текста, а не только на сам текст//
            if (RoutedEventArgs.Source is TextBlock textBlock) ChangeListBox(textBlock.Text);
            if (RoutedEventArgs.Source is Avalonia.Controls.Presenters.ContentPresenter presenter)
            {           
                TypeWithImage getTypes = (TypeWithImage)presenter.DataContext;
                ChangeListBox(getTypes.FileName);                
            }
        }

        public void ChangeListBox<T>(T currentObject)
        {            
            string temp = Convert.ToString(currentObject);
            switch (temp)
            {
                case "..":                
                    string _getParentPath = Convert.ToString(Directory.GetParent(GetDirectories.GetPath()));
                    if (_getParentPath != "")
                    {
                        GetDirectories.SetPath(_getParentPath);
                        MainListBox.ItemsSource = new ObservableCollection<TypeWithImage>(GetDirectories.GetCurrentDirectories().Concat((TypeWithImage[])(GetDirectories.GetCurrentFiles())));
                    }
                    else MainListBox.ItemsSource = new ObservableCollection<TypeWithImage>(GetDirectories.GetLogicalDrives());                    
                    break;
                default:
                    if (GetDirectories.GetPath() == "") GetDirectories.SetPath(temp);
                    else
                    {
                        if (Directory.Exists(GetDirectories.GetPath() + "\\" + temp)) 
                            GetDirectories.SetPath(GetDirectories.GetPath() + "\\" + temp);                        
                        else break;                       
                    }
                    MainListBox.ItemsSource = new ObservableCollection<TypeWithImage>(GetDirectories.GetCurrentDirectories().Concat((TypeWithImage[])(GetDirectories.GetCurrentFiles())));
                    break;
            }           
        }
    }
}