using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using Avalonia.VisualTree;
using LogicGateLibrary;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;

namespace dz13.Control;

public class LogicDiagramEditor : TemplatedControl
{
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
    private const string ClearButton = "ClearButton";
    private Button _clearButton;
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
        _clearButton = e.NameScope.Find(name: ClearButton) as Button
            ?? throw new Exception($"{ClearButton} does not exist.");

        _mainCanvas.Children.Add(new CanvasLayout(_mainCanvas.GetVisualRoot().ClientSize.Width, _mainCanvas.GetVisualRoot().ClientSize.Height));

        _itemsList.DoubleTapped += ItemsList_DoubleTapped;
        _radioButton1.Click += RadioButton_Click;
        _radioButton2.Click += RadioButton_Click;
        _mainCanvas.Tapped += MainCanvas_Tapped;
        _deleteButton.Click += DeleteButton_Click;
        _mainCanvas.DoubleTapped += MainCanvas_DoubleTapped;
        _clearButton.Click += ClearButton_Click;
        _mainCanvas.SizeChanged += MainCanvas_SizeChanged;

        _mainCanvas.PointerMoved += MainCanvas_PointerMoved;
        _mainCanvas.PointerPressed += MainCanvas_PointerPressed;
        _mainCanvas.PointerReleased += MainCanvas_PointerReleased;        
    }
    private void MainCanvas_SizeChanged(object? sender, SizeChangedEventArgs e)
    {
        foreach (var item in _mainCanvas.Children.ToList())
        {
            if (item.GetType() == typeof(CanvasLayout)) _mainCanvas.Children.Remove(item);
        }
        CanvasLayout canvasLayout = new CanvasLayout(_mainCanvas.GetVisualRoot().ClientSize.Width, _mainCanvas.GetVisualRoot().ClientSize.Height);
        canvasLayout.ZIndex = -1;
        _mainCanvas.Children.Add(canvasLayout);                      
    }
    private void ClearButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        LogicGateActions.ClearCanvas(_mainCanvas);
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
    private bool _gateMoving = false;
    private bool _connectorCreating = false;
    private Connector temporaryConnector;
    private void MainCanvas_PointerReleased(object? sender, Avalonia.Input.PointerReleasedEventArgs e)
    {
        _gateMoving = false;
        if (_connectorCreating)
        {
            LogicGateActions.CheckConnectorSize(_mainCanvas, temporaryConnector);
            _connectorCreating = false;
        }
    }
    private void MainCanvas_PointerMoved(object? sender, Avalonia.Input.PointerEventArgs e)
    {
        if (_connectorCreating)
        {
            Avalonia.Point currentPosition = e.GetPosition(_mainCanvas);
      
            if (e.Source is Connector)
            {
                if (Math.Abs(currentPosition.X - temporaryConnector.StartPoint.X) >= Math.Abs(currentPosition.Y - temporaryConnector.StartPoint.Y)) //отрисовка горизонтальной или вертикальной линии в зависимости от курсора//
                    LogicGateActions.EditConnectorX(temporaryConnector, Math.Round(currentPosition.X / 10) * 10);
                else LogicGateActions.EditConnectorY(temporaryConnector, Math.Round(currentPosition.Y / 10) * 10);
            }
            else LogicGateActions.EditConnectorX(temporaryConnector, Math.Round(currentPosition.X / 10) * 10);
        }
        else
        {
            switch (e.Source)
            {
                case Connector:

                    break;
                case LogicGate:
                    if (_gateMoving && !_connectorCreating)
                    {
                        var logicGate = e.Source as LogicGate;
                        if (logicGate.IsSelected)
                        {
                            LogicGateActions.Move(logicGate, e.GetPosition(_mainCanvas));
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
    private void MainCanvas_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
    {
        switch(e.Source)
        {
            case Connector:
                var connector = e.Source as Connector;
                if (connector.IsSelected)
                {
                    _gateMoving = true;
                }
                else
                {
                    temporaryConnector = LogicGateActions.CreateConnector(_mainCanvas, connector, e.GetPosition(_mainCanvas));
                    _connectorCreating = true;
                }
                break;
            case LogicGate:
                var logicGate = e.Source as LogicGate;
                if (logicGate.IsSelected)
                {
                    _gateMoving = true;
                }
                else
                {
                    temporaryConnector = LogicGateActions.CreateConnector(_mainCanvas, logicGate, e.GetPosition(_mainCanvas));
                    if (temporaryConnector != null) _connectorCreating = true;
                }
                break;            
        }
    }

    private void MainCanvas_Tapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        switch (e.Source)
        {
            case Canvas:
            case CanvasLayout:
                LogicGateActions.RemoveAllSelections(_mainCanvas);
                break;
            case LogicGate:
                var logicGate = e.Source as LogicGate;
                LogicGateActions.IsSelected(logicGate);
                break;
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