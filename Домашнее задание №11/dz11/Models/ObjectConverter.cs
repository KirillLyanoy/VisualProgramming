using Avalonia.Data.Converters;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Reflection;

namespace dz11.Models
{
    internal class ObjectConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            ObservableCollection<Component> collection = [];
            if (value.GetType().IsClass && value is not string)
            {
                ToTree(value, collection);
            }
            else
            {              
                collection.Add(new Leaf((string)value, value.GetType()));
            }
            return collection;
        }
        private void ToTree<T>(T value, ObservableCollection<Component> collection)
        {
            Type type = value.GetType();
            Composite composite = new((string)(type.Name), type);
            PropertyInfo[] propertyes = type.GetProperties();
            _ = new object[propertyes.Length];
            foreach (PropertyInfo property in propertyes)
            {
                if (property.GetValue(value) is int || property.GetValue(value) is string)
                {
                    composite.Add(new Leaf(property.Name, property.GetValue(value)));
                }
                else
                {
                    ToTree(property.GetValue(value), composite.Children);
                }
            }
            collection.Add(composite);
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
