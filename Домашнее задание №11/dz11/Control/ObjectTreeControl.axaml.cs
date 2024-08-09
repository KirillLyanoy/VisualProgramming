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

    private static readonly StyledProperty<ObservableCollection<Component>> objectTree =
    AvaloniaProperty.Register<ObjectTreeControl, ObservableCollection<Component>>("ObjectTreeItem");
    private ObservableCollection<Component> ObjectTreeItem
    {
        get => GetValue(ObjectTree);
        set => SetValue(ObjectTree, value);
    }

    private const string TreeViewMain = "TreeViewMain";
    private TreeView _treeViewMain;

    internal static StyledProperty<ObservableCollection<Component>> ObjectTree => objectTree;

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
        ConvertToTree(CurrentObject, ObjectTreeItem);

        _treeViewMain = e.NameScope.Find(name: TreeViewMain) as TreeView
               ?? throw new Exception($"{TreeViewMain} does not exist.");
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);
        if (change.Property == ObjectTree)
        {
            _treeViewMain.ItemsSource = ObjectTreeItem;
        }
    }

            private void ConvertToTree<T>(T data, ObservableCollection<Component> collection)
    {
        Type type = data.GetType();
        Composite composite = new Composite(Convert.ToString(type.Name));
        PropertyInfo[] propertyes = type.GetProperties();
        object[] arrObj = new object[propertyes.Length];
        foreach (PropertyInfo property in propertyes)
        {
            if (property.GetValue(data) is int || property.GetValue(data) is string)
            {
                composite.Add(new Leaf(Convert.ToString(property.Name) + ":\t" + Convert.ToString(property.GetValue(data))));
            }
            else
            {
                ConvertToTree(property.GetValue(data), composite.Children);
            }
        }
        collection.Add(composite);
    }
}

