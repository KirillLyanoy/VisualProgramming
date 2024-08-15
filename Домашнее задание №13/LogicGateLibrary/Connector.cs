using Avalonia.Media;
using Avalonia;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGateLibrary
{
    public class Connector : LogicGate
    {
        public bool ValueIn { get; set; }
        public sealed override void Render(DrawingContext context)
        {
            base.Render(context);
            Point startPoint = new Point(100, 100);
          
            IBrush? brush;


          
        }
    }
}
