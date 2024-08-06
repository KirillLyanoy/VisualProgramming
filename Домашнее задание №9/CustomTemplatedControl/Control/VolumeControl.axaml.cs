using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using Avalonia.Platform;
using System;
using System.Drawing;
using System.Runtime.InteropServices.ObjectiveC;
using System.Windows.Input;

namespace dz9.Control
{
    public class VolumeControl : TemplatedControl
    {
        public static readonly StyledProperty<ICommand> FullSizeCommand =
            AvaloniaProperty.Register<VolumeControl, ICommand>("FullSizeCommand");
        public ICommand FullSize
        {
            get => GetValue(FullSizeCommand);
            set => SetValue(FullSizeCommand, value);
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
