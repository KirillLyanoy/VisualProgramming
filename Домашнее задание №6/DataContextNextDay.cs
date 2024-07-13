using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace dz6
{
    internal class DataContextNextDay : DataContextMain
    {
        public DataContextNextDay()
        {
            DayInfo = DataContextWithWeather.GetOneDayWeather(MainWindow.GetDateNext());            
        }
        private List<model.List> _dayInfo;
        public List<model.List> DayInfo
        {
            get { return _dayInfo; }
            set { _ = SetField(ref _dayInfo, value); }
        }
    }
}
