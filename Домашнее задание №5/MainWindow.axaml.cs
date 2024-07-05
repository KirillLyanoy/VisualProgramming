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
        //вспомогательная переменная, блокирующая запуск ожидания вспомогательного потока//
        static private bool _joinThreadLock = true; 

        private void ListBoxDoubleTapped(object? sender, Avalonia.Input.TappedEventArgs RoutedEventArgs)
        {
            //ожидание дозагрузки поддиректорий// 
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
            //установка нового пути в зависимости от выбранного пользователем элемента//
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
            //замена коллекции в Лист Боксе//
            MainListBox.ItemsSource = dataContextWithCollection.GetBelowAboveDirectories(currentObject);
            //вызов дополнительного потока, загружающего поддиректории//
            t.Start(); 
        }

        private void ImageView(object? sender, Avalonia.Input.TappedEventArgs RoutedEventArgs)
        {
            //определение источника, для того чтобы функция вызывалась при нажатии на текст, на картинку и на пустое поле//
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