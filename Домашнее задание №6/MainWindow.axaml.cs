using Avalonia.Controls;

namespace dz6
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CurrentWeather.GetWeather();
        }
    }
}