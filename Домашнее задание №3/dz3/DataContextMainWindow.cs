using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace dz3;

public class DataContextMainWindow : INotifyPropertyChanged
{
    private string _text = "0";

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
            if (_text == "0" && text != ".") Text = text;

            else
            {
                Text = _text + text;
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
    }

    public bool CanExecuteCommand(object parameter)
    {
        if (parameter is string text)
        {
            return text.StartsWith("Hello") == false;
        }

        return false;
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