using Avalonia.Controls;
using System;
using System.Linq;
using Avalonia.Media;
using LogicGateLibrary;

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
            switch (logicGate)
            {
                case Connector:
                    Connector connector = logicGate as Connector;
                    connector.StartPoint = new Avalonia.Point(current.X, current.Y);
                    connector.EndPoint = new Avalonia.Point(current.X, current.Y);
                    connector.RenderTransform = new TranslateTransform();
                    break;
                case IN:
                case OUT:
                    logicGate.StartPoint = new Avalonia.Point(Math.Round(current.X / 10) * 10 - 30, Math.Round(current.Y / 10) * 10 - 20);
                    logicGate.RenderTransform = new TranslateTransform();
                    break;
                default:
                    logicGate.StartPoint = new Avalonia.Point(Math.Round(current.X / 10) * 10 - 20, Math.Round(current.Y / 10) * 10 - 50);
                    logicGate.RenderTransform = new TranslateTransform();
                    break;
            }
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
        public static void EditConnectorX(Connector connector, double value)
        {
            connector.EndPoint = new Avalonia.Point(value, connector.StartPoint.Y);
            connector.RenderTransform = new TranslateTransform();
        }
        public static void EditConnectorY(Connector connector, double value)
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
            foreach (var item in connector.Connections)
            {
                switch (item)
                {
                    case Connector:
                        Connector childConnector = item as Connector;
                        childConnector.ValueOut = false;
                        childConnector.Connections.Remove(connector);
                        break;
                    case LogicGate:

                        LogicGate childLogicGate = item as LogicGate;

                        if (childLogicGate.FirstIn == connector)
                        {
                            childLogicGate.ValueOut = false;
                            childLogicGate.FirstIn = null;
                        }
                        if (childLogicGate.SecondIn == connector)
                        {
                            childLogicGate.ValueOut = false;
                            childLogicGate.SecondIn = null;
                        }
                        if (childLogicGate.Out == connector)
                        {
                            childLogicGate.ValueOut = false;
                            childLogicGate.Out = null;
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
            }
            if (gate.SecondIn != null)
            {
                Connector secondConnector = gate.SecondIn as Connector;
                secondConnector.Connections.Remove(gate);
            }
            if (gate.Out != null)
            {
                Connector outConnector = gate.Out as Connector;
                outConnector.Connections.Remove(gate);
                outConnector.ValueOut = false;
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
                                (oldConnector.EndPoint.X - oldConnector.StartPoint.Y) * (connector.EndPoint.Y - oldConnector.StartPoint.Y))
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
        public static void UpdateDiagram(Canvas canvas)
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
    }
}
