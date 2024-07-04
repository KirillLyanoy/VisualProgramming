using Avalonia.Controls;
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
        //��������������� ����������, ������������ �������� ������ ��� ��������� ������ ���������//
        static private bool _firstRunning = true; 

        private void ListBox_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs RoutedEventArgs)
        {
            if (!_firstRunning) 
            {
                //�������� ���������� �������������// 
                t.Join();     
            }
            else
            {
                _firstRunning = false;
            }
                //����������� ���������, ��� ���� ����� ������� ���������� ��� ������� �� �����, �� �������� � �� ������ ����//
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
                        else return;
                    }                    
                    break;
            }
            //������ ��������� � ���� �����//
            MainListBox.ItemsSource = dataContextWithCollection.GetBelowAboveDirectories(currentObject);
            //����� ��������������� ������, ������������ �������������//
            t.Start(); 
        }
    }
}