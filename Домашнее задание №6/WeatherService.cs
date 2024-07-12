using System.Net.Http;
using System;
using dz6.model;
using System.Threading.Tasks;
using System.Text.Json;

namespace dz6
{
    internal class WeatherService
    {
        private static HttpClient client = new HttpClient();
        private static string _url = "https://api.openweathermap.org/data/2.5/forecast?q=Novosibirsk&units=metric&appid=65270a98c3dcac555ca95710dfd76dda";
        public static void SetUrl(string url)
        {
            _url = url;
        }
   
        static JsonSerializerOptions serializeOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };
        public static WeatherInfo weatherResult = new WeatherInfo();
        //получение погоды с openweather//        
        public static async Task<WeatherInfo> GetWeather()
        {            
            try
            {
                using HttpResponseMessage response = await client.GetAsync(_url);
                response.EnsureSuccessStatusCode();
                var jsonResponse = await response.Content.ReadAsStringAsync();
                weatherResult = JsonSerializer.Deserialize<WeatherInfo>(jsonResponse, serializeOptions);
                return weatherResult;
            }
            catch (System.Net.Http.HttpRequestException)
            {               
                SetUrl("https://api.openweathermap.org/data/2.5/forecast?q=Novosibirsk&units=metric&appid=65270a98c3dcac555ca95710dfd76dda");
                return weatherResult;
            }
           
        }
    }
}