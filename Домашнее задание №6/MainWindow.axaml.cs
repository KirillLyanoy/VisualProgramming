using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using System;
using System.Diagnostics;

namespace dz6
{
    public partial class MainWindow : Window
    {        
        public MainWindow()
        {      
            InitializeComponent();
        }
        private void OpenInfo(object? sender, Avalonia.Input.TappedEventArgs RoutedEventArgs)
        {
            if (RoutedEventArgs.Source is TextBlock textBlock) ViewInfo(textBlock.Text);
            if (RoutedEventArgs.Source is Avalonia.Controls.Presenters.ContentPresenter presenter) ViewInfo(Convert.ToString(presenter.Content));
        }
        private static string dateNext;
        public static string GetDateNext() { return dateNext; }
        private void ViewInfo(string date)
        {
            dateNext = date;
            WindowNextDays windowInfo = new();
            windowInfo.ShowDialog(this); 
        }
    }
}