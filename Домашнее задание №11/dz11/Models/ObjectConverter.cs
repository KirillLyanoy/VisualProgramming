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
            if (!CheckBaseType(value.GetType()))
            {
                ToTree(value, collection);
            }
            else
            {              
                collection.Add(new Leaf(value, System.Convert.ToString(value.GetType())));
            }
            return collection;
        }
        private void ToTree<T>(T value, ObservableCollection<Component> collection)
        {
            Type type = value.GetType();
            Composite composite = new(type.Name);
            PropertyInfo[] propertyes = type.GetProperties();
            _ = new object[propertyes.Length];
            foreach (PropertyInfo property in propertyes)
            {
                if (property.GetValue(value) is int || property.GetValue(value) is string)
                {
                    composite.Add(new Leaf(property.GetValue(value), property.Name));
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

        private bool CheckBaseType(Type type)
        {
            var typeCode = Type.GetTypeCode(type);
            switch (typeCode)
            {
                case TypeCode.Boolean:
                    return true;
                case TypeCode.Byte:
                    return true;
                case TypeCode.Char:
                    return true;
                case TypeCode.DBNull:
                    return true;
                case TypeCode.DateTime:
                    return true;
                case TypeCode.Decimal:
                    return true;
                case TypeCode.Double:
                    return true;
                case TypeCode.Empty:
                    return true;
                case TypeCode.Int16:
                    return true;
                case TypeCode.Int32:
                    return true;
                case TypeCode.Int64:
                    return true;
                case TypeCode.SByte:
                    return true;
                case TypeCode.Single:
                    return true;
                case TypeCode.String:
                    return true;
                case TypeCode.UInt16:
                    return true;
                case TypeCode.UInt32:
                    return true;
                case TypeCode.UInt64:
                    return true;
                default:
                    return false;
            }
        }
    }
}
