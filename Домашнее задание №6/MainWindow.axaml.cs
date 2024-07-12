using Avalonia.Controls;
using System;
using System.Threading;

namespace dz6
{
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {      
            InitializeComponent();        
        }

        private static DataContextMainWindow _dataContextMainWindow;
        private void SetNewCity(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            DataContextMainWindow.aTimer.Stop();
            WeatherService.SetUrl("https://api.openweathermap.org/data/2.5/forecast?q=" + NewCity.Text + "&units=metric&appid=65270a98c3dcac555ca95710dfd76dda");
            _dataContextMainWindow = new DataContextMainWindow();
        }
    }
}