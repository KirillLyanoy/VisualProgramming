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
    public class OUT : LogicGate
    {
        public OUT() { }     
        public bool ValueIn { get; set; } = false;
        public sealed override void Render(DrawingContext context)
        {
            base.Render(context);
            Pen pen = new Pen(Brushes.Black, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10);
            IBrush currentBrush;
            if (ValueIn) currentBrush = Brushes.Lime;
            else currentBrush = Brushes.Green;
            if (IsSelected)
                context.DrawRectangle(Brushes.Transparent, new Pen(Brushes.Black, 2, DashStyle.DashDotDot, PenLineCap.Flat, PenLineJoin.Miter, 10), new Rect(new Point(StartPoint.X - 15, StartPoint.Y - 10), new Size(100, 50)));

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
                Point = new Point(StartPoint.X + 75, StartPoint.Y + 15)
            });
            figure.Segments.Add(new LineSegment
            {
                Point = new Point(StartPoint.X + 50, StartPoint.Y + 30)
            });
            figure.Segments.Add(new LineSegment
            {
                Point = new Point(StartPoint.X, StartPoint.Y + 30)
            });
            figure.Segments.Add(new LineSegment
            {
                Point = new Point(StartPoint.X, StartPoint.Y)
            });
            var geometry = new PathGeometry();
            geometry.Figures.Add(figure);
            context.DrawGeometry(Brushes.White, pen, geometry);

            if (ValueIn) context.DrawText(new FormattedText("1", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(LabelFont, FontStyle.Normal, FontWeight.Normal, FontStretch.Normal), 15, Brushes.Black), new Point(StartPoint.X + 26, StartPoint.Y + 5));
            else context.DrawText(new FormattedText("0", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(LabelFont, FontStyle.Normal, FontWeight.Normal, FontStretch.Normal), 15, Brushes.Black), new Point(StartPoint.X + 26, StartPoint.Y + 5));
            context.DrawText(new FormattedText("b", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(LabelFont, FontStyle.Normal, FontWeight.Normal, FontStretch.Normal), 15, Brushes.Blue), new Point(StartPoint.X + 42, StartPoint.Y + 12));
            if (Label != null)
            {
                context.DrawText(new FormattedText(Label, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(LabelFont, FontStyle.Normal, FontWeight.Normal, FontStretch.Normal), 15, Brushes.Black), new Point(StartPoint.X + 10, StartPoint.Y + 44));
            }

            context.DrawEllipse(currentBrush, null, new Rect(StartPoint.X - 9, StartPoint.Y + 11, 8, 8));
            FirstInPoint = new(StartPoint.X - 5, StartPoint.Y + 15);
        }
    }
}
