using Avalonia.Controls;
using dz7.model;
using System;

namespace dz7;

public partial class NewUserWindow : Window
{
    public NewUserWindow()
    {
        InitializeComponent();
    }

    private void ConfirmButton(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        DataContextWithUsers dataContextWithUsers = new();
        dataContextWithUsers.UsersList.Add(new User()
        {
            Id = int.Parse(id.Text),
            Name = name.Text,
            Username = userName.Text,
            Email = email.Text,
            Phone = phone.Text,
            Website = website.Text,
            Address = new Address()
            {
                Street = street.Text,
                Suite = suite.Text,
                City = city.Text,
                Geo = new Geo()
                {
                    Lat = lat.Text,
                    Lng = lng.Text
                }
            },
            Company = new Company()
            {
                Name = companyName.Text,
                CatchPhrase = catchPhrase.Text,
                Bs = bs.Text,
            }
        });
        this.Close();
    }
    private void CancelButton(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        this.Close();
    }
    private void TextBox_KeyDown(object? sender, Avalonia.Input.KeyEventArgs e)
    {
        try
        {
            if (!Char.IsDigit(e.KeySymbol[0]))
            {
                e.Handled = true;
            }
        }
        catch (System.NullReferenceException)
        {
            e.Handled = true;
        }
    }
}