using Avalonia.Controls;
using System.Collections.ObjectModel;
using Avalonia.Media;
using Avalonia;
using Avalonia.Controls.Primitives;

namespace LogicGateLibrary
{
    public enum Standart
    {
        GOST,
        ANSI
    }  
    public abstract class LogicGate : TemplatedControl
    {
        public bool ValueOut { get; }
        public Standart Standart { get; set; } = Standart.GOST;
        public string Label { get; set; }
        public FontFamily LabelFont { get; set; } = FontFamily.Default;
        public bool IsSelected { get; set; } = false;        
        public LogicGate(Standart standart)
        {
            Standart = standart;
        }
        public LogicGate() { }



        public static StyledProperty<bool> IsSelected1 = Avalonia.AvaloniaProperty.Register<LogicGate, bool>(nameof(Selected1));
        public bool Selected1
        {
            get => GetValue(IsSelected1);
            set => SetValue(IsSelected1, value);
        }


    }
}
