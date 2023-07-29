using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherCheckLibrary.Entities
{
    public class CurrentWeather
   {
        //        {
        //    "request": {
        //        "type": "City",
        //        "query": "New York, United States of America",
        //        "language": "en",
        //        "unit": "m"
        //    },
        //    "location": {
        //        "name": "New York",
        //        "country": "United States of America",
        //        "region": "New York",
        //        "lat": "40.714",
        //        "lon": "-74.006",
        //        "timezone_id": "America/New_York",
        //        "localtime": "2019-09-07 08:14",
        //        "localtime_epoch": 1567844040,
        //        "utc_offset": "-4.0"
        //    },
        //    "current": {
        //        "observation_time": "12:14 PM",
        //        "temperature": 13,
        //        "weather_code": 113,
        //        "weather_icons": [
        //            "https://assets.weatherstack.com/images/wsymbols01_png_64/wsymbol_0001_sunny.png"
        //        ],
        //        "weather_descriptions": [
        //            "Sunny"
        //        ],
        //        "wind_speed": 0,
        //        "wind_degree": 349,
        //        "wind_dir": "N",
        //        "pressure": 1010,
        //        "precip": 0,
        //        "humidity": 90,
        //        "cloudcover": 0,
        //        "feelslike": 13,
        //        "uv_index": 4,
        //        "visibility": 16
        //    }
        //}
        [JsonProperty("observation_time")]
        public string ObservationTime { get; set; }

        [JsonProperty("temperature")]
        public int Temperature { get; set; }

        [JsonProperty("weather_code")]
        public int WeatherCode { get; set; }

        [JsonProperty("weather_icons")]
        public List<string> WeatherIcons { get; set; }

        [JsonProperty("weather_descriptions")]
        public List<string> WeatherDescriptions { get; set; }

        [JsonProperty("wind_speed")]
        public int WindSpeed { get; set; }

        [JsonProperty("wind_degree")]
        public int WindDegree { get; set; }

        [JsonProperty("wind_dir")]
        public string WindDirection { get; set; }


        [JsonProperty("pressure")]
        public int WindPressure { get; set; }

        [JsonProperty("precip")]
        public decimal WindPrecipitation { get; set; }

        [JsonProperty("humidity")]
        public int WindHumidity { get; set; }

        [JsonProperty("cloudcover")]
        public int CloudCover { get; set; }

        [JsonProperty("feelslike")]
        public int FeelsLike { get; set; }

        [JsonProperty("uv_index")]
        public int UVIndex { get; set; }

        [JsonProperty("visibility")]
        public int Visibility { get; set; }
        
    }
}
