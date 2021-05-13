using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast.Converters
{
    public static class DayConverter
    {
        public static DateTime EpochToDate(long number)
        {
            DateTimeOffset offset = DateTimeOffset.FromUnixTimeSeconds(number * 1000);
            DateTime convertedValue = offset.DateTime;
            return convertedValue;
        }
    }
}
