using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace webservices.Models
{
    public class OpenWeatherMap
    {
        public String Cod { get; set; }
        public String Name { get; set; }
        public Main Main { get; set; }
        public List<Weather> Weather { get; set; }
    }

    public class Main  
    {
        public String Temp { get; set; }

    }

    public class Weather
    {
        public String Icon { get; set; }
    }

    public static class Serialize
    {
        public static OpenWeatherMap FromJson(string json) => JsonConvert.DeserializeObject<OpenWeatherMap>(json, Converter.Settings);

        public static string ToJson(this OpenWeatherMap self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}


