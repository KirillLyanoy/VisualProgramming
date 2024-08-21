using System.Collections.ObjectModel;
using System.Globalization;
using Avalonia;
using Avalonia.Media;

namespace LogicGateLibrary
{
    public class NAND : LogicGate
    {
        public NAND(Standart standart) : base(standart)
        {
            ValueIn.CollectionChanged += UpdateConnectorsValue;
        }
        public ObservableCollection<bool> ValueIn = new ObservableCollection<bool>() { false, false };
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
                        context.DrawRectangle(Brushes.Transparent, new Pen(Brushes.Black, 2, DashStyle.DashDotDot, PenLineCap.Flat, PenLineJoin.Miter, 10), new Rect(new Point(StartPoint.X - 10, StartPoint.Y - 10), new Size(77, 120)));

                    context.DrawRectangle(Brushes.White, pen, new Rect(new Point(StartPoint.X, StartPoint.Y), new Size(50, 100)));
                    context.DrawEllipse(Brushes.White, pen, new Rect(new Point(StartPoint.X + 44, StartPoint.Y + 44), new Size(12, 12)));
                    context.DrawText(new FormattedText("&", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface.Default, 15, Brushes.Black), new Point(StartPoint.X + 20, StartPoint.Y + 20));
                    if (Label != null)
                    {
                        context.DrawText(new FormattedText(Label, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(LabelFont, FontStyle.Normal, FontWeight.Normal, FontStretch.Normal), 15, Brushes.Black), new Point(StartPoint.X + 10, StartPoint.Y + 110));
                    }

                    FirstInPoint = new(StartPoint.X, StartPoint.Y + 20);
                    SecondInPoint = new(StartPoint.X, StartPoint.Y + 80);
                    OutPoint = new(StartPoint.X + 60, StartPoint.Y + 50);
                    context.DrawEllipse(valueBrush0, null, FirstInPoint, 4, 4);
                    context.DrawEllipse(valueBrush1, null, SecondInPoint, 4, 4);
                    context.DrawEllipse(valueBrushOut, null, OutPoint, 4, 4);

                    break;
                case (Standart.ANSI):
                    if (IsSelected)
                        context.DrawRectangle(Brushes.Transparent, new Pen(Brushes.Black, 2, DashStyle.DashDotDot, PenLineCap.Flat, PenLineJoin.Miter, 10), new Rect(new Point(StartPoint.X - 10, StartPoint.Y - 10), new Size(108, 120)));

                    context.DrawEllipse(Brushes.White, pen, new Rect(new Point(StartPoint.X, StartPoint.Y + 10), new Size(80, 80)));
                    context.DrawRectangle(Brushes.White, new Pen(Brushes.White, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10), new Rect(new Point(StartPoint.X, StartPoint.Y + 10), new Size(40, 80)));
                    Point point_1 = new Point(StartPoint.X, StartPoint.Y + 10);
                    Point point_2 = new Point(StartPoint.X, StartPoint.Y + 90);
                    Point point_3 = new Point(StartPoint.X + 41, StartPoint.Y + 10);
                    Point point_4 = new Point(StartPoint.X + 41, StartPoint.Y + 90);
                    context.DrawLine(pen, point_1, point_2);
                    context.DrawLine(pen, point_1, point_3);
                    context.DrawLine(pen, point_2, point_4);
                    context.DrawEllipse(Brushes.White, pen, new Rect(new Point(StartPoint.X + 75, StartPoint.Y + 44), new Size(12, 12)));
                    if (Label != null)
                    {
                        context.DrawText(new FormattedText(Label, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(LabelFont, FontStyle.Normal, FontWeight.Normal, FontStretch.Normal), 15, Brushes.Black), new Point(StartPoint.X + 10, StartPoint.Y + 110));
                    }

                    FirstInPoint = new(StartPoint.X, StartPoint.Y + 20);
                    SecondInPoint = new(StartPoint.X, StartPoint.Y + 80);
                    OutPoint = new(StartPoint.X + 90, StartPoint.Y + 50);
                    context.DrawEllipse(valueBrush0, null, FirstInPoint, 4, 4);
                    context.DrawEllipse(valueBrush1, null, SecondInPoint, 4, 4);
                    context.DrawEllipse(valueBrushOut, null, OutPoint, 4, 4);

                    break;
                default:
                    break;
            }
        }
        private void UpdateConnectorsValue(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (ValueIn[0] && ValueIn[1]) ValueOut = false;
            else ValueOut = true;
            if (Out != null) Out.Value = ValueOut;

            RenderTransform = new TranslateTransform();
        }
    }
}
