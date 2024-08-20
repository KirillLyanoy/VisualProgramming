using Avalonia.Media;
using Avalonia;
using System.Collections.ObjectModel;

namespace LogicGateLibrary
{
    public class Connector : LogicGate
    {
        public Connector() { }
        public Connector(Point point)
        {
            StartPoint = point;
            EndPoint = point;
        }    
        public ObservableCollection<LogicGate> Connections { get; set; } = new();
        public bool ValueIn { get; set; } = false;
        public bool ValueOut { get; set; } = false;
        public Avalonia.Point EndPoint { get; set; } = new Point(100, 50);
        public sealed override void Render(DrawingContext context)
        {
            base.Render(context);
          
            IBrush currentBrush;
            if (ValueIn) currentBrush = Brushes.Lime;
            else currentBrush = Brushes.Green;           
            if (IsSelected) currentBrush = Brushes.Red;
            IBrush? brush;

            context.DrawLine(new Pen(currentBrush, 3, null, PenLineCap.Flat, PenLineJoin.Bevel, 10), StartPoint, EndPoint);
        }
    }
}
