using dz6.model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;


namespace dz6
{
    internal class DataContextMainWindow : INotifyPropertyChanged
    {
        public DataContextMainWindow() 
        {
            if (CurrentWeatherInfo == null) CurrentWeatherInfo = new WeatherInfo() { };
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
    }
}
