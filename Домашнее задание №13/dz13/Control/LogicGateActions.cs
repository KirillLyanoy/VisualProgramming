using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Avalonia.Media;
using LogicGateLibrary;
using Avalonia.Controls.Presenters;
using System.Drawing;

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
            if (logicGate is not Connector)
            {
                logicGate.StartPoint = new Avalonia.Point(Math.Round(current.X / 10) * 10, Math.Round(current.Y / 10) * 10);
                logicGate.RenderTransform = new TranslateTransform();
            }
            else
            {
                Connector connector = logicGate as Connector;
                connector.StartPoint = new Avalonia.Point(current.X, current.Y);
                connector.EndPoint = new Avalonia.Point(current.X, current.Y);
                connector.RenderTransform = new TransformGroup();
            }
        }
        public static void Delete(Canvas canvas)
        {
            LogicGate logicGate;
            foreach (var item in canvas.Children.ToList())
            {
                logicGate = item as LogicGate;
                if (logicGate != null)
                    if (logicGate.IsSelected) canvas.Children.Remove(item);
            }
        }
        public static void IsSelected(LogicGate logicGate)
        {
            logicGate.IsSelected = !logicGate.IsSelected;
            logicGate.RenderTransform = new TransformGroup();
        }
        public static void ChangeIn(IN logicGate)
        {
            logicGate.ValueOut = !logicGate.ValueOut;
            logicGate.IsSelected = false;
            logicGate.RenderTransform = new TransformGroup();
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
                        logicGate.RenderTransform = new TransformGroup();
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
                LinkItems(logicGate, connector);
                return connector;
            }
            if (logicGate.SecondInPoint != null && logicGate.SecondIn == null &&
                Math.Sqrt(Math.Pow((currentPoint.X - (logicGate.SecondInPoint.X)), 2) + Math.Pow((currentPoint.Y - (logicGate.SecondInPoint.Y)), 2)) <= 15)
            {
                Connector connector = new Connector(logicGate.SecondInPoint, logicGate.SecondInPoint);
                canvas.Children.Add(connector);
                LinkItems(logicGate, connector);
                return connector;
            }
            if (logicGate.OutPoint != null && logicGate.Out == null &&
                Math.Sqrt(Math.Pow((currentPoint.X - (logicGate.OutPoint.X)), 2) + Math.Pow((currentPoint.Y - (logicGate.OutPoint.Y)), 2)) <= 15)
            {
                Connector connector = new Connector(logicGate.OutPoint, logicGate.OutPoint);
                canvas.Children.Add(connector);
                LinkItems(logicGate, connector);
                return connector;
            }
            return null;
        }
        public static void EditConnectorX(Connector connector, double value)
        {
            connector.EndPoint = new Avalonia.Point(value, connector.StartPoint.Y);
            connector.RenderTransform = new TransformGroup();
        }
        public static void EditConnectorY(Connector connector, double value)
        {
            connector.EndPoint = new Avalonia.Point(connector.StartPoint.X, value);
            connector.RenderTransform = new TransformGroup();
        }
        public static void CheckConnectorSize(Canvas canvas, Connector connector)
        {
            if (Math.Abs(connector.StartPoint.X - connector.EndPoint.X) < 20 &&
                Math.Abs(connector.StartPoint.Y - connector.EndPoint.Y) < 20)                
                canvas.Children.Remove(connector);
        }
        public static void LinkItems(LogicGate parentLogicGate, Connector childLogicGate)
        {
            switch (parentLogicGate)
            {
                case Connector:
                    Connector connector = parentLogicGate as Connector;
                    connector.Connections.Add(childLogicGate);
                    childLogicGate.Connections.Add(parentLogicGate);
                    break;
                case LogicGate:
                    parentLogicGate = childLogicGate;
                    childLogicGate.Connections.Add(parentLogicGate);
                    break;
            }
        }      
        public static void UnLinkItems(LogicGate parentLogicGate, Connector childLogicGate)
        {
            switch (parentLogicGate)
            {
                case Connector:
                    Connector connector = parentLogicGate as Connector;
                    connector.Connections.Remove(childLogicGate);
                    childLogicGate.Connections.Remove(parentLogicGate);
                    break;
                case LogicGate:
                    parentLogicGate = null;
                    childLogicGate.Connections.Remove(parentLogicGate);
                    break;
            }
        }
    }
}
