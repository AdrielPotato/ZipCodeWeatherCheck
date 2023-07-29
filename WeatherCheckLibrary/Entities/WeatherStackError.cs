using Newtonsoft.Json;

namespace WeatherCheckLibrary.Entities
{
    public class WeatherStackError
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("error")]
        public ErrorInfo Error { get; set; }

        public class ErrorInfo
        {
            [JsonProperty("code")]
            public int Code { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("info")]
            public string Info { get; set; }
        }
    }


}
