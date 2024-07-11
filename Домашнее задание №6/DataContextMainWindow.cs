using dz6.model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System;
using System.Linq;

namespace dz6
{
    internal class DataContextMainWindow : INotifyPropertyChanged
    {
        private Thread thread;
        public DataContextMainWindow() 
        {
            CurrentWeatherInfo = new();
            WeatherUpdate();
            thread = new Thread(EveryThreeHoursUpdate);
        }
        private static WeatherInfo? _currentWeatherInfo;

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
        //обновление погоды каждые 3 часа//
        private void EveryThreeHoursUpdate()
        {
            while(true)
            {               
                Thread.Sleep(10800000);
                WeatherUpdate();
            }
        }

        private void NextDays()
        {
            List<string> days = new();
            DateTime currentDateTime = DateTime.Now;
            foreach (var item in CurrentWeatherInfo.List)
            {
                DateTime dateTime;
                dateTime = Convert.ToDateTime(item.Dt_txt);
                dateTime = dateTime.AddHours(4);
                days.Add(dateTime.Day + "." + dateTime.Month);
            }
            Days = days.Distinct().ToList();
        }
        private static List<string> _days;
        public List<string> Days
        {
            get { return _days; }
            set { _ = SetField(ref _days, value); }
        }



    }
}
