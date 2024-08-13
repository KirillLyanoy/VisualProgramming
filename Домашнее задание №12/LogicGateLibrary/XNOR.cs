using System.Drawing.Drawing2D;
using System.Globalization;
using Avalonia;
using Avalonia.Media;
namespace LogicGateLibrary.Controls
{
    internal class XNOR : LogicGateControl
    {
        public sealed override void Render(DrawingContext context)
        {
            base.Render(context);
            Point startPoint = new Point(100, 100);
            switch (Standart)
            {
                case (Standart.GOST):
                    context.DrawLine(new Pen(Brushes.Black, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10), new Point(startPoint.X - 50, startPoint.Y + 25), new Point(startPoint.X, startPoint.Y + 25));
                    context.DrawLine(new Pen(Brushes.Black, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10), new Point(startPoint.X - 50, startPoint.Y + 75), new Point(startPoint.X, startPoint.Y + 75));
                    context.DrawLine(new Pen(Brushes.Black, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10), new Point(startPoint.X + 50, startPoint.Y + 50), new Point(startPoint.X + 100, startPoint.Y + 50));
                    context.DrawRectangle(Brushes.White, new Pen(Brushes.Black, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10), new Rect(new Point(startPoint.X, startPoint.Y), new Size(50, 100)));
                    context.DrawEllipse(Brushes.White, new Pen(Brushes.Black, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10), new Rect(new Point(startPoint.X + 50, startPoint.Y + 46), new Size(8, 8)));
                    context.DrawText(new FormattedText("=1", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface.Default, 15, Brushes.Black), new Point(startPoint.X + 17, startPoint.Y + 20));
                    if (Label != null)
                    {
                        context.DrawText(new FormattedText(Label, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(LabelFont, FontStyle.Normal, FontWeight.Normal, FontStretch.Normal), 15, Brushes.Black), new Point(startPoint.X + 10, startPoint.Y + 110));
                    }
                    break;
                case (Standart.ANSI):
                    context.DrawEllipse(Brushes.White, new Pen(Brushes.Black, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10), new Rect(new Point(startPoint.X, startPoint.Y + 10), new Size(80, 80)));
                    context.DrawRectangle(Brushes.White, new Pen(Brushes.White, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10), new Rect(new Point(startPoint.X, startPoint.Y + 10), new Size(40, 80)));

                    Point point_1 = new Point(startPoint.X, startPoint.Y + 10);
                    Point point_2 = new Point(startPoint.X, startPoint.Y + 90);
                    Point point_3 = new Point(startPoint.X + 41, startPoint.Y + 10);
                    Point point_4 = new Point(startPoint.X + 41, startPoint.Y + 90);

                    context.DrawLine(new Pen(Brushes.Red, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10), point_1, point_2);
                    context.DrawLine(new Pen(Brushes.Red, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10), point_1, point_3);
                    context.DrawLine(new Pen(Brushes.Red, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10), point_2, point_4);

                    context.DrawLine(new Pen(Brushes.Red, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10), new Point(startPoint.X - 50, startPoint.Y + 25), new Point(startPoint.X, startPoint.Y + 25));
                    context.DrawLine(new Pen(Brushes.Red, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10), new Point(startPoint.X - 50, startPoint.Y + 75), new Point(startPoint.X, startPoint.Y + 75));
                    context.DrawLine(new Pen(Brushes.Red, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10), new Point(startPoint.X + 80, startPoint.Y + 50), new Point(startPoint.X + 100, startPoint.Y + 50));
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
