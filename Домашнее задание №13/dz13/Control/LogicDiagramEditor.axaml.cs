using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Metadata;
using LogicGateLibrary;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace dz13.Control;

public class LogicDiagramEditor : TemplatedControl
{
    private const string MainCanvas = "MainCanvas";
    private Canvas _mainCanvas;

    public static StyledProperty<double> XProperty = Avalonia.AvaloniaProperty.Register<LogicDiagramEditor, double>(nameof(X));
    public double X
    {
        get => GetValue(XProperty);
        set => SetValue(XProperty, value);
    }
    public static StyledProperty<double> YProperty = Avalonia.AvaloniaProperty.Register<LogicDiagramEditor, double>(nameof(Y));
    public double Y
    {
        get => GetValue(YProperty);
        set => SetValue(YProperty, value);
    }

    public static StyledProperty<ObservableCollection<LogicGate>> ItemsOnCanvasProperty = Avalonia.AvaloniaProperty.Register<LogicDiagramEditor, ObservableCollection<LogicGate>>(nameof(Items));
    [Content]
    public ObservableCollection<LogicGate> ItemsOnCanvas
    {
        get => GetValue(ItemsProperty);
        set => SetValue(ItemsProperty, value);
    }

    public static StyledProperty<ObservableCollection<LogicGate>> ItemsProperty = Avalonia.AvaloniaProperty.Register<LogicDiagramEditor, ObservableCollection<LogicGate>>(nameof(Items));
    [Content]
    public ObservableCollection<LogicGate> Items
    {
        get => GetValue(ItemsProperty);
        set => SetValue(ItemsProperty, value);
    }
    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);


        _mainCanvas = e.NameScope.Find(name: MainCanvas) as Canvas
            ?? throw new Exception($"{MainCanvas} not finded");
        _mainCanvas.PointerMoved += MainCanvasPointerMoved;
        
    }



    private void MainCanvasPointerMoved(object? sender, Avalonia.Input.PointerEventArgs e)
    {
        var position = e.GetPosition(_mainCanvas);
        X = position.X;
        Y = position.Y;
    }
}