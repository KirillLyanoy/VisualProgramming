using Avalonia.Controls;
using System;
using System.Linq;
using Avalonia.Media;
using LogicGateLibrary;
using Avalonia.OpenGL.Surfaces;
namespace dz13.Control
{
    public class LogicGateActions
    {
        public static void Add(Canvas canvas, string logicGateName)
        {
            switch (logicGateName)
            {
                case ("Буфер"):
                    canvas.Children.Add(new BUF(Standart.GOST));
                    break;
                case ("Инвертор"):
                    canvas.Children.Add(new INV(Standart.GOST));
                    break;
                case ("И"):
                    canvas.Children.Add(new AND(Standart.GOST));
                    break;
                case ("И-НЕ"):
                    canvas.Children.Add(new NAND(Standart.GOST));
                    break;
                case ("ИЛИ"):
                    canvas.Children.Add(new OR(Standart.GOST));
                    break;
                case ("ИЛИ-НЕ"):
                    canvas.Children.Add(new NOR(Standart.GOST));
                    break;
                case ("Исключающее ИЛИ"):
                    canvas.Children.Add(new XOR(Standart.GOST));
                    break;
                case ("Исключающее ИЛИ-НЕ"):
                    canvas.Children.Add(new XNOR(Standart.GOST));
                    break;
                case ("Вход"):
                    canvas.Children.Add(new IN());
                    break;
                case ("Выход"):
                    canvas.Children.Add(new OUT());
                    break;
                case ("BUF"):
                    canvas.Children.Add(new BUF(Standart.ANSI));
                    break;
                case ("INV"):
                    canvas.Children.Add(new INV(Standart.ANSI));
                    break;
                case ("AND"):
                    canvas.Children.Add(new AND(Standart.ANSI));
                    break;
                case ("NAND"):
                    canvas.Children.Add(new NAND(Standart.ANSI));
                    break;
                case ("OR"):
                    canvas.Children.Add(new OR(Standart.ANSI));
                    break;
                case ("NOR"):
                    canvas.Children.Add(new NOR(Standart.ANSI));
                    break;
                case ("XOR"):
                    canvas.Children.Add(new XOR(Standart.ANSI));
                    break;
                case ("XNOR"):
                    canvas.Children.Add(new XNOR(Standart.ANSI));
                    break;
                case ("IN"):
                    canvas.Children.Add(new IN());
                    break;
                case ("OUT"):
                    canvas.Children.Add(new OUT());
                    break;
                default:
                    break;
            }
        }
        public static void Move(LogicGate logicGate, Avalonia.Point current)
        {
            Avalonia.Point newCoord;

            if (logicGate is IN || logicGate is OUT) newCoord = new Avalonia.Point(Math.Round(current.X / 10) * 10 - 30, Math.Round(current.Y / 10) * 10 - 20);
            else newCoord = new Avalonia.Point(Math.Round(current.X / 10) * 10 - 20, Math.Round(current.Y / 10) * 10 - 50);

            logicGate.StartPoint = newCoord;
            logicGate.RenderTransform = new TranslateTransform();
        }
        public static void Delete(Canvas canvas)
        {
            foreach (var item in canvas.Children.ToList())
            {
                if (item is CanvasLayout) continue;
                else
                {
                    switch (item)
                    {
                        case Connector:
                            Connector connector = item as Connector;
                            if (connector.IsSelected)
                            {
                                UnLinkItems(connector);
                                canvas.Children.Remove(connector);
                            }
                            break;
                        case LogicGate:
                            LogicGate logicGate = item as LogicGate;
                            if (logicGate.IsSelected)
                            {
                                UnLinkItems(logicGate);
                                canvas.Children.Remove(logicGate);
                            }
                            break;
                    }
                }
            }
        }
        public static void IsSelected(LogicGate logicGate)
        {
            logicGate.IsSelected = !logicGate.IsSelected;
            logicGate.RenderTransform = new TranslateTransform();
        }
        public static void ChangeIn(IN logicGate)
        {
            logicGate.ValueOut = !logicGate.ValueOut;
            logicGate.IsSelected = false;
            logicGate.RenderTransform = new TranslateTransform();
        }
        public static void RemoveAllSelections(Canvas canvas)
        {
            LogicGate logicGate;
            foreach (var item in canvas.Children.ToList())
            {
                logicGate = item as LogicGate;
                if (logicGate is CanvasLayout) continue;
                if (logicGate != null)
                {
                    if (logicGate.IsSelected)
                    {
                        logicGate.IsSelected = !logicGate.IsSelected;
                        logicGate.RenderTransform = new TranslateTransform();
                    }
                }
            }
        }
        public static void ClearCanvas(Canvas canvas)
        {
            foreach (var item in canvas.Children.ToList())
            {
                if (item is not CanvasLayout) canvas.Children.Remove(item);
            }
        }
        public static Connector CreateConnector(Canvas canvas, Connector connector, Avalonia.Point currentPoint)
        {
            Connector newConnector = new Connector(currentPoint, currentPoint);
            canvas.Children.Add(newConnector);
            LinkItems(connector, newConnector);
            return newConnector;
        }
        public static Connector CreateConnector(Canvas canvas, LogicGate logicGate, Avalonia.Point currentPoint)
        {
            if (logicGate.FirstInPoint != null && logicGate.FirstIn == null &&
                Math.Sqrt(Math.Pow((currentPoint.X - (logicGate.FirstInPoint.X)), 2) + Math.Pow((currentPoint.Y - (logicGate.FirstInPoint.Y)), 2)) <= 15)
            {
                Connector connector = new Connector(logicGate.FirstInPoint, logicGate.FirstInPoint);
                canvas.Children.Add(connector);
                LinkItems(logicGate, connector, 0);
                return connector;
            }
            if (logicGate.SecondInPoint != null && logicGate.SecondIn == null &&
                Math.Sqrt(Math.Pow((currentPoint.X - (logicGate.SecondInPoint.X)), 2) + Math.Pow((currentPoint.Y - (logicGate.SecondInPoint.Y)), 2)) <= 15)
            {
                Connector connector = new Connector(logicGate.SecondInPoint, logicGate.SecondInPoint);
                canvas.Children.Add(connector);
                LinkItems(logicGate, connector, 1);
                return connector;
            }
            if (logicGate.OutPoint != null && logicGate.Out == null &&
                Math.Sqrt(Math.Pow((currentPoint.X - (logicGate.OutPoint.X)), 2) + Math.Pow((currentPoint.Y - (logicGate.OutPoint.Y)), 2)) <= 15)
            {
                Connector connector = new Connector(logicGate.OutPoint, logicGate.OutPoint);
                canvas.Children.Add(connector);
                LinkItems(logicGate, connector, 2);
                return connector;
            }
            return null;
        }
        //public static void ChangeConnectorStartPointX(Connector connector, double value)
        //{
        //    connector.StartPoint = new Avalonia.Point(value, connector.EndPoint.Y);
        //    connector.RenderTransform = new TranslateTransform();
        //}
        //public static void ChangeConnectorStartPointY(Connector connector, double value)
        //{
        //    connector.StartPoint = new Avalonia.Point(connector.EndPoint.X, value);
        //    connector.RenderTransform = new TranslateTransform();
        //}
        public static void ChangeConnectorEndPointX(Connector connector, double value)
        {
            connector.EndPoint = new Avalonia.Point(value, connector.StartPoint.Y);
            connector.RenderTransform = new TranslateTransform();
        }
        public static void ChangeConnectorEndPointY(Connector connector, double value)
        {
            connector.EndPoint = new Avalonia.Point(connector.StartPoint.X, value);
            connector.RenderTransform = new TranslateTransform();
        }
        public static bool CheckConnectorSize(Canvas canvas, Connector connector)
        {
            if (Math.Abs(connector.StartPoint.X - connector.EndPoint.X) < 20 &&
                Math.Abs(connector.StartPoint.Y - connector.EndPoint.Y) < 20) return false;
            else return true;
        }
        public static void LinkItems(LogicGate parentLogicGate, Connector childLogicGate, short connectIndex)
        {
            childLogicGate.Connections.Add(parentLogicGate);
            switch (connectIndex)
            {
                case 0:
                    parentLogicGate.FirstIn = childLogicGate;
                    break;
                case 1:
                    parentLogicGate.SecondIn = childLogicGate;
                    break;
                case 2:
                    parentLogicGate.Out = childLogicGate;
                    break;
            }
        }
        public static void LinkItems(Connector parentLogicGate, Connector childLogicGate)
        {
            Connector connector = parentLogicGate as Connector;
            connector.Connections.Add(childLogicGate);
            childLogicGate.Connections.Add(parentLogicGate);
        }
        public static void UnLinkItems(Connector connector)
        {
            foreach (var item in connector.Connections.ToList())
            {
                switch (item)
                {
                    case Connector:
                        Connector childConnector = item as Connector;
                        childConnector.ValueOut = false;
                        childConnector.Connections.Remove(connector);

                        connector.Connections.Remove(childConnector);
                        break;
                    case LogicGate:

                        LogicGate childLogicGate = item as LogicGate;

                        if (childLogicGate.FirstIn == connector)
                        {
                            childLogicGate.ValueOut = false;
                            childLogicGate.FirstIn = null;
                            connector.Connections.Remove(childLogicGate.FirstIn);
                        }
                        if (childLogicGate.SecondIn == connector)
                        {
                            childLogicGate.ValueOut = false;
                            childLogicGate.SecondIn = null;
                            connector.Connections.Remove(childLogicGate.SecondIn);
                        }
                        if (childLogicGate.Out == connector)
                        {
                            childLogicGate.ValueOut = false;
                            childLogicGate.Out = null;
                            connector.Connections.Remove(childLogicGate.Out);
                        }
                        break;
                }
            }
        }
        public static void UnLinkItems(LogicGate gate)
        {
            if (gate.FirstIn != null)
            {
                Connector firstConnector = gate.FirstIn as Connector;
                firstConnector.Connections.Remove(gate);
                gate.FirstIn = null;
            }
            if (gate.SecondIn != null)
            {
                Connector secondConnector = gate.SecondIn as Connector;
                secondConnector.Connections.Remove(gate);
                gate.SecondIn = null;
            }
            if (gate.Out != null)
            {
                Connector outConnector = gate.Out as Connector;
                outConnector.Connections.Remove(gate);
                outConnector.ValueOut = false;
                gate.Out = null;
            }
        }
        public static void CheckConnectorEndOut(Canvas canvas, Connector connector)
        {
            foreach (var item in canvas.Children.ToList())
            {
                switch (item)
                {
                    case Connector:
                        Connector oldConnector = item as Connector;
                        if (oldConnector != connector)
                        {
                            if ((connector.EndPoint.X - oldConnector.StartPoint.X) * (oldConnector.EndPoint.Y - oldConnector.StartPoint.Y) ==
                                (oldConnector.EndPoint.X - oldConnector.StartPoint.X) * (connector.EndPoint.Y - oldConnector.StartPoint.Y))
                            {
                                LinkItems(oldConnector, connector);
                                connector.RenderTransform = new TranslateTransform();
                                return;
                            }
                            else break;
                        }
                        else break;
                    case LogicGate:
                        LogicGate logicGate = item as LogicGate;
                        if (logicGate.FirstIn == null && logicGate.FirstInPoint.X != 0 && logicGate.FirstInPoint.Y != 0)
                        {
                            if (Math.Sqrt(Math.Pow((connector.EndPoint.X - (logicGate.FirstInPoint.X)), 2) + Math.Pow((connector.EndPoint.Y - (logicGate.FirstInPoint.Y)), 2)) <= 10)
                            {
                                LinkItems(logicGate, connector, 0);
                                return;
                            }
                        }
                        if (logicGate.SecondIn == null && logicGate.SecondInPoint.X != 0 && logicGate.SecondInPoint.Y != 0)
                        {
                            if (Math.Sqrt(Math.Pow((connector.EndPoint.X - (logicGate.SecondInPoint.X)), 2) + Math.Pow((connector.EndPoint.Y - (logicGate.SecondInPoint.Y)), 2)) <= 10)
                            {
                                LinkItems(logicGate, connector, 1);
                                return;
                            }
                        }
                        if (logicGate.Out == null)
                        {
                            if (Math.Sqrt(Math.Pow((connector.EndPoint.X - (logicGate.OutPoint.X)), 2) + Math.Pow((connector.EndPoint.Y - (logicGate.OutPoint.Y)), 2)) <= 10)
                            {
                                LinkItems(logicGate, connector, 2);
                                return;
                            }
                        }
                        break;
                }
            }
        }
        public static void UpdateDiagramValue(Canvas canvas)
        {
            foreach (var item in canvas.Children.ToList())
            {
                if (item is IN)
                {
                    var _in = item as IN;
                    _in.UpdateConnectorsValue();
                }
            }
        }
        public static void DeleteItemsWithConnectors(Canvas canvas)
        {
            foreach (var item in canvas.Children.ToList())
            {
                if (item is Connector)
                {
                    var connector = item as Connector;
                    if (connector.IsSelected)
                    {
                        UnLinkItems(connector);
                        canvas.Children.Remove(item);
                    }
                }
                else if (item is LogicGate)
                {
                    var logicGate = item as LogicGate;
                    if (logicGate.IsSelected)
                    {
                        if (logicGate.FirstIn != null)
                        {
                            Connector connector = logicGate.FirstIn as Connector;
                            UnLinkItems(logicGate.FirstIn);
                            canvas.Children.Remove(connector);
                        }
                        if (logicGate.SecondIn != null)
                        {
                            Connector connector = logicGate.SecondIn as Connector;
                            UnLinkItems(logicGate.SecondIn);
                            canvas.Children.Remove(connector);
                        }
                        if (logicGate.Out != null)
                        {
                            Connector connector = logicGate.Out as Connector;
                            UnLinkItems(logicGate.Out);
                            canvas.Children.Remove(connector);
                        }
                        canvas.Children.Remove(logicGate);
                    }
                }
            }
        }
        public static void ResetPassedIndex(Canvas canvas)
        {
            foreach (var item in canvas.Children.ToList())
            {
                if (item is Connector)
                {
                    var connector = item as Connector;
                    connector.IsPassed = false;
                }
            }
        }
        public static GroupSelectionRectangle CreateGroupSelectedRectangle(Canvas canvas, Avalonia.Point startPoint)
        {
            GroupSelectionRectangle rectangle = new(startPoint, startPoint);
            canvas.Children.Add(rectangle);
            return rectangle;
        }
        public static void ChangeGroupSelectedRectangleSize(GroupSelectionRectangle rectangle, Avalonia.Point newEndPoint)
        {
            rectangle.EndPoint = newEndPoint;
            rectangle.RenderTransform = new TranslateTransform();
        }
        public static void CheckItemsInGroupSelectionRectangle(Canvas canvas, GroupSelectionRectangle selections)
        {
            foreach (var item in canvas.Children)
            {
                if (item is LogicGate)
                {
                    LogicGate logicGate = item as LogicGate;
                    if (logicGate.CenterPoint.X <= selections.RectangleSelect.BottomRight.X &&
                        logicGate.CenterPoint.X >= selections.RectangleSelect.TopLeft.X &&
                        logicGate.CenterPoint.Y <= selections.RectangleSelect.BottomRight.Y &&
                        logicGate.CenterPoint.Y >= selections.RectangleSelect.TopLeft.Y)
                    {
                        logicGate.IsSelected = true;
                        logicGate.RenderTransform = new TranslateTransform();
                    }
                    else
                    {
                        logicGate.IsSelected = false;
                        logicGate.RenderTransform = new TranslateTransform();
                    }
                }
            }
        }
    }
}
