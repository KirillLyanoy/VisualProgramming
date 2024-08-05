using Avalonia.Controls;
using System.ComponentModel;

namespace dz9;

public partial class VolumeControl : UserControl, INotifyPropertyChanged
{
    public VolumeControl()
    {
        InitializeComponent();
    }
    private bool IsChecked = false;
    private double minValue = 0;
    private double maxValue = 1000;
    public double MinValue { get { return minValue; } set { minValue = value; } }
    public double MaxValue { get { return maxValue; } set { maxValue = value; } }
   
    private void WrapPanel_Tapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        if (e.Source is Image)
        {
            if (!IsChecked)
            {
                slider.IsVisible = true;
                IsChecked = true;
            }
            else
            {
                slider.IsVisible = false;
                IsChecked = false;
            }
        }
    }
}