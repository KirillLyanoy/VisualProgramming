using Avalonia.Controls.Primitives;
using Avalonia;
using dz11.Models;
using System.Collections.ObjectModel;
using System.Reflection;
using System;
using Avalonia.Controls;


namespace dz11.Control;

public class ObjectTreeControl : TemplatedControl
{
    public static readonly StyledProperty<object> CurrentObjectProperty =
        AvaloniaProperty.Register<ObjectTreeControl, object>("CurrentObject");
    public object CurrentObject
    {
        get => GetValue(CurrentObjectProperty);
        set => SetValue(CurrentObjectProperty, value);
    }

   
}
/*
	<Window.DataTemplates>
		<DataTemplate DataType="{x:Type con:Leaf}">
			<Grid ColumnDefinitions="*,*">
				<TextBox Grid.Column="1" Text="{Binding Value}" IsReadOnly="True"/>
				<TextBox Grid.Column="0" Text="{Binding PropertyName}" IsReadOnly="True"/>
			</Grid>
		</DataTemplate>
		<DataTemplate DataType="{x:Type con:Component}">
			<Expander Header="{Binding PropertyName}">
				<ListBox ItemsSource="{Binding Children}">
				</ListBox>
			</Expander>
		</DataTemplate>		
	</Window.DataTemplates>
	
	
	<StackPanel Margin="30">
		<Expander Header="Object Expander">
			<ListBox ItemsSource="{Binding CurrentUser, Converter={StaticResource ObjectConverter}}" />
		</Expander>
	</StackPanel>
	
 */