using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherCheckLibrary.Constants;
using WeatherCheckLibrary.Entities;
using WeatherCheckLibrary.Services.Interfaces;

namespace WeatherCheckLibrary.Services
{
    public class WeatherStackService:IWeatherStackService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _config;
        private readonly ILogger<WeatherStackService> _logger;

        public WeatherStackService(
            IHttpClientFactory clientFactory,
            IConfiguration config,
            ILogger<WeatherStackService> logger)
        {
            _clientFactory = clientFactory;
            _config = config;
            _logger = logger;
        }

        protected readonly string currentWeatherUrl = "/current";


        public async Task<(bool Success, CurrentWeatherResponse, WeatherStackError)> GetCurrentWeatherByZipCode(int zipCode)
        {
            try
            {
                //setup client
                var accessKey = _config.GetSection("WeatherStack:AccessKey").Value;
                var httpClient = _clientFactory.CreateClient("WeatherStack");

                //query
                var queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);

                queryString.Add("access_key", accessKey);
                queryString.Add("query", zipCode.ToString());

                //send request
                var request = new HttpRequestMessage(HttpMethod.Get, $"/current?{queryString}");
                var httpResponse = await httpClient.SendAsync(request);

                //Read response
                string jsonStr = await httpResponse.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<CurrentWeatherResponse>(jsonStr);
                var error = JsonConvert.DeserializeObject<WeatherStackError>(jsonStr);
                bool success = true;
                if (!error.Success)
                {
                    success = false;
                    _logger.LogError(error.Error.Info);
                }

                return (success, result, error);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

    }
}
