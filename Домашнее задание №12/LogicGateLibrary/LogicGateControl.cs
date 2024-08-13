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
    internal class LogicGateControl : Control
    {
        public Collection<short> ValueIn = new Collection<short>();
        public short ValueOut { get; }
        public Standart Standart { get; set; } = Standart.GOST;
        public string Label { get; set; }
        public FontFamily LabelFont { get; set; } = FontFamily.Default;
        public bool IsSelected { get; set; } = false;
    }
}
