using Avalonia.Controls;
using Avalonia.Media;
using Avalonia;

namespace LogicGateLibrary
{
    public enum Standart
    {
        GOST,
        ANSI
    }
    public abstract class LogicGate : Control
    {
        public LogicGate() { }
        public LogicGate(Standart standart)
        {
            Standart = standart;
        }
        public FontFamily LabelFont { get; set; } = FontFamily.Default;
        public string Label { get; set; }
        public Standart Standart { get; set; } = Standart.GOST;
        public bool IsSelected { get; set; } = false;  
        public Point StartPoint { get; set; } = new Point(100, 50);
    }
}
