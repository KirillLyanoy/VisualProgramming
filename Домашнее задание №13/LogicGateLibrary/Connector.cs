using Avalonia.Media;
using Avalonia;
using System.Collections.ObjectModel;

namespace LogicGateLibrary
{
    public class Connector : LogicGate
    {
        public Connector() { }
        public Connector(Point startPoint, Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }
        public ObservableCollection<LogicGate> Connections { get; set; } = new();
        private bool _value = false;
        public bool Value
        {
            get { return _value; }
            set
            {
                _value = value;
                UpdateConnectorsValue(_value);
            }
        }
        private bool _error = false;
        private LogicGate temporaryParentItem;
        public Avalonia.Point EndPoint { get; set; } = new Point(100, 50);
        public sealed override void Render(DrawingContext context)
        {
            base.Render(context);

            IBrush currentBrush;
            if (Value) currentBrush = Brushes.Lime;
            else currentBrush = Brushes.Green;
            if (IsSelected) currentBrush = Brushes.Red;
            IBrush? brush;

            context.DrawLine(new Pen(currentBrush, 3, null, PenLineCap.Flat, PenLineJoin.Bevel, 10), StartPoint, EndPoint);

            foreach (var item in Connections)
            {
                if (item is Connector)
                {
                    var connector = item as Connector;
                    if ((this.StartPoint.X - connector.StartPoint.X) * (connector.EndPoint.Y - connector.StartPoint.Y) ==
                        (connector.EndPoint.X - connector.StartPoint.X) * (this.StartPoint.Y - connector.StartPoint.Y))
                        context.DrawEllipse(currentBrush, null, StartPoint, 4, 4);
                    if ((this.EndPoint.X - connector.StartPoint.X) * (connector.EndPoint.Y - connector.StartPoint.Y) ==
                        (connector.EndPoint.X - connector.StartPoint.X) * (this.EndPoint.Y - connector.StartPoint.Y))
                        context.DrawEllipse(currentBrush, null, EndPoint, 4, 4);
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
                            connector.SetNewValue(this, newValue);
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
            temporaryParentItem = parentItem;
            Value = value;
        }
    }
}
