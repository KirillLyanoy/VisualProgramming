﻿using System.Collections.ObjectModel;
using System.Globalization;
using Avalonia;
using Avalonia.Media;

namespace LogicGateLibrary
{
    public class XNOR : LogicGate
    {
        public XNOR(Standart standart) : base(standart)
        {
            ValueIn.CollectionChanged += UpdateConnectorsValue;
            StartPoint = new Point(100, 50);
            if (standart is Standart.GOST) CenterPoint = new Point(StartPoint.X + 25, StartPoint.Y + 50);
            else CenterPoint = new Point(StartPoint.X + 45, StartPoint.Y + 50);
        }
        public ObservableCollection<bool> ValueIn = new ObservableCollection<bool>() { false, false };
        private Point _startPoint;
        public override Point StartPoint
        {
            get { return _startPoint; }
            set
            {
                _startPoint = value;
                if (Standart == Standart.GOST)
                {
                    FirstInPoint = new(StartPoint.X, StartPoint.Y + 20);
                    SecondInPoint = new(StartPoint.X, StartPoint.Y + 80);
                    OutPoint = new(StartPoint.X + 60, StartPoint.Y + 50);
                }
                else if (Standart == Standart.ANSI)
                {
                    FirstInPoint = new(StartPoint.X - 20, StartPoint.Y + 20);
                    SecondInPoint = new(StartPoint.X - 20, StartPoint.Y + 80);
                    OutPoint = new(StartPoint.X + 90, StartPoint.Y + 50);
                }
                if (this.Standart is Standart.GOST) CenterPoint = new Point(StartPoint.X + 25, StartPoint.Y + 50);
                else CenterPoint = new Point(StartPoint.X + 45, StartPoint.Y + 50);
            }
        }
        public override bool ValueOut { get; set; } = false;
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
                    context.DrawText(new FormattedText("=1", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface.Default, 15, Brushes.Black), new Point(StartPoint.X + 17, StartPoint.Y + 20));
                    if (Label != null)
                    {
                        context.DrawText(new FormattedText(Label, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(LabelFont, FontStyle.Normal, FontWeight.Normal, FontStretch.Normal), 15, Brushes.Black), new Point(StartPoint.X + 10, StartPoint.Y + 110));
                    }

                    context.DrawEllipse(valueBrush0, null, FirstInPoint, 4, 4);
                    context.DrawEllipse(valueBrush1, null, SecondInPoint, 4, 4);
                    context.DrawEllipse(valueBrushOut, null, OutPoint, 4, 4);

                    break;
                case (Standart.ANSI):
                    if (IsSelected)
                        context.DrawRectangle(Brushes.Transparent, new Pen(Brushes.Black, 2, DashStyle.DashDotDot, PenLineCap.Flat, PenLineJoin.Miter, 10), new Rect(new Point(StartPoint.X - 35, StartPoint.Y - 10), new Size(120, 120)));
                    var figure = new PathFigure
                    {
                        StartPoint = StartPoint,
                        IsClosed = false
                    };
                    figure.Segments.Add(new ArcSegment
                    {
                        Point = new Point(StartPoint.X + 80, StartPoint.Y + 50),
                        Size = new Size(80, 80),
                    });
                    figure.Segments.Add(new ArcSegment
                    {
                        Point = new Point(StartPoint.X, StartPoint.Y + 100),
                        Size = new Size(80, 80),
                    });
                    figure.Segments.Add(new LineSegment
                    {
                        Point = new Point(StartPoint.X - 20, StartPoint.Y + 100)
                    });
                    figure.Segments.Add(new ArcSegment
                    {
                        Point = new Point(StartPoint.X - 20, StartPoint.Y),
                        Size = new Size(100, 100),
                        SweepDirection = SweepDirection.CounterClockwise
                    });
                    figure.Segments.Add(new LineSegment
                    {
                        Point = new Point(StartPoint.X, StartPoint.Y)
                    });
                    var geometry = new PathGeometry();
                    geometry.Figures.Add(figure);
                    context.DrawGeometry(Brushes.White, pen, geometry);
                    figure = new PathFigure
                    {
                        StartPoint = new Point(StartPoint.X - 29, StartPoint.Y),
                        IsClosed = false
                    };
                    figure.Segments.Add(new ArcSegment
                    {
                        Point = new Point(StartPoint.X - 29, StartPoint.Y + 100),
                        Size = new Size(100, 100),
                    });
                    geometry = new PathGeometry();
                    geometry.Figures.Add(figure);
                    context.DrawGeometry(null, pen, geometry);
                    context.DrawEllipse(Brushes.White, pen, new Rect(new Point(StartPoint.X + 75, StartPoint.Y + 44), new Size(12, 12)));
                    if (Label != null)
                    {
                        context.DrawText(new FormattedText(Label, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(LabelFont, FontStyle.Normal, FontWeight.Normal, FontStretch.Normal), 15, Brushes.Black), new Point(StartPoint.X + 10, StartPoint.Y + 110));
                    }
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
            Connector connector = Out as Connector;
            if (ValueIn[0] == ValueIn[1]) ValueOut = true;
            else ValueOut = false;
            if (Out != null) connector.SetNewValue(this, ValueOut);

            RenderTransform = new TranslateTransform();
        }
    }
}
