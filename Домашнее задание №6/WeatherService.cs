using System.Net.Http;
using System;
using System.Threading;
using dz6.model;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text.Json;

namespace dz6
{ 
    internal class WeatherService
    {
        private static HttpClient client = new()
        {
            BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/forecast?q=Novosibirsk&units=metric&appid=65270a98c3dcac555ca95710dfd76dda"),
        };
        public static void NewUri(string url) { client.BaseAddress = new Uri(url); }    
        static JsonSerializerOptions serializeOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };
        //получение погоды с openweather//
        public static async Task<WeatherInfo> GetWeather()
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
    }
}