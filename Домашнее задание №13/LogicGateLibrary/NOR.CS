using System.Collections.ObjectModel;
using System.Globalization;
using Avalonia;
using Avalonia.Media;

namespace LogicGateLibrary
{
    public class NOR : LogicGate
    {
        public Collection<bool> ValueIn = new Collection<bool>();
        public sealed override void Render(DrawingContext context)
        {
            base.Render(context);
            Point startPoint = new Point(100, 100);
            if (IsSelected)
                context.DrawRectangle(Brushes.White, new Pen(Brushes.Black, 2, DashStyle.DashDotDot, PenLineCap.Flat, PenLineJoin.Miter, 10), new Rect(new Point(startPoint.X - 60, startPoint.Y - 10), new Size(180, 120)));

            switch (Standart)
            {
                case (Standart.GOST):
                    context.DrawLine(new Pen(Brushes.Black, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10), new Point(startPoint.X - 50, startPoint.Y + 25), new Point(startPoint.X, startPoint.Y + 25));
                    context.DrawLine(new Pen(Brushes.Black, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10), new Point(startPoint.X - 50, startPoint.Y + 75), new Point(startPoint.X, startPoint.Y + 75));
                    context.DrawLine(new Pen(Brushes.Black, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10), new Point(startPoint.X + 50, startPoint.Y + 50), new Point(startPoint.X + 100, startPoint.Y + 50));
                    context.DrawRectangle(Brushes.White, new Pen(Brushes.Black, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10), new Rect(new Point(startPoint.X, startPoint.Y), new Size(50, 100)));
                    context.DrawEllipse(Brushes.White, new Pen(Brushes.Black, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10), new Rect(new Point(startPoint.X + 50, startPoint.Y + 46), new Size(8, 8)));
                    context.DrawText(new FormattedText("1", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface.Default, 15, Brushes.Black), new Point(startPoint.X + 20, startPoint.Y + 20));
                    if (Label != null)
                    {
                        context.DrawText(new FormattedText(Label, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(LabelFont, FontStyle.Normal, FontWeight.Normal, FontStretch.Normal), 15, Brushes.Black), new Point(startPoint.X + 10, startPoint.Y + 110));
                    }
                    break;
                case (Standart.ANSI):
                    context.DrawLine(new Pen(Brushes.Black, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10), new Point(startPoint.X - 50, startPoint.Y + 25), new Point(startPoint.X, startPoint.Y + 25));
                    context.DrawLine(new Pen(Brushes.Black, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10), new Point(startPoint.X - 50, startPoint.Y + 75), new Point(startPoint.X, startPoint.Y + 75));
                    context.DrawLine(new Pen(Brushes.Black, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10), new Point(startPoint.X + 50, startPoint.Y + 50), new Point(startPoint.X + 100, startPoint.Y + 50));
                    var figure = new PathFigure
                    {
                        StartPoint = startPoint,
                        IsClosed = false
                    };
                    figure.Segments.Add(new ArcSegment
                    {
                        Point = new Point(startPoint.X + 75, startPoint.Y + 50),
                        Size = new Size(80, 80),
                    });
                    figure.Segments.Add(new ArcSegment
                    {
                        Point = new Point(startPoint.X, startPoint.Y + 100),
                        Size = new Size(80, 80),
                    });
                    figure.Segments.Add(new LineSegment
                    {
                        Point = new Point(startPoint.X - 20, startPoint.Y + 100)
                    });
                    figure.Segments.Add(new ArcSegment
                    {
                        Point = new Point(startPoint.X - 20, startPoint.Y),
                        Size = new Size(100, 100),
                        SweepDirection = SweepDirection.CounterClockwise
                    });
                    figure.Segments.Add(new LineSegment
                    {
                        Point = new Point(startPoint.X, startPoint.Y)
                    });
                    var geometry = new PathGeometry();
                    geometry.Figures.Add(figure);
                    context.DrawGeometry(Brushes.White, new Pen(Brushes.Black, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10), geometry);
                    context.DrawEllipse(Brushes.White, new Pen(Brushes.Black, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10), new Rect(new Point(startPoint.X + 75, startPoint.Y + 46), new Size(8, 8)));
                    if (Label != null)
                    {
                        context.DrawText(new FormattedText(Label, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(LabelFont, FontStyle.Normal, FontWeight.Normal, FontStretch.Normal), 15, Brushes.Black), new Point(startPoint.X + 10, startPoint.Y + 110));
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
