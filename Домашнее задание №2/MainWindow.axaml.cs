using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Styling;
using System;
using System.Drawing;
using System.Reflection.Metadata;
using Tmds.DBus.Protocol;

namespace dz2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void ClickHandler(object sender, RoutedEventArgs args)
        {
            Button button = sender as Button;      
            rectangleRect.Background = button.Background;
        }        
    }
}