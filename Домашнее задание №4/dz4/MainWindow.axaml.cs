using Avalonia.Controls;
using Avalonia.Interactivity;
using Microsoft.VisualBasic;
using System;
using System.IO;
using Tmds.DBus.Protocol;

namespace dz4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DoubleTappedOnTextBox(object? sender, Avalonia.Input.TappedEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            GetDirectory.SetNewDirectory(Convert.ToString(textBlock.Text));

            //  GetDirectory.SetNewDirectory(Convert.ToString(Directory.GetParent(GetDirectory.GetPath())));
        }
    }
}