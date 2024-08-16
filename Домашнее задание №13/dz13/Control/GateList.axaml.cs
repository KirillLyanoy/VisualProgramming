using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using LogicGateLibrary;
using System;
using System.Collections.ObjectModel;

namespace dz13.Control;

public class GateList : TemplatedControl
{
    private const string ItemsList = "ItemsList";
    private ListBox _itemsList;

    public ObservableCollection<string> LogicGatesGOST { get; set; }
    public ObservableCollection<string> LogicGatesANSI { get; set; }

    private const string RadioButton1 = "RadioButton1";
    private RadioButton _radioButton1;
    private const string RadioButton2 = "RadioButton2";
    private RadioButton _radioButton2;

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
    public GateList()
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

        _itemsList.DoubleTapped += ItemsList_DoubleTapped;
        _radioButton1.Click += RadioButton_Click;
        _radioButton2.Click += RadioButton_Click;
    }
    private void ItemsList_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        ContentPresenter contentPresenter = e.Source as ContentPresenter;
        switch (contentPresenter.Content)
        {
            case ("Буфер"):
                break;
            case ("Инвертор"):
                break;
            case ("И"):
                break;
            case ("И-НЕ"):
                break;
            case ("ИЛИ"):
                break;
            case ("ИЛИ-НЕ"):
                break;
            case ("Исключающее ИЛИ"):
                break;
            case ("Исключающее ИЛИ-НЕ"):
                break;
            case ("Вход"):
                break;
            case ("Выход"):
                break;
            case ("Коннектор"):
                break;
            case ("BUF"):
                break;
            case ("INV"):
                break;
            case ("AND"):
                break;
            case ("NAND"):
                break;
            case ("OR"):
                break;
            case ("NOR"):
                break;
            case ("XOR"):
                break;
            case ("XNOR"):
                break;
            case ("IN"):
                break;
            case ("OUT"):
                break;
            case ("Connector"):
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