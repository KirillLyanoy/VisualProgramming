using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Converters;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Avalonia.Media.Immutable;
using ReactiveUI;
using SkiaSharp;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;

namespace dz10.Control
{
    public class Palette : TemplatedControl
    {
        private const string MainColorSlider = "MainColorSlider";
        private ColorSlider _mainColorSlider;
        private const string MainColorSpectrum = "MainColorSpectrum";
        private ColorSpectrum _mainColorSpectrum;

        private const string CurrentRed = "CurrentRed";
        private TextBox _currentRed;
        private const string CurrentGreen = "CurrentGreen";
        private TextBox _currentGreen;
        private const string CurrentBlue = "CurrentBlue";
        private TextBox _currentBlue;
        private const string CurrentHue = "CurrentHue";
        private TextBox _currentHue;
        private const string CurrentSaturation = "CurrentSaturation";
        private TextBox _currentSaturation;
        private const string CurrentValue = "CurrentValue";
        private TextBox _currentValue;

        public static readonly StyledProperty<Avalonia.Media.Color> CurrentRGBColorProperty =
            AvaloniaProperty.Register<Palette, Avalonia.Media.Color>(nameof(CurrentRGBColorProperty), defaultValue:Avalonia.Media.Color.FromRgb(255, 0, 0));   
        public Avalonia.Media.Color CurrentRGBColor
        {
            get => GetValue(CurrentRGBColorProperty);
            set => SetValue(CurrentRGBColorProperty, value);
        }
        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);
            _mainColorSlider = e.NameScope.Find(name: MainColorSlider) as ColorSlider
                ?? throw new Exception($"{MainColorSlider} does not exist.");
            _mainColorSlider.ColorChanged += _mainColorSlider_ColorChanged;
            _mainColorSpectrum = e.NameScope.Find(name: MainColorSpectrum) as ColorSpectrum
                ?? throw new Exception($"{MainColorSpectrum} does not exist.");
            _mainColorSpectrum.ColorChanged += _mainColorSpectrum_ColorChanged; ;
            _mainColor1 = e.NameScope.Find(name: MainColor1) as Ellipse
                ?? throw new Exception($"{MainColor1} does not exist.");
            _mainColor2 = e.NameScope.Find(name: MainColor2) as Ellipse
                ?? throw new Exception($"{MainColor2} does not exist.");
            _mainColor3 = e.NameScope.Find(name: MainColor3) as Ellipse
                ?? throw new Exception($"{MainColor3} does not exist.");
            _mainColor4 = e.NameScope.Find(name: MainColor4) as Ellipse
                ?? throw new Exception($"{MainColor4} does not exist.");
            _mainColor5 = e.NameScope.Find(name: MainColor5) as Ellipse
                ?? throw new Exception($"{MainColor5} does not exist.");
            _mainColor6 = e.NameScope.Find(name: MainColor6) as Ellipse
                ?? throw new Exception($"{MainColor6} does not exist.");
            _mainColor7 = e.NameScope.Find(name: MainColor7) as Ellipse
               ?? throw new Exception($"{MainColor7} does not exist.");
            _mainColor8 = e.NameScope.Find(name: MainColor8) as Ellipse
               ?? throw new Exception($"{MainColor8} does not exist.");
            _mainColor9 = e.NameScope.Find(name: MainColor9) as Ellipse
               ?? throw new Exception($"{MainColor9} does not exist.");
            _mainColor10 = e.NameScope.Find(name: MainColor10) as Ellipse
               ?? throw new Exception($"{MainColor10} does not exist.");
            _mainColor11 = e.NameScope.Find(name: MainColor11) as Ellipse
               ?? throw new Exception($"{MainColor11} does not exist.");
            _mainColor12 = e.NameScope.Find(name: MainColor12) as Ellipse
               ?? throw new Exception($"{MainColor12} does not exist.");
            _mainColor13 = e.NameScope.Find(name: MainColor13) as Ellipse
               ?? throw new Exception($"{MainColor13} does not exist.");
            _mainColor14 = e.NameScope.Find(name: MainColor14) as Ellipse
               ?? throw new Exception($"{MainColor14} does not exist.");
            _mainColor15 = e.NameScope.Find(name: MainColor15) as Ellipse
               ?? throw new Exception($"{MainColor15} does not exist.");
            _mainColor16 = e.NameScope.Find(name: MainColor16) as Ellipse
               ?? throw new Exception($"{MainColor16} does not exist.");
            _currentColorView = e.NameScope.Find(name: CurrentColorView) as Avalonia.Controls.Shapes.Rectangle
               ?? throw new Exception($"{CurrentColorView} does not exist.");
            _currentRed = e.NameScope.Find(name: CurrentRed) as TextBox
               ?? throw new Exception($"{CurrentRed} does not exist.");
            _currentGreen = e.NameScope.Find(name: CurrentGreen) as TextBox
               ?? throw new Exception($"{CurrentRed} does not exist.");
            _currentBlue = e.NameScope.Find(name: CurrentBlue) as TextBox
               ?? throw new Exception($"{CurrentBlue} does not exist.");
            _currentHue = e.NameScope.Find(name: CurrentHue) as TextBox
               ?? throw new Exception($"{CurrentHue} does not exist.");
            _currentSaturation = e.NameScope.Find(name: CurrentSaturation) as TextBox
               ?? throw new Exception($"{CurrentSaturation} does not exist.");
            _currentValue = e.NameScope.Find(name: CurrentValue) as TextBox
               ?? throw new Exception($"{CurrentValue} does not exist.");

