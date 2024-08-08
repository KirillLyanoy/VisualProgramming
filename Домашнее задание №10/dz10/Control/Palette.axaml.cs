using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Avalonia.Media.Immutable;
using System;
using System.Collections.ObjectModel;

namespace dz10.Control
{
    public class Palette : TemplatedControl
    {
        private const string MainColorSlider = "MainColorSlider";
        private ColorSlider _mainColorSlider;
        private const string MainColorSpectrum = "MainColorSpectrum";
        private ColorSpectrum _mainColorSpectrum;
        private const string AddButton = "AddButton";
        private Button _addButton;
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
        private Ellipse _currentAdditionalColor;
        private const string CurrentColorView = "CurrentColorView";
        private Avalonia.Controls.Shapes.Rectangle _currentColorView;
        private ObservableCollection<string> AdditionalColors = new ObservableCollection<string>()
        {
            "AdditionalColor0",
            "AdditionalColor1",
            "AdditionalColor2",
            "AdditionalColor3",
            "AdditionalColor4",
            "AdditionalColor5",
            "AdditionalColor6",
            "AdditionalColor7",
            "AdditionalColor8",
            "AdditionalColor9",
            "AdditionalColor10",
            "AdditionalColor11",
            "AdditionalColor12",
            "AdditionalColor13",
            "AdditionalColor14",
            "AdditionalColor15",
        };
        private ObservableCollection<Ellipse> _additionalColors = new();
        private ObservableCollection<string> MainColors = new ObservableCollection<string>()
        {
            "MainColor0",
            "MainlColor1",
            "MainColor2",
            "MainColor3",
            "MainColor4",
            "MainColor5",
            "MainColor6",
            "MainColor7",
            "MainColor8",
            "MainColor9",
            "MainColor10",
            "MainColor11",
            "MainColor12",
            "MainColor13",
            "MainColor14",
            "MainColor15",
        };
        private ObservableCollection<Ellipse> _mainColors = new();

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
            _mainColorSpectrum = e.NameScope.Find(name: MainColorSpectrum) as ColorSpectrum
                ?? throw new Exception($"{MainColorSpectrum} does not exist.");
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
            _addButton = e.NameScope.Find(name: AddButton) as Button
               ?? throw new Exception($"{AddButton} does not exist.");
            for (int i = 0; i < 16; i++)
            {
                _mainColors.Add(e.NameScope.Find(name: "MainColor" + i) as Ellipse
                ?? throw new Exception($"{"MainColor" + i} does not exist."));
                _mainColors[i].DoubleTapped += _color_DoubleTapped;
            }
            for (int i = 0; i < 16; i++)
            {
                _additionalColors.Add(e.NameScope.Find(name: "AdditionalColor" + i) as Ellipse
                ?? throw new Exception($"{"AdditionalColor" + i} does not exist."));
                _additionalColors[i].Tapped += _additionalColor_Tapped;
                _additionalColors[i].DoubleTapped += _color_DoubleTapped;
            }
            _mainColorSpectrum.ColorChanged += _mainColorSpectrum_ColorChanged;
            _mainColorSlider.ColorChanged += _mainColorSlider_ColorChanged;
            _currentRed.TextChanged += _currentTextBlock_TextChanged;
            _currentGreen.TextChanged += _currentTextBlock_TextChanged;
            _currentBlue.TextChanged += _currentTextBlock_TextChanged;
            _currentHue.TextChanged += _currentTextBlock_TextChanged;
            _currentSaturation.TextChanged += _currentTextBlock_TextChanged;
            _currentValue.TextChanged += _currentTextBlock_TextChanged;
            _addButton.Click += _addButton_Click;
            _currentRed.KeyDown += _currentRGB_KeyDown;
            _currentGreen.KeyDown += _currentRGB_KeyDown;
            _currentBlue.KeyDown += _currentRGB_KeyDown;
            _currentHue.KeyDown += _currentHSV_KeyDown;
            _currentSaturation.KeyDown += _currentHSV_KeyDown;
            _currentValue.KeyDown += _currentHSV_KeyDown;
            _currentAdditionalColor = _additionalColors[0];
        }
        private void _addButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color = CurrentRGBColor;
            _currentAdditionalColor.Fill = mySolidColorBrush;
        }
        
        private void _additionalColor_Tapped(object? sender, Avalonia.Input.TappedEventArgs e)
        {
            _currentAdditionalColor.StrokeThickness = 1;
            Ellipse ellipse = e.Source as Ellipse;
            ellipse.StrokeThickness = 3;
            _currentAdditionalColor = ellipse;
        }
        private void _currentHSV_KeyDown(object? sender, Avalonia.Input.KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            try
            {
                if (!Char.IsDigit(e.KeySymbol[0]) && e.KeySymbol[0] != ',')
                {
                    e.Handled = true;
                }
                else if (textBox.Text != null) if (textBox.Text.Contains(',') && e.KeySymbol[0] == ',') e.Handled = true;
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
                case ("CurrentHue"):
                    {
                        if (Convert.ToDouble(textBox.Text) < 360)
                        {
                            HsvColor currentHsvColor = CurrentRGBColor.ToHsv();
                            HsvColor newHsvColor = new HsvColor(currentHsvColor.A, double.Parse(textBox.Text), currentHsvColor.S, currentHsvColor.V);
                            CurrentRGBColor = newHsvColor.ToRgb();
                        }
                        break;
                    }
                case ("CurrentSaturation"):
                    {
                        if (Convert.ToDouble(textBox.Text) <= 1)
                        {
                            HsvColor currentHsvColor = CurrentRGBColor.ToHsv();
                            HsvColor newHsvColor = new HsvColor(currentHsvColor.A, currentHsvColor.H, double.Parse(textBox.Text), currentHsvColor.V);
                            CurrentRGBColor = newHsvColor.ToRgb();                            
                        }
                        break;
                    }
                case ("CurrentValue"):
                    {
                        if (Convert.ToDouble(textBox.Text) <= 1)
                        {
                            HsvColor currentHsvColor = CurrentRGBColor.ToHsv();
                            HsvColor newHsvColor = new HsvColor(currentHsvColor.A, currentHsvColor.H, currentHsvColor.S, double.Parse(textBox.Text));
                            CurrentRGBColor = newHsvColor.ToRgb();                            
                        }
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
        private void _color_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
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
    }
}
