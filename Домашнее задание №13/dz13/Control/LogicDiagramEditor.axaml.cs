using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;

using LogicGateLibrary;
using System;
using System.Collections.ObjectModel;

namespace dz13.Control;

public class LogicDiagramEditor : TemplatedControl
{
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
    private const string ItemsList = "ItemsList";
    private ListBox _itemsList;
    public ObservableCollection<string> LogicGatesGOST { get; set; }
    public ObservableCollection<string> LogicGatesANSI { get; set; }

    private const string RadioButton1 = "RadioButton1";
    private RadioButton _radioButton1;
    private const string RadioButton2 = "RadioButton2";
    private RadioButton _radioButton2;
    private const string DeleteButton = "DeleteButton";
    private Button _deleteButton;

    private const string MainCanvas = "MainCanvas";
    private Canvas _mainCanvas;

    public static StyledProperty<ObservableCollection<string>> ItemsProperty = Avalonia.AvaloniaProperty.Register<LogicDiagramEditor, ObservableCollection<string>>(nameof(Items));
    public ObservableCollection<string> Items
    {
        get => GetValue(ItemsProperty);
        set => SetValue(ItemsProperty, value);
    }
    public LogicDiagramEditor()
    {
        LogicGatesGOST = new ObservableCollection<string>()
        {
            "Буфер",
            "Инвертор",
            "И",
            "И-НЕ",
            "ИЛИ",
            "ИЛИ-НЕ",
            "Исключающее ИЛИ",
            "Исключающее ИЛИ-НЕ",
            "Вход",
            "Выход",
        };
        LogicGatesANSI = new ObservableCollection<string>()
        {
            "BUF",
            "INV",
            "AND",
            "NAND",
            "OR",
            "NOR",
            "XOR",
            "XNOR",
            "IN",
            "OUT",
        };
        Items = LogicGatesGOST;
    }
    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);

        _radioButton1 = e.NameScope.Find(name: RadioButton1) as RadioButton
            ?? throw new Exception($"{RadioButton1} does not exist.");
        _radioButton2 = e.NameScope.Find(name: RadioButton2) as RadioButton
            ?? throw new Exception($"{RadioButton2} does not exist.");
        _itemsList = e.NameScope.Find(name: ItemsList) as ListBox
            ?? throw new Exception($"{ItemsList} does not exist.");
        _mainCanvas = e.NameScope.Find(name: MainCanvas) as Canvas
            ?? throw new Exception($"{MainCanvas} does not exist.");
        _deleteButton = e.NameScope.Find(name: DeleteButton) as Button
            ?? throw new Exception($"{DeleteButton} does not exist.");

        _itemsList.DoubleTapped += ItemsList_DoubleTapped;
        _radioButton1.Click += RadioButton_Click;
        _radioButton2.Click += RadioButton_Click;
        _mainCanvas.Tapped += MainCanvas_Tapped;
        _deleteButton.Click += DeleteButton_Click;
        _mainCanvas.DoubleTapped += MainCanvas_DoubleTapped;

        _mainCanvas.PointerMoved += MainCanvas_PointerMoved;
        _mainCanvas.PointerMoved += MainCanvas_SetCurrentPosition;
        _mainCanvas.PointerPressed += MainCanvas_PointerPressed;
        _mainCanvas.PointerReleased += MainCanvas_PointerReleased;        
    }
    private void MainCanvas_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        if (e.Source is IN)
        {
            var logicGate = e.Source as IN;
            LogicGateActions.ChangeIn(logicGate);
        }    
    }
    private void DeleteButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        LogicGateActions.Delete(_mainCanvas);
    }
    private void MainCanvas_SetCurrentPosition(object? sender, Avalonia.Input.PointerEventArgs e)
    {
        Point point = e.GetPosition(_mainCanvas);
        X = point.X;
        Y = point.Y;
    }
    bool moving = false;
    bool connectorCreating = false;
    Point startConnectorCreatingPoint;
    Connector temp;
    private void MainCanvas_PointerReleased(object? sender, Avalonia.Input.PointerReleasedEventArgs e)
    {
        moving = false;

        if (connectorCreating)
        {
            if (Math.Abs(temp.StartPoint.X - temp.EndPoint.X) < 10 &&
            Math.Abs(temp.StartPoint.Y - temp.EndPoint.Y) < 10) _mainCanvas.Children.Remove(temp); //линия не нарисуется, если её размер слишком маленький//
            connectorCreating = false;
        }
    }    
    private void MainCanvas_PointerMoved(object? sender, Avalonia.Input.PointerEventArgs e)
    {
        Point current = e.GetPosition(_mainCanvas);

        if (moving)
        {
            if (e.Source is LogicGate && !connectorCreating)
            {
                var logicGate = e.Source as LogicGate;
                LogicGateActions.Move(logicGate, current.X - X, current.Y - Y);
            }
            else
            {
                if (Math.Abs(current.X - temp.StartPoint.X) >= Math.Abs(current.Y - temp.StartPoint.Y)) //отрисовка горизонтальной или вертикальной линии в зависимости от курсора//
                    LogicGateActions.ChangeConnectorSize(temp, startConnectorCreatingPoint, new Point(current.X, temp.StartPoint.Y));
                else LogicGateActions.ChangeConnectorSize(temp, startConnectorCreatingPoint, new Point(temp.StartPoint.X, current.Y));
            }
        }
    }    
    private void MainCanvas_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
    {
        moving = true;
        startConnectorCreatingPoint = e.GetPosition(_mainCanvas);

        if (e.Source is not LogicGate)
        {
            temp = new Connector(startConnectorCreatingPoint);
            _mainCanvas.Children.Add(temp);
            connectorCreating = true;
            LogicGateActions.RemoveAllSelections(_mainCanvas);
        }                    
    }
    private void MainCanvas_Tapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        if (e.Source is LogicGate)
        {         
            var logicGate = e.Source as LogicGate;
            LogicGateActions.IsSelected(logicGate);          
        }
    }
    private void ItemsList_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        if (e.Source is ContentPresenter || e.Source is TextBlock)
        {
            ListBox listBox = sender as ListBox;
            LogicGateActions.Add(_mainCanvas, Convert.ToString(listBox.SelectedValue));
        }
    }
    private void RadioButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        RadioButton radioButton = sender as RadioButton;
        switch (radioButton.Content)
        {
            case ("ГОСТ"):
                Items = LogicGatesGOST;
                break;
            case ("ANSI"):
                Items = LogicGatesANSI;
                break;
        }
    }
}