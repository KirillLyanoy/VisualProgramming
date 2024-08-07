using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using System;

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
        }

        private void _mainColorSpectrum_ColorChanged(object? sender, ColorChangedEventArgs e)
        {
            CurrentColor = e.NewColor;
        }

        private void _mainColorSlider_ColorChanged(object? sender, ColorChangedEventArgs e)
        {
            CurrentColor = e.NewColor;
        }
    }
}
