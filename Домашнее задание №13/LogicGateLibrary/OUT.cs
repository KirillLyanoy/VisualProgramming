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
        public bool ValueIn { get; set; }
        public sealed override void Render(DrawingContext context)
        {
            base.Render(context);
            IBrush currentBrush;
            if (ValueIn) currentBrush = Brushes.Lime;
            else currentBrush = Brushes.Green;
            Point startPoint = new Point(100, 100);
            if (IsSelected)
                context.DrawRectangle(Brushes.White, new Pen(Brushes.Black, 2, DashStyle.DashDotDot, PenLineCap.Flat, PenLineJoin.Miter, 10), new Rect(new Point(startPoint.X - 25, startPoint.Y - 10), new Size(110, 50)));
            context.DrawLine(new Pen(Brushes.Black, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10), startPoint, new Point(startPoint.X + 50, startPoint.Y));
            context.DrawLine(new Pen(Brushes.Black, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10), new Point(startPoint.X + 50, startPoint.Y), new Point(startPoint.X + 75, startPoint.Y + 15));
            context.DrawLine(new Pen(Brushes.Black, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10), new Point(startPoint.X + 75, startPoint.Y + 15), new Point(startPoint.X + 50, startPoint.Y + 30));
            context.DrawLine(new Pen(Brushes.Black, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10), new Point(startPoint.X + 50, startPoint.Y + 30), new Point(startPoint.X, startPoint.Y + 30));
            context.DrawLine(new Pen(Brushes.Black, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10), new Point(startPoint.X, startPoint.Y + 30), new Point(startPoint.X, startPoint.Y));
            context.DrawLine(new Pen(currentBrush, 2), new Point(startPoint.X, startPoint.Y + 15), new Point(startPoint.X - 20, startPoint.Y + 15));            
            if (ValueIn) context.DrawText(new FormattedText("1", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(LabelFont, FontStyle.Normal, FontWeight.Normal, FontStretch.Normal), 15, Brushes.Black), new Point(startPoint.X + 26, startPoint.Y + 7));
            else context.DrawText(new FormattedText("0", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(LabelFont, FontStyle.Normal, FontWeight.Normal, FontStretch.Normal), 15, Brushes.Black), new Point(startPoint.X + 26, startPoint.Y + 7));
            context.DrawText(new FormattedText("b", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(LabelFont, FontStyle.Normal, FontWeight.Normal, FontStretch.Normal), 15, Brushes.Blue), new Point(startPoint.X + 42, startPoint.Y + 15));
            if (Label != null)
            {
                context.DrawText(new FormattedText(Label, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(LabelFont, FontStyle.Normal, FontWeight.Normal, FontStretch.Normal), 15, Brushes.Black), new Point(startPoint.X + 10, startPoint.Y + 44));
            }
        }
    }
}
