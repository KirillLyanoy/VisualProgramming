using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using System.Drawing;
using System.Windows.Input;

namespace dz10.Control
{
    public class Palette : TemplatedControl
    {
        public static readonly StyledProperty<Avalonia.Media.Color> CurrentColorProperty =
            AvaloniaProperty.Register<Palette, Avalonia.Media.Color>("CurrentColorProperty");
        public Avalonia.Media.Color CurrentColor
        {
            get => GetValue(CurrentColorProperty);
            set => SetValue(CurrentColorProperty, value);
        }
        public static readonly StyledProperty<string> TextChangeProperty =
            AvaloniaProperty.Register<Palette, Avalonia.Media.Color>("TextChange");
        public Avalonia.Media.Color TextChange
        {
            get => GetValue(TextChangeProperty);
            set => SetValue(TextChangeProperty, value);
        }
    }
}
