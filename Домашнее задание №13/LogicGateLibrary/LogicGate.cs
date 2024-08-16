using Avalonia.Controls;
using System.Collections.ObjectModel;
using Avalonia.Media;

namespace LogicGateLibrary
{
    public enum Standart
    {
        GOST,
        ANSI
    }  
    public abstract class LogicGate : Control
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
    }
}
