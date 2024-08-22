using Avalonia.Media;
using Avalonia;
using System.Globalization;

namespace LogicGateLibrary
{
    public class OUT : LogicGate
    {
        public OUT() 
        {
            StartPoint = new Point(100, 50);
        }
        private bool _valueIn = false;
        public bool ValueIn
        {
            get { return _valueIn; }
            set
            {
                _valueIn = value;
                ValueOut = ValueIn;
                RenderTransform = new TranslateTransform();
            }
        }
        private Point _startPoint;
        public override Point StartPoint
        {
            get { return _startPoint; }
            set
            {
                _startPoint = value;
                FirstInPoint = new(StartPoint.X, StartPoint.Y + 20);
            }
        }
        public override bool ValueOut { get; set; }
        public sealed override void Render(DrawingContext context)
        {
            base.Render(context);
            Pen pen = new Pen(Brushes.Black, 2, null, PenLineCap.Flat, PenLineJoin.Miter, 10);
            IBrush currentBrush;
            if (ValueIn) currentBrush = Brushes.Lime;
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

            if (ValueOut) context.DrawText(new FormattedText("1", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(LabelFont, FontStyle.Normal, FontWeight.Normal, FontStretch.Normal), 15, Brushes.Black), new Point(StartPoint.X + 26, StartPoint.Y + 10));
            else context.DrawText(new FormattedText("0", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(LabelFont, FontStyle.Normal, FontWeight.Normal, FontStretch.Normal), 15, Brushes.Black), new Point(StartPoint.X + 26, StartPoint.Y + 10));
            context.DrawText(new FormattedText("b", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(LabelFont, FontStyle.Normal, FontWeight.Normal, FontStretch.Normal), 15, Brushes.Blue), new Point(StartPoint.X + 42, StartPoint.Y + 17));
            if (Label != null)
            {
                context.DrawText(new FormattedText(Label, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(LabelFont, FontStyle.Normal, FontWeight.Normal, FontStretch.Normal), 15, Brushes.Black), new Point(StartPoint.X + 10, StartPoint.Y + 44));
            }            
            context.DrawEllipse(currentBrush, null, FirstInPoint, 4, 4);
        }
    }
}
