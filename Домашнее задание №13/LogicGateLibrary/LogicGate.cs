using Avalonia.Controls;
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

        public Point FirstInPoint { get; set; }
        public Point SecondInPoint { get; set; }
        public Point OutPoint { get; set; }

        public LogicGate FirstIn { get; set; }
        public LogicGate SecondIn { get; set; }
        public LogicGate Out { get; set; }
    }
}
