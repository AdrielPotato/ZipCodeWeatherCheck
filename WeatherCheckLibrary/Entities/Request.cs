using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherCheckLibrary.Entities
{
    public class Request
    {

        // "request": {
        //        "type": "City",
        //        "query": "New York, United States of America",
        //        "language": "en",
        //        "unit": "m"
        //    },

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }

    }
}
