using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast.Converters
{
    public static class KelvinConverter
    {
        public static decimal ConvertKelvinToCelsius(decimal dec)
        {
            return dec - 273;
        }
    }
}