            _mainColor1.Tapped += _mainColor_Tapped;
            _mainColor2.Tapped += _mainColor_Tapped;
            _mainColor3.Tapped += _mainColor_Tapped;
            _mainColor4.Tapped += _mainColor_Tapped;
            _mainColor5.Tapped += _mainColor_Tapped;
            _mainColor6.Tapped += _mainColor_Tapped;
            _mainColor7.Tapped += _mainColor_Tapped;
            _mainColor8.Tapped += _mainColor_Tapped;
            _mainColor9.Tapped += _mainColor_Tapped;
            _mainColor10.Tapped += _mainColor_Tapped;
            _mainColor11.Tapped += _mainColor_Tapped;
            _mainColor12.Tapped += _mainColor_Tapped;
            _mainColor13.Tapped += _mainColor_Tapped;
            _mainColor14.Tapped += _mainColor_Tapped;
            _mainColor15.Tapped += _mainColor_Tapped;
            _mainColor16.Tapped += _mainColor_Tapped;

            _currentRed.TextChanged += _currentTextBlock_TextChanged;
            _currentGreen.TextChanged += _currentTextBlock_TextChanged;
            _currentBlue.TextChanged += _currentTextBlock_TextChanged;
            _currentHue.TextChanged += _currentTextBlock_TextChanged;
            _currentSaturation.TextChanged += _currentTextBlock_TextChanged;
            _currentValue.TextChanged += _currentTextBlock_TextChanged;

