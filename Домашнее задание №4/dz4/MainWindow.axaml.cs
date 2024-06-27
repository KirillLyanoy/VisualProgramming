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
                        string _getParentPath = Convert.ToString(Directory.GetParent(Path.GetPath()));
                        if (_getParentPath != "") Path.SetPath(_getParentPath);
                        else Path.SetLogicalDrives();
                        break;
                    default:
                        if (Directory.Exists(textBlock.Text))
                        {
                            Path.SetPath(Convert.ToString((textBlock.Text)));
                        }
                        break;
                }
                DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetPath());
                MainListBox.ItemsSource = new ObservableCollection<FileSystemInfo>(Path.GetTypeDirectories().Concat((FileSystemInfo[])Path.GetTypeFiles()));
            }
        }   
    }
}