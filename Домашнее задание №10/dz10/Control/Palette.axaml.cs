using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using System;
using System.Drawing;

namespace dz10.Control
{
    public class Palette : TemplatedControl
    {
        private const string PART_MainColorSlider = "PART_MainColorSlider";
        private ColorSlider _mainColorSlider;
        private const string PART_MainColorSpectrum = "PART_MainColorSpectrum";
        private ColorSpectrum _mainColorSpectrum;

        public static readonly StyledProperty<Avalonia.Media.Color> CurrentColorProperty =
            AvaloniaProperty.Register<Palette, Avalonia.Media.Color>(nameof(CurrentColorProperty), defaultValue:Avalonia.Media.Color.FromRgb(255, 0, 0));   

        public Avalonia.Media.Color CurrentColor
        {
            get => GetValue(CurrentColorProperty);
            set => SetValue(CurrentColorProperty, value);
        }






        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);
            _mainColorSlider = e.NameScope.Find(name: PART_MainColorSlider) as ColorSlider
                ?? throw new Exception($"{PART_MainColorSlider} does not exist.");
            _mainColorSlider.ColorChanged += _mainColorSlider_ColorChanged;

            _mainColorSpectrum = e.NameScope.Find(name: PART_MainColorSpectrum) as ColorSpectrum
                ?? throw new Exception($"{PART_MainColorSpectrum} does not exist.");
            _mainColorSpectrum.ColorChanged += _mainColorSpectrum_ColorChanged; ;

            _mainColor1 = e.NameScope.Find(name: MainColor1) as Ellipse
                ?? throw new Exception($"{MainColor1} does not exist.");
            _mainColor1.Tapped += _mainColor1_Tapped;
        }

        private void _mainColor1_Tapped(object? sender, Avalonia.Input.TappedEventArgs e)
        {
            Ellipse tempEllipse = sender as Ellipse;
      
        }

        private void _mainColorSpectrum_ColorChanged(object? sender, ColorChangedEventArgs e)
        {
            CurrentColor = e.NewColor;
        }

        private void _mainColorSlider_ColorChanged(object? sender, ColorChangedEventArgs e)
        {
            CurrentColor = e.NewColor;
        }





        private const string MainColor1 = "MainColor1";
        private Ellipse _mainColor1;
    }
}
