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
            switch (currentObject)
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
                    if (GetDirectories.GetPath() == "") GetDirectories.SetPath(currentObject);
                    else
                    {
                        if (Directory.Exists(GetDirectories.GetPath() + "\\" + currentObject)) 
                            GetDirectories.SetPath(GetDirectories.GetPath() + "\\" + currentObject);                        
                        else break;                       
                    }
                    MainListBox.ItemsSource = new ObservableCollection<TypeWithImage>(GetDirectories.GetCurrentDirectories().Concat((TypeWithImage[])(GetDirectories.GetCurrentFiles())));
                    break;
            }           
        }
    }
}