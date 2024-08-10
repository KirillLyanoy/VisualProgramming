using Avalonia.Controls.Primitives;
using Avalonia;

namespace dz11.Control;

public class ObjectTreeControl : TemplatedControl
{
    public static readonly StyledProperty<object> ObjectProperty =
        AvaloniaProperty.Register<ObjectTreeControl, object>("CurrentObject");
    public object Object
    {
        get => GetValue(ObjectProperty);
        set => SetValue(ObjectProperty, value);
    }
    public static readonly StyledProperty<object> HeaderProperty =
    AvaloniaProperty.Register<ObjectTreeControl, object>("Header", defaultValue: "Expander");
    public object Header
    {
        get => GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }
}