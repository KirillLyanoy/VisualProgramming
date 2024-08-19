using System.Collections.ObjectModel;
using System.Globalization;
using Avalonia;
using Avalonia.Media;

namespace LogicGateLibrary
{
    public class AND : LogicGate
    {
        public AND(Standart standart) : base(standart) { }
        public Collection<bool> ValueIn = new Collection<bool>() { false, false };
        public bool ValueOut { get; set; } = false;

        public sealed override void Render(DrawingContext context)
        {
            base.Render(context);
            Pen pen = new Pen(Brushes.Black, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10);

            IBrush valueBrush0;
            IBrush valueBrush1;
            IBrush valueBrushOut;
            if (ValueIn[0]) valueBrush0 = Brushes.Lime;
            else valueBrush0 = Brushes.Green;
            if (ValueIn[1]) valueBrush1 = Brushes.Lime;
            else valueBrush1 = Brushes.Green;
            if (ValueOut) valueBrushOut = Brushes.Lime;
            else valueBrushOut = Brushes.Green;


            switch (Standart)
            {                
                case (Standart.GOST):
                    if (IsSelected)
                        context.DrawRectangle(Brushes.Transparent, new Pen(Brushes.Black, 2, DashStyle.DashDotDot, PenLineCap.Flat, PenLineJoin.Miter, 10), new Rect(new Point(StartPoint.X - 10, StartPoint.Y - 10), new Size(70, 120)));

                     context.DrawRectangle(Brushes.White, pen, new Rect(new Point(StartPoint.X, StartPoint.Y), new Size(50, 100)));
                    context.DrawText(new FormattedText("&", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface.Default, 15, Brushes.Black), new Point(StartPoint.X + 20, StartPoint.Y + 20));
                    if (Label != null)
                    {
                        context.DrawText(new FormattedText(Label, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(LabelFont, FontStyle.Normal, FontWeight.Normal, FontStretch.Normal), 15, Brushes.Black), new Point(StartPoint.X + 10, StartPoint.Y + 110));
                    }
                    context.DrawEllipse(valueBrush0, null, new Rect(StartPoint.X - 9, StartPoint.Y + 21, 8, 8));
                    context.DrawEllipse(valueBrush1, null, new Rect(StartPoint.X - 9, StartPoint.Y + 71, 8, 8));
                    context.DrawEllipse(valueBrushOut, null, new Rect(StartPoint.X + 51, StartPoint.Y + 46, 8, 8));

                    FirstInPoint = new(StartPoint.X - 5, StartPoint.Y + 25);
                    SecondInPoint = new(StartPoint.X - 5, StartPoint.Y + 75);
                    OutPoint = new(StartPoint.X + 55, StartPoint.Y + 50);

                    break;
                case (Standart.ANSI):
                    if (IsSelected)
                        context.DrawRectangle(Brushes.Transparent, new Pen(Brushes.Black, 2, DashStyle.DashDotDot, PenLineCap.Flat, PenLineJoin.Miter, 10), new Rect(new Point(StartPoint.X - 10, StartPoint.Y - 10), new Size(100, 120)));

                    context.DrawEllipse(Brushes.White, pen, new Rect(new Point(StartPoint.X, StartPoint.Y + 10), new Size(80, 80)));
                    context.DrawRectangle(Brushes.White, new Pen(Brushes.White, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10), new Rect(new Point(StartPoint.X, StartPoint.Y + 10), new Size(40, 80)));
                    Point point_1 = new Point(StartPoint.X, StartPoint.Y + 10);
                    Point point_2 = new Point(StartPoint.X, StartPoint.Y + 90);
                    Point point_3 = new Point(StartPoint.X + 41, StartPoint.Y + 10);
                    Point point_4 = new Point(StartPoint.X + 41, StartPoint.Y + 90);
                    context.DrawLine(pen, point_1, point_2);
                    context.DrawLine(pen, point_1, point_3);
                    context.DrawLine(pen, point_2, point_4);
                    if (Label != null)
                    {
                        context.DrawText(new FormattedText(Label, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(LabelFont, FontStyle.Normal, FontWeight.Normal, FontStretch.Normal), 15, Brushes.Black), new Point(StartPoint.X + 10, StartPoint.Y + 110));
                    }
                    context.DrawEllipse(valueBrush0, null, new Rect(StartPoint.X - 9, StartPoint.Y + 21, 8, 8));
                    context.DrawEllipse(valueBrush1, null, new Rect(StartPoint.X - 9, StartPoint.Y + 71, 8, 8));
                    context.DrawEllipse(valueBrushOut, null, new Rect(StartPoint.X + 81, StartPoint.Y + 46, 8, 8));

                    FirstInPoint = new(StartPoint.X - 5, StartPoint.Y + 25);
                    SecondInPoint = new(StartPoint.X - 5, StartPoint.Y + 75);
                    OutPoint = new(StartPoint.X + 90, StartPoint.Y + 50);
                    break;
                default:
                    break;
            }
        }
    }
}