            _currentRed.KeyDown += _currentRGB_KeyDown;
            _currentGreen.KeyDown += _currentRGB_KeyDown;
            _currentBlue.KeyDown += _currentRGB_KeyDown;
            _currentSaturation.KeyDown += _currentSV_KeyDown;
            _currentValue.KeyDown += _currentSV_KeyDown;
        }

        private void _currentSV_KeyDown(object? sender, Avalonia.Input.KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            try
            {                
                if (!Char.IsDigit(e.KeySymbol[0]))
                {
                    if (e.KeySymbol != ",") e.Handled = true;
                    else if (textBox.Text.Last() == ',') e.Handled = true;
                }
                else
                {
                    if (Convert.ToInt64(textBox.Text + e.KeySymbol[0]) > 1) e.Handled = true;
                }
            }
            catch (System.NullReferenceException)
            {
                e.Handled = true;
            }
        }

        private void _currentRGB_KeyDown(object? sender, Avalonia.Input.KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;                
            try
            {
                if (!Char.IsDigit(e.KeySymbol[0]))
                {
                    e.Handled = true;
                }
                else
                {
                    if (textBox.Text != null) if (textBox.Text.Length > 2) e.Handled = true;
                    else if (Convert.ToInt16(textBox.Text + e.KeySymbol[0]) > 255) e.Handled = true;
                }
            }
            catch (System.NullReferenceException)
            {
                e.Handled = true;
            }
        }

        private void _currentTextBlock_TextChanged(object? sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox; 
            if (textBox.Text == "") return;
            if (textBox.Text == "1." || textBox.Text == "0.") return;
            switch (textBox.Name)
            {
                case ("CurrentRed"):                   
                    CurrentRGBColor = new Avalonia.Media.Color(CurrentRGBColor.A, byte.Parse(textBox.Text), CurrentRGBColor.G, CurrentRGBColor.B);
                    break;
                case ("CurrentGreen"):
                    CurrentRGBColor = new Avalonia.Media.Color(CurrentRGBColor.A, CurrentRGBColor.R, byte.Parse(textBox.Text), CurrentRGBColor.B);
                    break;
                case ("CurrentBlue"):
                    CurrentRGBColor = new Avalonia.Media.Color(CurrentRGBColor.A, CurrentRGBColor.R, CurrentRGBColor.G, byte.Parse(textBox.Text));
                    break;
                case ("CurrentHeu"):
                    {
                        HsvColor currentHsvColor = CurrentRGBColor.ToHsv();
                        HsvColor newHsvColor = new HsvColor(currentHsvColor.A, double.Parse(textBox.Text), currentHsvColor.S, currentHsvColor.V);
                        CurrentRGBColor = newHsvColor.ToRgb();
                        break;
                    }
                case ("CurrentSaturation"):
                    {
                        HsvColor currentHsvColor = CurrentRGBColor.ToHsv();
                        HsvColor newHsvColor = new HsvColor(currentHsvColor.A, currentHsvColor.H, double.Parse(textBox.Text), currentHsvColor.V);
                        CurrentRGBColor = newHsvColor.ToRgb();
                        break;
                    }
                case ("CurrentValue"):
                    {
                        HsvColor currentHsvColor = CurrentRGBColor.ToHsv();
                        HsvColor newHsvColor = new HsvColor(currentHsvColor.A, currentHsvColor.H, currentHsvColor.S, double.Parse(textBox.Text));
                        CurrentRGBColor = newHsvColor.ToRgb();
                        break;
                    }
                default:
                    break;
            }
        }

        protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
        {
            base.OnPropertyChanged(change);
            if (change.Property == CurrentRGBColorProperty)
            {
                SolidColorBrush mySolidColorBrush = new SolidColorBrush();
                Avalonia.Media.Color newColor = (Avalonia.Media.Color)change.NewValue;
                mySolidColorBrush.Color = Avalonia.Media.Color.FromArgb(newColor.A,  newColor.R, newColor.G, newColor.B);
                _currentColorView.Fill = mySolidColorBrush;

                _mainColorSpectrum.Color = newColor;
                _mainColorSlider.Color = newColor;

                _currentRed.Text = newColor.R.ToString();
                _currentGreen.Text = newColor.G.ToString();
                _currentBlue.Text = newColor.B.ToString();

                _currentHue.Text = newColor.ToHsv().H.ToString();
                _currentSaturation.Text = newColor.ToHsv().S.ToString();
                _currentValue.Text = newColor.ToHsv().V.ToString();
            }
            
        }
 
        private void _mainColor_Tapped(object? sender, Avalonia.Input.TappedEventArgs e)
        {
            Ellipse ellipse = sender as Ellipse;
            ImmutableSolidColorBrush colorBrush = ellipse.Fill.ToImmutable() as ImmutableSolidColorBrush;
            CurrentRGBColor = colorBrush.Color;
        }
        private void _mainColorSpectrum_ColorChanged(object? sender, ColorChangedEventArgs e)
        {
            CurrentRGBColor = e.NewColor;
        }
        private void _mainColorSlider_ColorChanged(object? sender, ColorChangedEventArgs e)
        {
            CurrentRGBColor = e.NewColor;
        }
        private const string MainColor1 = "MainColor1";
        private Ellipse _mainColor1;
        private const string MainColor2 = "MainColor2";
        private Ellipse _mainColor2;
        private const string MainColor3 = "MainColor3";
        private Ellipse _mainColor3;
        private const string MainColor4 = "MainColor4";
        private Ellipse _mainColor4;
        private const string MainColor5 = "MainColor5";
        private Ellipse _mainColor5;
        private const string MainColor6 = "MainColor6";
        private Ellipse _mainColor6;
        private const string MainColor7 = "MainColor7";
        private Ellipse _mainColor7;
        private const string MainColor8 = "MainColor8";
        private Ellipse _mainColor8;
        private const string MainColor9 = "MainColor9";
        private Ellipse _mainColor9;
        private const string MainColor10 = "MainColor10";
        private Ellipse _mainColor10;
        private const string MainColor11 = "MainColor11";
        private Ellipse _mainColor11;
        private const string MainColor12 = "MainColor12";
        private Ellipse _mainColor12;
        private const string MainColor13 = "MainColor13";
        private Ellipse _mainColor13;
        private const string MainColor14 = "MainColor14";
        private Ellipse _mainColor14;
        private const string MainColor15 = "MainColor15";
        private Ellipse _mainColor15;
        private const string MainColor16 = "MainColor16";
        private Ellipse _mainColor16;

        private const string CurrentColorView = "CurrentColorView";
        private Avalonia.Controls.Shapes.Rectangle _currentColorView;
    }
}
