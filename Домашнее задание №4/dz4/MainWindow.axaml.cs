using Avalonia.Controls;
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
            if (RoutedEventArgs.Source is TextBlock textBlock)
            {
                switch (textBlock.Text)
                {
                    case "..":
                        string _getParentPath = Convert.ToString(Directory.GetParent(DirectoriesAndFiles.GetPath()));
                        if (_getParentPath != "")
                        {
                            DirectoriesAndFiles.SetPath(_getParentPath);
                            DirectoryInfo directoryInfo = new DirectoryInfo(DirectoriesAndFiles.GetPath());
                            MainListBox.ItemsSource = new ObservableCollection<FileSystemInfo>(DirectoriesAndFiles.GetDirectoryUp().Concat(DirectoriesAndFiles.GetTypeDirectories().Concat((FileSystemInfo[])DirectoriesAndFiles.GetTypeFiles())));
                        }
                        else
                        {
                            MainListBox.ItemsSource = new ObservableCollection<FileSystemInfo>(DirectoriesAndFiles.GetLogicalDrives());
                        }
                        break;
                    default:
                        if (Directory.Exists(textBlock.Text))
                        {
                            DirectoriesAndFiles.SetPath(Convert.ToString((textBlock.Text)));
                            DirectoryInfo directoryInfo = new DirectoryInfo(DirectoriesAndFiles.GetPath());
                            MainListBox.ItemsSource = new ObservableCollection<FileSystemInfo>(DirectoriesAndFiles.GetDirectoryUp().Concat(DirectoriesAndFiles.GetTypeDirectories().Concat((FileSystemInfo[])DirectoriesAndFiles.GetTypeFiles())));
                        }
                        break;
                }
            }           
        }   
    }
}