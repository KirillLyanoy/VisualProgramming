using Avalonia.Input;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz3
{
    class Calculator
    {
        static private double _x;
        static private double _y;
        static private string? _operator;
        static public void SetX(double x) { _x = x; }
        static public double GetX() { return _x; }
        static public void SetY(double y) { _y = y; }
        static public void SetOperator(string operatorName) { _operator = operatorName; }
        static public double Calculation()
        {
            switch (_operator)
            {
                case "Plus":
                    return (_x + _y);
                case "Minus":
                    return (_x - _y);
                case "Multiply":
                    return (_x * _y);
                case "Divide":
                    return (_x / _y);
                case "Mod":
                    return (_x % _y);
                case "Factorial":                   
                     long temp = 1;
                    for (int i = 1; i <= _x; i++)
                    {
                        temp *= i;
                    }
                    return (temp);
                case "Degree":
                    return Math.Pow(_x, _y);
                case "Log":
                    return Math.Log10(_x);
                case "Ln":
                    return Math.Log(_x);
                case "Sin":
                    return Math.Sin(_x);
                case "Cos":
                    return Math.Cos(_x);
                case "Tan":
                    return Math.Tan(_x);
                case "Floor":
                    return Math.Floor(_x);
                case "Ceil":
                    return Math.Ceiling(_x);
                default:
                    return 0;
            }
        }
    }
}
