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
            if (RoutedEventArgs.Source is TextBlock textBlock) ChangeListBox(textBlock.Text);
            if (RoutedEventArgs.Source is Avalonia.Controls.Presenters.ContentPresenter presenter) ChangeListBox(presenter.DataContext); 
            
        }

        public void ChangeListBox<T>(T currentObject)
        {
            
            string temp = Convert.ToString(currentObject);
            switch (temp)
            {
                case "..":                
                    string _getParentPath = Convert.ToString(Directory.GetParent(DirectoriesAndFiles.GetPath()));
                    if (_getParentPath != "")
                    {
                        DirectoriesAndFiles.SetPath(_getParentPath);
                        MainListBox.ItemsSource = new ObservableCollection<GetTypes>(DirectoriesAndFiles.GetTypeDirectories().Concat((GetTypes[])(DirectoriesAndFiles.GetTypeFiles())));
                    }
                    else
                    {                        
                        MainListBox.ItemsSource = new ObservableCollection<GetTypes>(DirectoriesAndFiles.GetLogicalDrives());
                    }
                    break;
                default:
                    if (DirectoriesAndFiles.GetPath() == "") DirectoriesAndFiles.SetPath(temp);
                    else DirectoriesAndFiles.SetPath(Directory.GetCurrentDirectory() + "\\" + temp);
                    MainListBox.ItemsSource = new ObservableCollection<GetTypes>(DirectoriesAndFiles.GetTypeDirectories().Concat((GetTypes[])(DirectoriesAndFiles.GetTypeFiles())));                    
                    break;
            }           
        }
    }
}