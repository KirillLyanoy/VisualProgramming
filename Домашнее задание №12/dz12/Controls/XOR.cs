using System.Drawing.Drawing2D;
using System.Globalization;
using Avalonia;
using Avalonia.Media;
namespace dz12.Controls
{
    internal class XOR : LogicGateControl
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
                    context.DrawText(new FormattedText("=1", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface.Default, 15, Brushes.Black), new Point(startPoint.X + 17, startPoint.Y + 20));
                    if (Label != null)
                    {
                        context.DrawText(new FormattedText(Label, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(LabelFont, FontStyle.Normal, FontWeight.Normal, FontStretch.Normal), 15, Brushes.Black), new Point(startPoint.X + 10, startPoint.Y + 110));
                    }
                    break;
                case (Standart.ANSI):



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
