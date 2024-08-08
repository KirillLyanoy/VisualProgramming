using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using System.Windows.Input;

namespace dz9.Control
{
    public class VolumeControl : TemplatedControl
    {    
        
        public static readonly StyledProperty<ICommand> VolumeCommandProperty =
            AvaloniaProperty.Register<VolumeControl, ICommand>("VolumeCommand");
        public ICommand VolumeCommand
        {
            get => GetValue(VolumeCommandProperty);
            set => SetValue(VolumeCommandProperty, value);
        }
        public static readonly StyledProperty<bool> FullSizeProperty =
            AvaloniaProperty.Register<VolumeControl, bool>("FullSize");
        public bool FullSize
        {
            get => GetValue(FullSizeProperty);
            set => SetValue(FullSizeProperty, value);
        }
        public static readonly StyledProperty<object> MinValueProperty =
            AvaloniaProperty.Register<VolumeControl, object>("MinValueProperty");
        public object MinValue
        {
            get => GetValue(MinValueProperty);
            set => SetValue(MinValueProperty, value);
        }
        public static readonly StyledProperty<object> MaxValueProperty =
            AvaloniaProperty.Register<VolumeControl, object>("MaxValueProperty");
        public object MaxValue
        {
            get => GetValue(MaxValueProperty);
            set => SetValue(MaxValueProperty, value);
        }
        public static readonly StyledProperty<IImage?> ImagePathProperty =
            AvaloniaProperty.Register<VolumeControl, IImage?>("ImagePathProperty");
        public IImage? ImagePath
        {
            get => GetValue(ImagePathProperty);
            set => SetValue(ImagePathProperty,value);
        }
     }
}
