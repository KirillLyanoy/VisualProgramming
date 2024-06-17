using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz3
{
    internal class InputData
    {
        public void ClickHandler(object sender, RoutedEventArgs args)
        {
            Button button = sender as Button;
            Variable.FirstValue = Convert.ToString(button.Content);
        }
    }

}
