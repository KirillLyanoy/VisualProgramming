using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace dz3;

public class DataContextMainWindow : INotifyPropertyChanged
{
    private string _text = "0"; //текс в главном текстовом блоке//
    private bool yIndex = false; //используется для сохранения второго значения при повторном нажатии "="//
                                 
    public string Text
    {
        get
        {
            return _text;
        }

        set
        {
            _ = SetField(ref _text, value);
        }
    }

    public void ExecuteCommand(object parameter)
    {
        if (parameter is string text)
        {
            if (_text == "0" && text != ",") Text = text;

            else
            {
                if (_text == "-0") Text = "-" + text;
                else Text = _text + text;
            }
        }
    }
    public void DeleteLastElement()
    {
        int n = Text.Length;
        if (n > 0) Text = Text.Remove(n - 1);
        if (Text.Length == 0) Text = "0";
    }
    public void Clear()
    {
        Text = "0";
        Calculator.SetX(0);
        Calculator.SetY(0);
    }
    public void CalculateWithOneElement(string _operator)
    {
        Calculator.SetX(Convert.ToDouble(_text));
        Calculator.SetOperator(_operator);
        Calculator.SetX(Calculator.Calculation());
        Text = Convert.ToString(Calculator.GetX());
    }
    public void CalculateWithTwoElements(string _operator)
    {
        Calculator.SetX(Convert.ToDouble(_text));
        Text = "0";
        Calculator.SetOperator(_operator);
        yIndex = true; 
    }

    public void Equally()
    {        
        if (yIndex) Calculator.SetY(Convert.ToDouble(_text));
        Calculator.SetX(Calculator.Calculation());
        Text = Convert.ToString(Calculator.GetX());       
        yIndex = false;
    }

    public void NegativeNumber()
    {
        

        if (_text[0] == '-') Text = _text.Remove(0, 1);
        else Text = "-" + _text;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}