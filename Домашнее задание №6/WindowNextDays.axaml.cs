using Avalonia.Controls;

namespace dz6
{
    public partial class WindowNextDays : Window
    {
        public WindowNextDays()
        {
            InitializeComponent();
        }
        private void CloseWindow(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            this.Close();           
        }  
    }
}