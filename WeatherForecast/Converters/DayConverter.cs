using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast.Converters
{
    public static class DayConverter
    {
        public static DateTime EpochToDate(long number)
        {
            //because we receive the data in int we have to convert it to datetine
            DateTimeOffset offset = DateTimeOffset.FromUnixTimeSeconds(number);
            DateTime convertedValue = offset.DateTime;
            return convertedValue;
        }
    }
}
