using System.Net.Http;
using System;
using System.Threading;
using System.Net.Http.Json;
using dz6.model;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Net;
using System.IO;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace dz6
{ 


    public class WeatherService
    {
        private static HttpClient client = new()
        {
            BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/forecast?q=Novosibirsk&units=metric&appid=65270a98c3dcac555ca95710dfd76dda"),
        };
        public static void NewUri(string url) { client.BaseAddress = new Uri(url); }    

        //обновление погоды каждые 3 часа//
        public static async void WeatherUpdate()
        {
            while (true)
            {                
                SetWeather(await GetWeather());
               
                break;
                Thread.Sleep(10800000);
            }
        }

        static JsonSerializerOptions serializeOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        //получение погоды с openweather//
        private static async Task<WeatherInfo> GetWeather()
        {
            WebRequest request = WebRequest.Create(client.BaseAddress);
            request.Method = "POST";
            WebResponse response = await request.GetResponseAsync();
            string answer = string.Empty;
            using (Stream s = response.GetResponseStream())
            {
                using StreamReader reader = new(s);
                answer = await reader.ReadToEndAsync();
            }
            response.Close();
            WeatherInfo weatherResult = JsonSerializer.Deserialize<WeatherInfo>(answer, serializeOptions);
            return weatherResult;
        }

        private static void SetWeather(WeatherInfo weatherInfo)
        {
            DataContextMainWindow dataContextMainWindow = new DataContextMainWindow();
            dataContextMainWindow.CurrentWeatherInfo = weatherInfo;
        }
    }
}