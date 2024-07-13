using dz6.model;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Timers;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace dz6
{
    internal class DataContextWithWeather : DataContextMain
    {
        public DataContextWithWeather()
        {
            CurrentWeatherInfo = new();
            WeatherUpdate();
            aTimer.Elapsed += WeatherUpdate;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            aTimer.Start();
        }
        public System.Timers.Timer aTimer = new(108000000);
        private static WeatherInfo? _currentWeatherInfo;
        public WeatherInfo CurrentWeatherInfo
        {
            get { return _currentWeatherInfo; }
            set { _ = SetField(ref _currentWeatherInfo, value); }
        }
        private List<string>? _days;
        public List<string> Days
        {
            get { return _days; }
            set { _ = SetField(ref _days, value); }
        }
        private int _roundedWeather;
        public int RoundedWeather
        {
            get { return _roundedWeather; }
            set { _ = SetField(ref _roundedWeather, value); }
        }
        public async void WeatherUpdate()
        {
            CurrentWeatherInfo = await WeatherService.GetWeather();
            NextDays();
            RoundWeather();
            NewBackgroundImage();
        }
        public async void WeatherUpdate(Object source, ElapsedEventArgs e)
        {
            CurrentWeatherInfo = await WeatherService.GetWeather();
            NextDays();
            RoundWeather();
            NewBackgroundImage();
        }
        private void NextDays()
        {
            List<string> days = [];
            DateTime dateTime;
            foreach (var item in CurrentWeatherInfo.List)
            {               
                dateTime = Convert.ToDateTime(item.Dt_txt);                          
                days.Add(dateTime.Day + "." + dateTime.Month);
            }
            Days = days.Distinct().ToList();
        }
        public void RoundWeather()
        {
            RoundedWeather = (int)Math.Round((decimal)_currentWeatherInfo.List[0].Main.Temp);
        }
        public void SetNewCity(string city)
        {
            aTimer.Stop();
            WeatherService.SetUrl("https://api.openweathermap.org/data/2.5/forecast?q=" + city + "&units=metric&appid=65270a98c3dcac555ca95710dfd76dda");
            WeatherUpdate();
            aTimer.Start();
        }
        public static List<model.List> GetOneDayWeather(string day)
        {
            List<List> oneDayWeather = [];
            DateTime dateTime;
            foreach (var item in _currentWeatherInfo.List)
            {
                dateTime = Convert.ToDateTime(item.Dt_txt);           
                if (day == dateTime.Day + "." + dateTime.Month) oneDayWeather.Add(item);
            }
            return oneDayWeather;
        }        
        public Bitmap BackgroundImage
        {
            get { return _backgroundImage; }
            set { _ = SetField(ref _backgroundImage, value); }
        }
        private static Bitmap _backgroundImage;
        private void NewBackgroundImage()
        {
            BackgroundImage = new Bitmap(AssetLoader.Open(new Uri("avares://dz6/Assets/" + _currentWeatherInfo.List[0].Weather[0].Icon + "Background.png")));
        }
    }
}