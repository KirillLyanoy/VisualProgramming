using System.Globalization;
using Avalonia;
using Avalonia.Media;

namespace LogicGateLibrary
{
    public class INV : LogicGate
    {
        public INV(Standart standart) : base(standart) { }
        public bool ValueIn { get; set; }
        public sealed override void Render(DrawingContext context)
        {
            base.Render(context);
            Point startPoint = new Point(100, 100);
            if (IsSelected)
                context.DrawRectangle(Brushes.White, new Pen(Brushes.Black, 2, DashStyle.DashDotDot, PenLineCap.Flat, PenLineJoin.Miter, 10), new Rect(new Point(startPoint.X - 60, startPoint.Y - 10), new Size(180, 120)));

            switch (Standart)
            {
                case (Standart.GOST):
                    context.DrawLine(new Pen(Brushes.Black, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10), new Point(startPoint.X - 50, startPoint.Y + 50), new Point(startPoint.X + 100, startPoint.Y + 50));
                    context.DrawRectangle(Brushes.White, new Pen(Brushes.Black, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10), new Rect(new Point(startPoint.X, startPoint.Y), new Size(50, 100)));
                    context.DrawText(new FormattedText("1", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface.Default, 15, Brushes.Black), new Point(startPoint.X + 20, startPoint.Y + 20));
                    context.DrawEllipse(Brushes.White, new Pen(Brushes.Black, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10), new Rect(new Point(startPoint.X + 50, startPoint.Y + 46), new Size(8, 8)));
                    if (Label != null)
                    {
                        context.DrawText(new FormattedText(Label, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(LabelFont, FontStyle.Normal, FontWeight.Normal, FontStretch.Normal), 15, Brushes.Black), new Point(startPoint.X + 10, startPoint.Y + 110));
                    }
                    break;
                case (Standart.ANSI):
                    context.DrawLine(new Pen(Brushes.Black, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10), new Point(startPoint.X - 50, startPoint.Y + 50), new Point(startPoint.X, startPoint.Y + 50));
                    context.DrawLine(new Pen(Brushes.Black, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10), new Point(startPoint.X + 50, startPoint.Y + 50), new Point(startPoint.X + 100, startPoint.Y + 50));
                    context.DrawLine(new Pen(Brushes.Black, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10), new Point(startPoint.X, startPoint.Y), new Point(startPoint.X, startPoint.Y + 100));
                    context.DrawLine(new Pen(Brushes.Black, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10), new Point(startPoint.X, startPoint.Y + 100), new Point(startPoint.X + 50, startPoint.Y + 50));
                    context.DrawLine(new Pen(Brushes.Black, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10), new Point(startPoint.X + 50, startPoint.Y + 50), new Point(startPoint.X, startPoint.Y));
                    context.DrawEllipse(Brushes.White, new Pen(Brushes.Black, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10), new Rect(new Point(startPoint.X + 50, startPoint.Y + 46), new Size(8, 8)));
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
