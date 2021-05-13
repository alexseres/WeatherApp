using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast.Converters
{
    public static class JsonConverters<T>
    {
        public static T JsonConverter(string json)
        {
            try
            {
                T item = JsonConvert.DeserializeObject<T>(json);
                return item;
            }
            catch (JsonReaderException ex)
            {
                Console.WriteLine(ex);
                throw new JsonReaderException();
            }
        }
    }
}
