using dz6.model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System;
using System.Linq;
using System.Timers;

namespace dz6
{
    internal class DataContextMainWindow : INotifyPropertyChanged
    {   
        public DataContextMainWindow() 
        {
            CurrentWeatherInfo = new();
            WeatherUpdate();
            aTimer.Elapsed += WeatherUpdate;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            aTimer.Start();
        }
        private static WeatherInfo? _currentWeatherInfo;
        public static System.Timers.Timer aTimer = new(6000);
        public WeatherInfo CurrentWeatherInfo 
        {
            get { return _currentWeatherInfo; }
            set { _ = SetField(ref _currentWeatherInfo, value); }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        //Запрос новой погоды //
        private async void WeatherUpdate()
        {
            CurrentWeatherInfo = await WeatherService.GetWeather();
            NextDays();
        }
        
        private async void WeatherUpdate(Object source, ElapsedEventArgs e)
        {
            CurrentWeatherInfo = await WeatherService.GetWeather();
            NextDays();
        }
        private void NextDays()
        {
            List<string> days = [];
            foreach (var item in CurrentWeatherInfo.List)
            {
                DateTime dateTime;
                dateTime = Convert.ToDateTime(item.Dt_txt);
                dateTime = dateTime.AddHours(4);
                days.Add(dateTime.Day + "." + dateTime.Month);
            }
            Days = days.Distinct().ToList();
        }
        private static List<string>? _days;
        public List<string> Days
        {
            get { return _days; }
            set { _ = SetField(ref _days, value); }
        }
    }
}
