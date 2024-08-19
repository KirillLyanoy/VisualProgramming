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
        public static void Move(LogicGate logicGate, double X, double Y)
        {
            if (logicGate is not Connector)
            {
                var transform = new TransformGroup();
                transform.Children.Add(new TranslateTransform(X, Y));
                logicGate.RenderTransform = transform;
                logicGate.StartPoint = new Avalonia.Point(logicGate.StartPoint.X + X, logicGate.StartPoint.Y + Y);
            }
            else
            {
                Connector connector = logicGate as Connector;
                connector.StartPoint = new Avalonia.Point(logicGate.StartPoint.X + X, logicGate.StartPoint.Y + Y);
                connector.EndPoint = new Avalonia.Point(connector.EndPoint.X + X, connector.EndPoint.Y + Y);
                connector.RenderTransform = new TransformGroup();
            }
        }
        public static void Delete(Canvas canvas) 
        {
            LogicGate logicGate;
            foreach (var item in canvas.Children.ToList()) 
            {
                logicGate = item as LogicGate;
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
        public static void ChangeConnectorSize(LogicGate logicGate, Avalonia.Point startPoint, Avalonia.Point endPoint)
        {
            Connector connector = logicGate as Connector;
            connector.StartPoint = startPoint;
            connector.EndPoint = endPoint;
            connector.RenderTransform = new TransformGroup();
        }
        public static void RemoveAllSelections(Canvas canvas)
        {
            try
            {
                LogicGate logicGate;
                foreach (var item in canvas.Children.ToList())
                {
                    logicGate = item as LogicGate;
                    if (logicGate.IsSelected)
                    {
                        logicGate.IsSelected = !logicGate.IsSelected;
                        logicGate.RenderTransform = new TransformGroup();
                    }
                }
            }
            catch (System.NullReferenceException)
            { 
                return; 
            }
        }
        public static void LinkElements(LogicGate parentLogicGate, Connector childLogicGate)
        {
            parentLogicGate = childLogicGate;
            childLogicGate.Connections.Add(parentLogicGate);
        }
    }
}
