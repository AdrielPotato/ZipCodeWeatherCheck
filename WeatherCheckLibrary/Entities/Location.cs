using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherCheckLibrary.Entities
{
    public class Location
    {

        //        "name": "New York",
        //        "country": "United States of America",
        //        "region": "New York",
        //        "lat": "40.714",
        //        "lon": "-74.006",
        //        "timezone_id": "America/New_York",
        //        "localtime": "2019-09-07 08:14",
        //        "localtime_epoch": 1567844040,
        //        "utc_offset": "-4.0"

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("lat")]
        public decimal Latitude { get; set; }

        [JsonProperty("lon")]
        public decimal Longitude { get; set; }

        [JsonProperty("timezone_id")]
        public string TimezoneID { get; set; }

        [JsonProperty("localtime")]
        public DateTime LocalTime { get; set; }

        [JsonProperty("localtime_epoch")]
        public long LocalTimeUtc { get; set; }

        [JsonProperty("utc_offset")]
        public decimal UtcOffset { get; set; }
    }
}
