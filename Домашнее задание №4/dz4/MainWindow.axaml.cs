using Avalonia.Controls;
using Avalonia.Media.Imaging;
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
                        string _getParentPath = Convert.ToString(Directory.GetParent(GetDirectory.GetPath()));
                        if (_getParentPath != "") GetDirectory.SetPath(_getParentPath);
                        else GetDirectory.SetLogicalDrives();
                        break;
                    default:
                        if (Directory.Exists(GetDirectory.GetPath() + "\\" + textBlock.Text))
                        {
                            GetDirectory.SetPath(Convert.ToString((GetDirectory.GetPath() + "\\" + textBlock.Text)));
                        }
                        break;
                }
                GetDirectory.SetNewDirectory();
                MainListBox.ItemsSource = new ObservableCollection<string>(new string[] { ".." }.Concat(GetDirectory.GetDirectories().Concat(GetDirectory.GetFiles())));    
            }           
        }
    }
}