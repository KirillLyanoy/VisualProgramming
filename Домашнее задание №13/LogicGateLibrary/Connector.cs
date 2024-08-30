using Avalonia.Media;
using Avalonia;
using System.Collections.ObjectModel;

namespace LogicGateLibrary
{
    public class Connector : LogicGate
    {
        public Connector() 
        {
            StartPoint = new Point(100, 50);
            EndPoint = new Point(100, 50);
            CenterPoint = new Point((StartPoint.X + EndPoint.X) / 2, (StartPoint.Y + EndPoint.Y) / 2);
        }
        public Connector(Point startPoint, Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }
        public ObservableCollection<LogicGate> Connections { get; set; } = new();
        private bool _valueOut = false;
        public override bool ValueOut
        {
            get { return _valueOut; }
            set
            {
                IsPassed = true;
                _valueOut = value;
                UpdateConnectorsValue(_valueOut);
            }
        }
        private Avalonia.Point _startPoint;
        public override Avalonia.Point StartPoint
        {
            get
            {
                return _startPoint;
            }
            set
            {
                _startPoint = value;
                CenterPoint = new Point((StartPoint.X + EndPoint.X) / 2, (StartPoint.Y + EndPoint.Y) / 2);
            }
        }
        private bool _isPassed = false;
        public bool IsPassed { get { return _isPassed; } set { _isPassed = value; } }
        private LogicGate temporaryParentItem;
        private bool _error = false;
        public bool Error 
        { 
            get { return _error; }
            set 
            { 
                _error = value;
                if (_error)
                {
                    foreach (var item in this.Connections.ToList())
                    {
                        if (item is Connector)
                        {
                            var connector = item as Connector;
                            if (!connector.Error) connector.Error = true;
                        }
                    }
                }
                RenderTransform = new TranslateTransform();
            } 
        }

        private Avalonia.Point _endPoint;
        public Avalonia.Point EndPoint 
        {
            get 
            {
                return _endPoint; 
            } 
            set
            {
                _endPoint = value;
                CenterPoint = new Point((StartPoint.X + EndPoint.X) / 2, (StartPoint.Y + EndPoint.Y) / 2);
            }
        }
        public sealed override void Render(DrawingContext context)
        {
            base.Render(context);

            IBrush currentBrush;
            if (ValueOut) currentBrush = Brushes.Lime;
            else currentBrush = Brushes.Green;

            if (IsSelected)
            {
                if (StartPoint.X < EndPoint.X || StartPoint.Y < EndPoint.Y)
                {
                    context.DrawRectangle(Brushes.Transparent, new Pen(Brushes.Black, 2, DashStyle.DashDotDot, PenLineCap.Flat, PenLineJoin.Miter, 10),
                        new Rect(new Point(StartPoint.X - 5, StartPoint.Y - 5), new Point(EndPoint.X + 5, EndPoint.Y + 5)));
                }
                else
                {
                    context.DrawRectangle(Brushes.Transparent, new Pen(Brushes.Black, 2, DashStyle.DashDotDot, PenLineCap.Flat, PenLineJoin.Miter, 10),
                        new Rect(new Point(EndPoint.X - 5, EndPoint.Y - 5), new Point(StartPoint.X + 5, StartPoint.Y + 5)));
                }
            }
            if (Error) currentBrush = Brushes.Red;

            context.DrawLine(new Pen(currentBrush, 3, null, PenLineCap.Flat, PenLineJoin.Bevel, 10), StartPoint, EndPoint);

            foreach (var item in Connections.ToList())
            {
                if (item is Connector)
                {
                    var connector = item as Connector;
                    if ((this.StartPoint.X - connector.StartPoint.X) * (connector.EndPoint.Y - connector.StartPoint.Y) ==
                        (connector.EndPoint.X - connector.StartPoint.X) * (this.StartPoint.Y - connector.StartPoint.Y))
                    {
                        if (this.StartPoint != connector.StartPoint && this.StartPoint != connector.EndPoint)
                        {
                            context.DrawEllipse(currentBrush, null, StartPoint, 4, 4);
                        }
                    }
                    else
                    {
                        if ((this.EndPoint.X - connector.StartPoint.X) * (connector.EndPoint.Y - connector.StartPoint.Y) ==
                        (connector.EndPoint.X - connector.StartPoint.X) * (this.EndPoint.Y - connector.StartPoint.Y))
                        {
                            if (this.EndPoint != connector.StartPoint && this.EndPoint != connector.EndPoint)
                            {
                                context.DrawEllipse(currentBrush, null, EndPoint, 4, 4);
                            }
                        }
                    }
                }
            }
        }
        public void UpdateConnectorsValue(bool newValue)
        {          
            foreach (var item in Connections)
            {
                if (temporaryParentItem != item)
                { 
                    switch (item)
                    {
                        case (Connector):
                            Connector connector = item as Connector;
                            if (connector.IsPassed == false) connector.SetNewValue(this, newValue);                            
                            break;
                        case (BUF):
                            BUF _buf = item as BUF;
                            if (_buf.FirstIn == this) _buf.ValueIn = newValue;
                            else if (_buf.Out == this) Error = true;
                            break;
                        case (INV):
                            INV _inv = item as INV;
                            if (_inv.FirstIn == this) _inv.ValueIn = newValue;
                            else if (_inv.Out == this) Error = true;
                            break;
                        case (AND):
                            AND _and = item as AND;
                            if (_and.FirstIn == this) _and.ValueIn[0] = newValue;
                            else if (_and.SecondIn == this) _and.ValueIn[1] = newValue;
                            else if (_and.Out == this) Error = true;
                            break;
                        case (NAND):
                            NAND _nand = item as NAND;
                            if (_nand.FirstIn == this) _nand.ValueIn[0] = newValue;
                            else if (_nand.SecondIn == this) _nand.ValueIn[1] = newValue;
                            else if (_nand.Out == this) Error = true;
                            break;
                        case (OR):
                            OR _or = item as OR;
                            if (_or.FirstIn == this) _or.ValueIn[0] = newValue;
                            else if (_or.SecondIn == this) _or.ValueIn[1] = newValue;
                            else if (_or.Out == this) Error = true;
                            break;
                        case (NOR):
                            NOR _nor = item as NOR;
                            if (_nor.FirstIn == this) _nor.ValueIn[0] = newValue;
                            else if (_nor.SecondIn == this) _nor.ValueIn[1] = newValue;
                            else if (_nor.Out == this) Error = true;
                            break;
                        case (XOR):
                            XOR _xor = item as XOR;
                            if (_xor.FirstIn == this) _xor.ValueIn[0] = newValue;
                            else if (_xor.SecondIn == this) _xor.ValueIn[1] = newValue;
                            else if (_xor.Out == this) Error = true;
                            break;
                        case (XNOR):
                            XNOR _xnor = item as XNOR;
                            if (_xnor.FirstIn == this) _xnor.ValueIn[0] = newValue;
                            else if (_xnor.SecondIn == this) _xnor.ValueIn[1] = newValue;
                            else if (_xnor.Out == this) Error = true;
                            break;
                        case (OUT):
                            OUT _out = item as OUT;
                            if (_out.FirstIn == this) _out.ValueIn = newValue;
                            break;
                        case (IN):
                            Error = true;
                            break;
                        default:
                            break;
                    }                    
                }
            }            
            RenderTransform = new TranslateTransform();
        }
        public void SetNewValue(LogicGate parentItem, bool value)
        {            
            temporaryParentItem = parentItem;
            ValueOut = value;
        }
    }
}
