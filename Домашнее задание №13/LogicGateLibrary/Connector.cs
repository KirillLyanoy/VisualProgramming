using Avalonia.Media;
using Avalonia;
using System.Collections.ObjectModel;

namespace LogicGateLibrary
{
    public class Connector : LogicGate
    {
        public Connector() { }
        public Connector(Point startPoint, Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }    
        public ObservableCollection<LogicGate> Connections { get; set; } = new();
        public bool Value { get; set; } = false;
        public Avalonia.Point EndPoint { get; set; } = new Point(100, 50);
        public sealed override void Render(DrawingContext context)
        {
            base.Render(context);
          
            IBrush currentBrush;
            if (Value) currentBrush = Brushes.Lime;
            else currentBrush = Brushes.Green;           
            if (IsSelected) currentBrush = Brushes.Red;
            IBrush? brush;

            context.DrawLine(new Pen(currentBrush, 3, null, PenLineCap.Flat, PenLineJoin.Bevel, 10), StartPoint, EndPoint);
        }

        public void UpdateValue()
        {
            foreach (var item in Connections)
            {

            }
        }


    }
}
