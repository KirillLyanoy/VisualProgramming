using dz6.model;
using System;
using System.Net.Http;
using System.Net.Http.Json;

namespace dz6
{
    internal class CurrentWeather
    {
        private static HttpClient client = new()
        {
            BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/forecast?q=Novosibirsk&units=metric&appid=65270a98c3dcac555ca95710dfd76dda"),
        };

        public static async void GetWeather()
        {
            WeatherJSON? weatherJSON = await client.GetFromJsonAsync<WeatherJSON>(client.BaseAddress); 
        }


    }
}
