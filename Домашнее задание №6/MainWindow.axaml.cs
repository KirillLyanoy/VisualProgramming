using Avalonia.Controls;
using System.Threading;

namespace dz6
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {            
            DataContextMainWindow dataContextMainWindow = new DataContextMainWindow();
            InitializeComponent();        
        }

        private void SetNewCity(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {

        }
    }
}