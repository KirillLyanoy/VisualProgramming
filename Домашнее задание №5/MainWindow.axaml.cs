using Avalonia.Controls;
using Avalonia.Media.Imaging;
using System;
using System.IO;
using System.Threading;

namespace dz5
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();           
            FileSystemWatch fileSystemWatch = new FileSystemWatch();
        }

        static private Thread? t;
        //��������������� ����������, ����������� ������ �������� ���������������� ������//
        static private bool _joinThreadLock = true; 

        private void ListBoxDoubleTapped(object? sender, Avalonia.Input.TappedEventArgs RoutedEventArgs)
        {
            //�������� ���������� �������������// 
            if (!_joinThreadLock) t.Join();
            else _joinThreadLock = false;
            
            string currentFile = CheckType(RoutedEventArgs);
            if (currentFile != null) ChangeListBox(currentFile);
            else _joinThreadLock = true;
        }
        
        public void ChangeListBox(string currentObject)
        {
            DataContextWithCollection dataContextWithCollection = new();
            t = new(dataContextWithCollection.DirectoriesBelowAbove);
            //��������� ������ ���� � ����������� �� ���������� ������������� ��������//
            switch (currentObject)
            {                
                case "..":                    
                    string _getParentPath = Convert.ToString(Directory.GetParent(GetDirectories.GetPath()));
                    if (_getParentPath != "") GetDirectories.SetPath(_getParentPath);                        
                    else GetDirectories.SetPath("");   
                    break;
                default:                    
                    if (GetDirectories.GetPath() == "") GetDirectories.SetPath(currentObject);
                    else
                    {
                        if (Directory.Exists(GetDirectories.GetPath() + "\\" + currentObject))
                        {
                            GetDirectories.SetPath(GetDirectories.GetPath() + "\\" + currentObject);
                        }
                        else
                        {
                            _joinThreadLock = true;
                            return;
                        }
                    }                    
                    break;
            }
            FileSystemWatch.CreateNewFileSystemWatcher(GetDirectories.GetPath());
            //������ ��������� � ���� �����//
            MainListBox.ItemsSource = dataContextWithCollection.GetBelowAboveDirectories(currentObject);
            //����� ��������������� ������, ������������ �������������//
            t.Start(); 
        }

        private void ImageView(object? sender, Avalonia.Input.TappedEventArgs RoutedEventArgs)
        {
            //����������� ���������, ��� ���� ����� ������� ���������� ��� ������� �� �����, �� �������� � �� ������ ����//
            string currentFile = CheckType(RoutedEventArgs);
            if (currentFile != null) ChangeImage(currentFile);
        }
        private void ChangeImage(string fileName)
        {
            if (File.Exists(GetDirectories.GetPath() + "\\" + fileName))
            {
                Bitmap currentImage = new(GetDirectories.GetPath() + "\\" + fileName);
                ImageViewer.Source = currentImage;
            }
        }
        private string CheckType(Avalonia.Input.TappedEventArgs RoutedEventArgs)
        {
            if (RoutedEventArgs.Source is TextBlock textBlock) return (textBlock.Text);
            if (RoutedEventArgs.Source is Avalonia.Controls.Presenters.ContentPresenter presenter)
            {
                if (presenter.DataContext is TypeWithImage getTypes) return (getTypes.Name);
                else return null;
            }
            if (RoutedEventArgs.Source is Image image)
            {
                TypeWithImage getTypes = image.DataContext as TypeWithImage;
                return getTypes.Name;
            }
            return null;
        }
    }
}