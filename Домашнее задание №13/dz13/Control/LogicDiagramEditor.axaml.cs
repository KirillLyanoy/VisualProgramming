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
    private const string ItemsList = "ItemsList";
    private ListBox _itemsList;
    public ObservableCollection<string> LogicGatesGOST { get; set; }
    public ObservableCollection<string> LogicGatesANSI { get; set; }

    private const string RadioButton1 = "RadioButton1";
    private RadioButton _radioButton1;
    private const string RadioButton2 = "RadioButton2";
    private RadioButton _radioButton2;

    private const string MainCanvas = "MainCanvas";
    private Canvas _mainCanvas;

    public static StyledProperty<ObservableCollection<string>> ItemsProperty = Avalonia.AvaloniaProperty.Register<LogicDiagramEditor, ObservableCollection<string>>(nameof(Items));
    public ObservableCollection<string> Items
    {
        get => GetValue(ItemsProperty);
        set => SetValue(ItemsProperty, value);
    }

    public static StyledProperty<LogicGate> CurrentItemProperty = Avalonia.AvaloniaProperty.Register<LogicDiagramEditor, LogicGate>(nameof(CurrentItem));
    public LogicGate CurrentItem
    {
        get => GetValue(CurrentItemProperty);
        set => SetValue(CurrentItemProperty, value);
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
            "Коннектор"
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
            "CONNECTOR"
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

        _mainCanvas.Tapped += MainCanvas_Tapped;

        _itemsList.DoubleTapped += ItemsList_DoubleTapped;
        _radioButton1.Click += RadioButton_Click;
        _radioButton2.Click += RadioButton_Click;
    }

    private void MainCanvas_Tapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        LogicGate selectedGate = e.Source as LogicGate;
        selectedGate.IsSelected = true;
        selectedGate.Render(selectedGate.)
    }

    private void ItemsList_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        if (e.Source is not ContentPresenter && e.Source is not TextBlock) return;
        ListBox listBox = sender as ListBox;
        switch (listBox.SelectedValue)
        {
            case ("Буфер"):
                _mainCanvas.Children.Add(new BUF(Standart.GOST));
                break;
            case ("Инвертор"):
                _mainCanvas.Children.Add(new INV(Standart.GOST));
                break;
            case ("И"):
                _mainCanvas.Children.Add(new AND(Standart.GOST));
                break;
            case ("И-НЕ"):
                _mainCanvas.Children.Add(new NAND(Standart.GOST));
                break;
            case ("ИЛИ"):
                _mainCanvas.Children.Add(new OR(Standart.GOST));
                break;
            case ("ИЛИ-НЕ"):
                _mainCanvas.Children.Add(new NOR(Standart.GOST));
                break;
            case ("Исключающее ИЛИ"):
                _mainCanvas.Children.Add(new XOR(Standart.GOST));
                break;
            case ("Исключающее ИЛИ-НЕ"):
                _mainCanvas.Children.Add(new XNOR(Standart.GOST));
                break;
            case ("Вход"):
                _mainCanvas.Children.Add(new IN());
                break;
            case ("Выход"):
                _mainCanvas.Children.Add(new OUT());
                break;
            case ("Коннектор"):
                _mainCanvas.Children.Add(new Connector());
                break;
            case ("BUF"):
                _mainCanvas.Children.Add(new BUF(Standart.ANSI));
                break;
            case ("INV"):
                _mainCanvas.Children.Add(new INV(Standart.ANSI));
                break;
            case ("AND"):
                _mainCanvas.Children.Add(new AND(Standart.ANSI));
                break;
            case ("NAND"):
                _mainCanvas.Children.Add(new NAND(Standart.ANSI));
                break;
            case ("OR"):
                _mainCanvas.Children.Add(new OR(Standart.ANSI));
                break;
            case ("NOR"):
                _mainCanvas.Children.Add(new NOR(Standart.ANSI));
                break;
            case ("XOR"):
                _mainCanvas.Children.Add(new XOR(Standart.ANSI));
                break;
            case ("XNOR"):
                _mainCanvas.Children.Add(new XNOR(Standart.ANSI));
                break;
            case ("IN"):
                _mainCanvas.Children.Add(new IN());
                break;
            case ("OUT"):
                _mainCanvas.Children.Add(new OUT());
                break;
            case ("Connector"):
                _mainCanvas.Children.Add(new Connector());
                break;
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