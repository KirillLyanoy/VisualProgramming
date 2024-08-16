using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using System;
using System.Collections.ObjectModel;

namespace dz13.Control;

public class GateList : TemplatedControl
{
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

        _radioButton1.Click += RadioButton_Click;
        _radioButton2.Click += RadioButton_Click;
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