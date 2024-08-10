using Avalonia.Controls.Primitives;
using Avalonia;
using dz11.Models;
using System.Collections.ObjectModel;
using System.Reflection;
using System;
using Avalonia.Controls;


namespace dz11.Control;

public class ObjectTreeControl : TemplatedControl
{
    public static readonly StyledProperty<object> CurrentObjectProperty =
        AvaloniaProperty.Register<ObjectTreeControl, object>("CurrentObject");
    public object CurrentObject
    {
        get => GetValue(CurrentObjectProperty);
        set => SetValue(CurrentObjectProperty, value);
    }   
}