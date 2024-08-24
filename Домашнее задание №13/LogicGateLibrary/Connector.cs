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
                _valueOut = value;
                UpdateConnectorsValue(_valueOut);
            }
        }
        public override Avalonia.Point StartPoint { get; set; }




        //private bool _error = false;
        //public bool Error { get 
        //    { 
        //        return _error; 
        //    } 
        //    set 
        //    { 
        //        _error = value;
        //        RenderTransform = new TranslateTransform();
        //        if (temporaryParentItem is Connector)
        //        {
        //            var parentConnector = temporaryParentItem as Connector;
        //            parentConnector.Error = true;
        //        }
        //    } 
    //}

    //private bool _hasIn = false;
    //public bool HasIn { get { return _hasIn; } set { _hasIn = value; } }



    private bool _isPassed = false;
    public bool IsPassed { get { return _isPassed; } set { _isPassed = value; } }
    private LogicGate temporaryParentItem;
        public Avalonia.Point EndPoint { get; set; }
        public sealed override void Render(DrawingContext context)
        {
            base.Render(context);

            IBrush currentBrush;
            if (ValueOut) currentBrush = Brushes.Lime;
            else currentBrush = Brushes.Green;

            if (IsSelected)
            {
                if (StartPoint.X < EndPoint.X || StartPoint.Y < EndPoint.Y)
                    context.DrawRectangle(Brushes.Transparent, new Pen(Brushes.Black, 2, DashStyle.DashDotDot, PenLineCap.Flat, PenLineJoin.Miter, 10), 
                        new Rect(new Point(StartPoint.X - 5, StartPoint.Y - 5), new Point(EndPoint.X + 5, EndPoint.Y + 5)));
                else context.DrawRectangle(Brushes.Transparent, new Pen(Brushes.Black, 2, DashStyle.DashDotDot, PenLineCap.Flat, PenLineJoin.Miter, 10), 
                    new Rect(new Point(EndPoint.X - 5, EndPoint.Y - 5), new Point(StartPoint.X + 5, StartPoint.Y + 5)));
            }
            //if (_error) currentBrush = Brushes.Red;

            context.DrawLine(new Pen(currentBrush, 3, null, PenLineCap.Flat, PenLineJoin.Bevel, 10), StartPoint, EndPoint);

            foreach (var item in Connections)
            {
                if (item is Connector)
                {
                    var connector = item as Connector;
                    if ((this.StartPoint.X - connector.StartPoint.X) * (connector.EndPoint.Y - connector.StartPoint.Y) ==
                        (connector.EndPoint.X - connector.StartPoint.X) * (this.StartPoint.Y - connector.StartPoint.Y))
                        if (this.StartPoint == connector.StartPoint || this.StartPoint == connector.EndPoint) break;
                        else context.DrawEllipse(currentBrush, null, StartPoint, 4, 4);

                    else if ((this.EndPoint.X - connector.StartPoint.X) * (connector.EndPoint.Y - connector.StartPoint.Y) ==
                        (connector.EndPoint.X - connector.StartPoint.X) * (this.EndPoint.Y - connector.StartPoint.Y))
                        if (this.EndPoint == connector.StartPoint || this.EndPoint == connector.EndPoint) break;
                        else context.DrawEllipse(currentBrush, null, EndPoint, 4, 4);
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
                            break;
                        case (INV):
                            INV _inv = item as INV;
                            if (_inv.FirstIn == this) _inv.ValueIn = newValue;
                            break;
                        case (AND):
                            AND _and = item as AND;
                            if (_and.FirstIn == this) _and.ValueIn[0] = newValue;
                            else if (_and.SecondIn == this) _and.ValueIn[1] = newValue;
                            break;
                        case (NAND):
                            NAND _nand = item as NAND;
                            if (_nand.FirstIn == this) _nand.ValueIn[0] = newValue;
                            else if (_nand.SecondIn == this) _nand.ValueIn[1] = newValue;
                            break;
                        case (OR):
                            OR _or = item as OR;
                            if (_or.FirstIn == this) _or.ValueIn[0] = newValue;
                            else if (_or.SecondIn == this) _or.ValueIn[1] = newValue;
                            break;
                        case (NOR):
                            NOR _nor = item as NOR;
                            if (_nor.FirstIn == this) _nor.ValueIn[0] = newValue;
                            else if (_nor.SecondIn == this) _nor.ValueIn[1] = newValue;
                            break;
                        case (XOR):
                            XOR _xor = item as XOR;
                            if (_xor.FirstIn == this) _xor.ValueIn[0] = newValue;
                            else if (_xor.SecondIn == this) _xor.ValueIn[1] = newValue;
                            break;
                        case (XNOR):
                            XNOR _xnor = item as XNOR;
                            if (_xnor.FirstIn == this) _xnor.ValueIn[0] = newValue;
                            else if (_xnor.SecondIn == this) _xnor.ValueIn[1] = newValue;
                            break;
                        case (OUT):
                            OUT _out = item as OUT;
                            if (_out.FirstIn == this) _out.ValueIn = newValue;
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
            IsPassed = true;
            temporaryParentItem = parentItem;
            ValueOut = value;
        }
    }
}
