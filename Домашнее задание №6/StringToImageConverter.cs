using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Globalization;

namespace dz6
{
    internal class StringToImageConverter : IValueConverter
    {       
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is model.List list)
            {
                Bitmap image = new(AssetLoader.Open(new Uri("avares://dz6/Assets/" + list.Weather[0].Icon + ".png")));
                return image;
            }
            else return null;
        }
        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {         
            return null;
        }

    }
}
