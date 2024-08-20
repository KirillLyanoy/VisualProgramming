using Avalonia.Controls;
using Avalonia.Media;
using Avalonia;

namespace LogicGateLibrary
{
    public class CanvasLayout : Control
    {
        private double Width { get; set; }
        private double Height { get; set; }
        public CanvasLayout(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public sealed override void Render(DrawingContext context)
        {
            base.Render(context);

            Pen pen = new Pen(Brushes.LightGray, 1, null, PenLineCap.Flat, PenLineJoin.Miter, 10);

            for (double i = 0; i < Width; i += 10)
            {
                context.DrawLine(pen, new Point(i, 0), new Point(i, Height));
            }
            for (double i = 0; i < Height; i += 10)
            {
                context.DrawLine(pen, new Point(0, i), new Point(Width, i));
            }
        }
    }
}
