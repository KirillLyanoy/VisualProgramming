﻿using Avalonia.Controls;
using Avalonia.Media;
using Avalonia;
using System.Net;

namespace LogicGateLibrary
{
    public class GroupSelectionRectangle : Control
    {
        public Avalonia.Point StartPoint;
        public Avalonia.Point EndPoint;
        public GroupSelectionRectangle(Avalonia.Point startPoint, Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;    
        }
        public Rect RectangleSelect;
        public sealed override void Render(DrawingContext context)
        {
            base.Render(context);
            Pen pen = new Pen(Brushes.Black, 2, DashStyle.DashDotDot, PenLineCap.Flat, PenLineJoin.Miter, 10);

            if (StartPoint.X <= EndPoint.X)
            {
                if (StartPoint.Y <= EndPoint.Y)
                {
                    RectangleSelect = new Rect(StartPoint, EndPoint);    
                }
                else
                {
                    RectangleSelect = new Rect(new Point(StartPoint.X, EndPoint.Y), new Point(EndPoint.X, StartPoint.Y));
                }
            }
            else
            {
                if (StartPoint.Y <= EndPoint.Y)
                {
                    RectangleSelect =  new Rect(new Point(EndPoint.X, StartPoint.Y), new Point(StartPoint.X, EndPoint.Y));

                }
                else
                {
                    RectangleSelect =  new Rect(EndPoint, StartPoint);
                }
            }
            context.DrawRectangle(Brushes.Transparent, pen, RectangleSelect);
        }
    }
}
