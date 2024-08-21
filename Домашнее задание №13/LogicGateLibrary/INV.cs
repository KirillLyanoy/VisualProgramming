using System.Globalization;
using Avalonia;
using Avalonia.Media;

namespace LogicGateLibrary
{
    public class INV : LogicGate
    {
        public INV(Standart standart) : base(standart) { }
        private bool _valueIn = false;
        public bool ValueIn
        {
            get { return _valueIn; }
            set
            {
                _valueIn = value;
                UpdateConnectorValue();
            }
        }
        public bool ValueOut { get; set; } = false;
        public sealed override void Render(DrawingContext context)
        {
            base.Render(context);
            Pen pen = new Pen(Brushes.Black, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10);
            IBrush valueBrushIn;
            IBrush valueBrushOut;
            if (ValueIn) valueBrushIn = Brushes.Lime;
            else valueBrushIn = Brushes.Green;
            if (ValueOut) valueBrushOut = Brushes.Lime;
            else valueBrushOut = Brushes.Green;

            switch (Standart)
            {
                case (Standart.GOST):
                    if (IsSelected)
                        context.DrawRectangle(Brushes.Transparent, new Pen(Brushes.Black, 2, DashStyle.DashDotDot, PenLineCap.Flat, PenLineJoin.Miter, 10), new Rect(new Point(StartPoint.X - 10, StartPoint.Y - 10), new Size(80, 120)));
                                       
                    context.DrawRectangle(Brushes.White, pen, new Rect(new Point(StartPoint.X, StartPoint.Y), new Size(50, 100)));
                    context.DrawText(new FormattedText("1", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface.Default, 15, Brushes.Black), new Point(StartPoint.X + 20, StartPoint.Y + 20));
                    context.DrawEllipse(Brushes.White, pen, new Rect(new Point(StartPoint.X + 44, StartPoint.Y + 44), new Size(12, 12)));
                    if (Label != null)
                    {
                        context.DrawText(new FormattedText(Label, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(LabelFont, FontStyle.Normal, FontWeight.Normal, FontStretch.Normal), 15, Brushes.Black), new Point(StartPoint.X + 10, StartPoint.Y + 110));
                    }

                    FirstInPoint = new(StartPoint.X, StartPoint.Y + 50);
                    OutPoint = new(StartPoint.X + 60, StartPoint.Y + 50);
                    context.DrawEllipse(valueBrushIn, null, FirstInPoint, 4, 4);
                    context.DrawEllipse(valueBrushIn, null, OutPoint, 4, 4);

                    break;
                case (Standart.ANSI):
                    if (IsSelected)
                        context.DrawRectangle(Brushes.Transparent, new Pen(Brushes.Black, 2, DashStyle.DashDotDot, PenLineCap.Flat, PenLineJoin.Miter, 10), new Rect(new Point(StartPoint.X - 10, StartPoint.Y - 10), new Size(77, 120)));

                    var figure = new PathFigure
                    {
                        StartPoint = StartPoint,
                        IsClosed = true
                    };
                    figure.Segments.Add(new LineSegment
                    {
                        Point = new Point(StartPoint.X, StartPoint.Y + 100)
                    });
                    figure.Segments.Add(new LineSegment
                    {
                        Point = new Point(StartPoint.X + 55, StartPoint.Y + 50)
                    });
                    figure.Segments.Add(new LineSegment
                    {
                        Point = new Point(StartPoint.X, StartPoint.Y)
                    });
                    var geometry = new PathGeometry();
                    geometry.Figures.Add(figure);
                    context.DrawGeometry(Brushes.White, pen, geometry);
                    context.DrawEllipse(Brushes.White, pen, new Rect(new Point(StartPoint.X + 53, StartPoint.Y + 44), new Size(12, 12)));
                    if (Label != null)
                    {
                        context.DrawText(new FormattedText(Label, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(LabelFont, FontStyle.Normal, FontWeight.Normal, FontStretch.Normal), 15, Brushes.Black), new Point(StartPoint.X + 10, StartPoint.Y + 110));
                    }

                    FirstInPoint = new(StartPoint.X, StartPoint.Y + 50);
                    OutPoint = new(StartPoint.X + 70, StartPoint.Y + 50);
                    context.DrawEllipse(valueBrushIn, null, FirstInPoint, 4, 4);
                    context.DrawEllipse(valueBrushIn, null, OutPoint, 4, 4);

                    break;
                default:
                    break;
            }
        }
        private void UpdateConnectorValue()
        {
            ValueOut = ValueIn;
            if (Out != null) Out.Value = !ValueOut;

            RenderTransform = new TranslateTransform();
        }
    }
}
