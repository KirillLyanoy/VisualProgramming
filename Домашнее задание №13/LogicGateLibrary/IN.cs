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
    public class IN : LogicGate
    {
        public IN() { }
        private bool _valueOut = false;
        public override bool ValueOut
        {
            get { return _valueOut; }
            set
            {
                _valueOut = value;
                UpdateConnectorsValue();
            }
        }
        public sealed override void Render(DrawingContext context)
        {
            base.Render(context);
            Pen pen = new Pen(Brushes.Black, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10);
            IBrush currentBrush;
            if (ValueOut) currentBrush = Brushes.Lime;
            else currentBrush = Brushes.Green;
            if (IsSelected)
                context.DrawRectangle(Brushes.Transparent, new Pen(Brushes.Black, 2, DashStyle.DashDotDot, PenLineCap.Flat, PenLineJoin.Miter, 10), new Rect(new Point(StartPoint.X - 10, StartPoint.Y - 10), new Size(100, 60)));
          
            var figure = new PathFigure
            {
                StartPoint = StartPoint,
                IsClosed = true
            };
            figure.Segments.Add(new LineSegment
            {
                Point = new Point(StartPoint.X + 50, StartPoint.Y)
            });
            figure.Segments.Add(new LineSegment
            {
                Point = new Point(StartPoint.X + 78, StartPoint.Y + 20)
            });
            figure.Segments.Add(new LineSegment
            {
                Point = new Point(StartPoint.X + 50, StartPoint.Y + 40)
            });
            figure.Segments.Add(new LineSegment
            {
                Point = new Point(StartPoint.X, StartPoint.Y + 40)
            });
            figure.Segments.Add(new LineSegment
            {
                Point = new Point(StartPoint.X, StartPoint.Y)
            });
            var geometry = new PathGeometry();
            geometry.Figures.Add(figure);
            context.DrawGeometry(Brushes.White, pen, geometry);

            context.DrawEllipse(currentBrush, null, new Rect(new Point(StartPoint.X + 20, StartPoint.Y + 6), new Point(StartPoint.X + 40, StartPoint.Y + 33)));

            if (ValueOut) context.DrawText(new FormattedText("1", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(LabelFont, FontStyle.Normal, FontWeight.Normal, FontStretch.Normal), 15, Brushes.Black), new Point(StartPoint.X + 26, StartPoint.Y + 10));
            else context.DrawText(new FormattedText("0", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(LabelFont, FontStyle.Normal, FontWeight.Normal, FontStretch.Normal), 15, Brushes.Black), new Point(StartPoint.X + 26, StartPoint.Y + 10));
            context.DrawText(new FormattedText("b", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(LabelFont, FontStyle.Normal, FontWeight.Normal, FontStretch.Normal), 15, Brushes.Blue), new Point(StartPoint.X + 42, StartPoint.Y + 17));
            if (Label != null)
            {
                context.DrawText(new FormattedText(Label, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(LabelFont, FontStyle.Normal, FontWeight.Normal, FontStretch.Normal), 15, Brushes.Black), new Point(StartPoint.X + 10, StartPoint.Y + 44));
            }
            OutPoint = new(StartPoint.X + 80, StartPoint.Y + 20);
            context.DrawEllipse(currentBrush, null, OutPoint, 4, 4);            
        }   
        public void UpdateConnectorsValue()
        {
            if (Out != null)
            {
                Connector connector = Out as Connector;
                Out.SetNewValue(this, ValueOut);
            }       
        }
    }
}
