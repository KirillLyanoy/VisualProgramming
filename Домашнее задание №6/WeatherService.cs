using System.Net.Http;
using dz6.model;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace dz6
{
    internal class WeatherService
    {
        private static HttpClient client = new();
        private static string _oldUrl;
        private static string _url = "https://api.openweathermap.org/data/2.5/forecast?q=Novosibirsk&units=metric&appid=65270a98c3dcac555ca95710dfd76dda";
        public static void SetUrl(string url)
        {
            _oldUrl = _url;
            _url = url;
        }
   
        static JsonSerializerOptions serializeOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };
        public static WeatherInfo weatherResult = new();
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
                SetUrl("https://api.openweathermap.org/data/2.5/forecast?q=" + _oldUrl + "&units=metric&appid=65270a98c3dcac555ca95710dfd76dda");
                return weatherResult;
            }           
        }    
    }
}