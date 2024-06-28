using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Media.Imaging;
using Microsoft.VisualBasic;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


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
                    string _getParentPath = Convert.ToString(Directory.GetParent(GetCurrentDirectories.GetPath()));
                    if (_getParentPath != "")
                    {
                        GetCurrentDirectories.SetPath(_getParentPath);
                        MainListBox.ItemsSource = new ObservableCollection<TypeWithImage>(GetCurrentDirectories.GetTypeDirectories().Concat((TypeWithImage[])(GetCurrentDirectories.GetTypeFiles())));
                    }
                    else
                    {                        
                        MainListBox.ItemsSource = new ObservableCollection<TypeWithImage>(GetCurrentDirectories.GetLogicalDrives());
                    }
                    break;
                default:
                    if (GetCurrentDirectories.GetPath() == "") GetCurrentDirectories.SetPath(temp);
                    else
                    {
                        if (Directory.Exists(GetCurrentDirectories.GetPath() + "\\" + temp))
                        {
                            GetCurrentDirectories.SetPath(GetCurrentDirectories.GetPath() + "\\" + temp);
                        }
                        else 
                        { 
                            break; 
                        }
                    }
                    MainListBox.ItemsSource = new ObservableCollection<TypeWithImage>(GetCurrentDirectories.GetTypeDirectories().Concat((TypeWithImage[])(GetCurrentDirectories.GetTypeFiles())));
                    break;
            }           
        }
    }
}