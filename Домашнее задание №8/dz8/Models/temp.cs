/* 
  <DataGrid
  ItemsSource="{Binding UsersList}"/>
  GridLinesVisibility="All"
  BorderThickness="1"
  BorderBrush="Gray">
    <DataGrid.Columns>
        <DataGridTextColumn Header="Id" Binding="{Binding Id}"/>
        <DataGridTextColumn Header="Name" Binding="{Binding Name}"/>
        <DataGridTextColumn Header="Username" Binding="{Binding Username}"/>
        <DataGridTextColumn Header="Email" Binding="{Binding Email}"/>
        <DataGridTextColumn Header="Phone" Binding="{Binding Phone}"/>
        <DataGridTextColumn Header="Website" Binding="{Binding Website}"/>
        <DataGridTextColumn Header="Street" Binding="{Binding Address.Street}"/>
        <DataGridTextColumn Header="Suite" Binding="{Binding Address.Suite}"/>
        <DataGridTextColumn Header="City" Binding="{Binding Address.City}"/>
        <DataGridTextColumn Header="Zipcode" Binding="{Binding Address.Zipcode}"/>
        <DataGridTextColumn Header="Lat" Binding="{Binding Address.Geo.Lat}"/>
        <DataGridTextColumn Header="Lat" Binding="{Binding Address.Geo.Lng}"/>
        <DataGridTextColumn Header="Company Name" Binding="{Binding Company.Name}"/>
        <DataGridTextColumn Header="Company Catch Phrase" Binding="{Binding Company.CatchPhrase}"/>
        <DataGridTextColumn Header="Company BS" Binding="{Binding Company.Bs}"/>
    </DataGrid.Columns>
</DataGrid> */


/*            UsersList = new ObservableCollection<User>()
            {
                new User()
                {
                    Id = 1,
                    Email="2312",
                     Phone="asds",
                      Website="asdsd",
                       Username="sdasd",
                        Name="sads",
                         Company = new Company()
                         {
                              Bs = "231",
                              Name="ssa",
                              CatchPhrase="sdasd",
                         },

                     Address = new Address()
                     {
                          City="asdas",
                            Street="sds",
                             Suite="sdasd",
                              Zipcode="sdas",
                               Geo = new Geo()
                               {
                                    Lat = "232",
                                    Lng = "22",
                               }
                     }

                },
                new User()
                {
                    Id = 2,
                    Email="2312",
                     Phone="asds",
                      Website="asdsd",
                       Username="sdasd",
                        Name="sads",
                         Company = new Company()
                         {
                              Bs = "231",
                              Name="ssa",
                              CatchPhrase="sdasd",
                         },

                     Address = new Address()
                     {
                          City="asdas",
                            Street="sds",
                             Suite="sdasd",
                              Zipcode="sdas",
                               Geo = new Geo()
                               {
                                    Lat = "232",
                                    Lng = "22",
                               }
                     }

                }
            };*/