using Avalonia.Input;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz3
{
    static class Answer
    {
        static private double _answer;
        static public double GetAnswer()
        {
            return _answer;
        }
        static public void SetAnswer(double answer)
        {
            _answer = answer;   
        }    
    }

    class Calc
    {
        static public void Calculation(double x, double y, string operation)
        {
            switch(operation)
            {
                case "Plus":
                    Answer.SetAnswer(x + y);
                    break;
                case "Minus":
                    Answer.SetAnswer(x - y);
                    break;
                case "Multiply":
                    Answer.SetAnswer(x * y);
                    break;
                case "Divide":
                    Answer.SetAnswer(x / y);
                    break;






            }






        }


        /*
       public double Plus(double x, double y)
       {                      
           return x + y;
       }

       public double Minus(double x, double y)
       {
           return x - y;
       }

       public double Multiply(double x, double y)
       {
       return x * y; 
       }

       public double Divide(double x, double y)
       {
           return x / y;
       }

       public double Mod(double x, double y)
       {
           return x % y;
       }
       public double Factorial(double x)
       {
           int n = 1;
           return Math.Fact;
       }

       public double Degree(double x, double y)
       {
           return Degree(x, y);
       }

       public double Log(double x)
       {
           return Log(x);
       }

       public double Ln(double x)
       {
           return Ln(x);
       }

       public double Sin(double x)
       {
           return Sin(x);
       }

       public double Cos(double x)
       {
           return Cos(x);
       }

       public double Tan(double x)
       {
           return Tan(x);
       }

       public double Floor(double x)
       {
           return Floor(x);
       }

       public double Ceil(double x)
       {
           return Ceil(x);
       } */
    }
}
