using Avalonia.Media;
using Avalonia;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGateLibrary
{
    public class Connector : LogicGate
    {
        public Connector() { }      
        public bool ValueIn { get; set; } = false;
        public bool ValueOut { get; set; } = false;
        public sealed override void Render(DrawingContext context)
        {
            base.Render(context);
            IBrush currentBrush;
            if (ValueIn) currentBrush = Brushes.Lime;
            else currentBrush = Brushes.Green;
            if (IsSelected) currentBrush = Brushes.Red;
            IBrush? brush;
            context.DrawEllipse(currentBrush, null, new Rect(StartPoint.X, StartPoint.Y, 8, 8));
            context.DrawEllipse(currentBrush, null, new Rect(StartPoint.X + 50, StartPoint.Y, 8, 8));
            context.DrawLine(new Pen(currentBrush, 4, null, PenLineCap.Flat, PenLineJoin.Miter, 10), new Point(StartPoint.X + 4, StartPoint.Y + 4), new Point(StartPoint.X + 54, StartPoint.Y + 4));
        }
    }
}
