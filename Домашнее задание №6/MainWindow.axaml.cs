using Avalonia.Controls;
using System;
using System.Threading;

namespace dz6
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {            
            DataContextMainWindow dataContextMainWindow;
            InitializeComponent();        
        }

        private void SetNewCity(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            DataContextMainWindow.aTimer.Stop();

         //   WeatherService.client.CancelPendingRequests();
         //   WeatherService.NewUri("https://api.openweathermap.org/data/2.5/forecast?q=Novosibirsk&units=metric&appid=65270a98c3dcac555ca95710dfd76dda");




            DataContextMainWindow.aTimer.Start();
        }
    }
}