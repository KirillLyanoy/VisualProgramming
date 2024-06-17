using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz3
{
    static class Variable
    {
        static private string firstVariable;
        static private string secondVariable;

        static public string FirstValue
        {
            get 
            { 
                return firstVariable; 
            }
            set
            {
                firstVariable = firstVariable + value;    
            }
        }
        static public string SecondValue
        {
            get 
            { 
                return secondVariable; 
            }
        }
    }
}
