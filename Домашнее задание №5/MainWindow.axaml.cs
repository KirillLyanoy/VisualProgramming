using Avalonia.Controls;
using Avalonia.Interactivity;
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
        }

        static private Thread t;
        //вспомогательная переменная, блокирующая запуск ожидания вспомогательного потока//
        static private bool _joinThreadLock = true; 

        private void ListBoxDoubleTapped(object? sender, Avalonia.Input.TappedEventArgs RoutedEventArgs)
        {
            if (!_joinThreadLock) 
            {
                //ожидание дозагрузки поддиректорий// 
                t.Join();     
            }
            else
            {
                _joinThreadLock = false;
            }
                //определение источника, для того чтобы функция вызывалась при нажатии на текст, на картинку и на пустое поле//
            if (RoutedEventArgs.Source is TextBlock textBlock) ChangeListBox(textBlock.Text);
            if (RoutedEventArgs.Source is Avalonia.Controls.Presenters.ContentPresenter presenter)
            {
                TypeWithImage getTypes = presenter.DataContext as TypeWithImage;
                ChangeListBox(getTypes.FileName);
            }
            if (RoutedEventArgs.Source is Image image)
            {
                TypeWithImage getTypes = image.DataContext as TypeWithImage;
                ChangeListBox(getTypes.FileName);
            }           
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
            //замена коллекции в Лист Боксе//
            MainListBox.ItemsSource = dataContextWithCollection.GetBelowAboveDirectories(currentObject);
            //вызов дополнительного потока, загружающего поддиректории//
            t.Start(); 
        }

        private void ImageView(object? sender, Avalonia.Input.TappedEventArgs RoutedEventArgs)
        {
            //определение источника, для того чтобы функция вызывалась при нажатии на текст, на картинку и на пустое поле//
            if (RoutedEventArgs.Source is TextBlock textBlock) ChangeImage(textBlock.Text);
            if (RoutedEventArgs.Source is Avalonia.Controls.Presenters.ContentPresenter presenter)
            {
                TypeWithImage getTypes = presenter.DataContext as TypeWithImage;
                ChangeImage(getTypes.FileName);
            }
            if (RoutedEventArgs.Source is Image image)
            {
                TypeWithImage getTypes = image.DataContext as TypeWithImage;
                ChangeImage(getTypes.FileName);
            }
        }
        private void ChangeImage(string fileName)
        {
            if (File.Exists(GetDirectories.GetPath() + "\\" + fileName))
            {
                Bitmap currentImage = new Bitmap(GetDirectories.GetPath() + "\\" + fileName);
                ImageViewer.Source = currentImage;
            }
        }
    }
}