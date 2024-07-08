using System.Net.Http;
using System;
using System.Threading;
using System.Net.Http.Json;
using dz6.model;
using System.Threading.Tasks;
using System.ComponentModel;


namespace dz6;


public class WeatherService
{
    private static HttpClient client = new()
    {
        BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/forecast?q=Novosibirsk&units=metric&appid=65270a98c3dcac555ca95710dfd76dda"),
    };
    public static void NewUri(string url) { client.BaseAddress = new Uri(url); }
    private static WeatherInfo? weatherInfo = new();

    //обновление погоды каждые 3 часа//
    public static async void WeatherUpdate()
    {
        while (true)
        {
            weatherInfo = await GetWeather();
            SetWeather(weatherInfo);
            Thread.Sleep(10800000);
        }
    }
   
    //получение погоды с openweather//
    private static async Task<WeatherInfo?> GetWeather()
    {
        return await client.GetFromJsonAsync<WeatherInfo>(client.BaseAddress);
    }
    private static void SetWeather(WeatherInfo? weatherInfo)
    {
        DataContextMainWindow dataContextMainWindow = new DataContextMainWindow();
        dataContextMainWindow.City = weatherInfo.City.Name.ToString();
    }
}
