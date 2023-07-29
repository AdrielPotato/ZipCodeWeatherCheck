using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WeatherCheckLibrary.Services.Interfaces;

namespace ZipCodeWeatherCheck
{
    public class App
    {
        private readonly IWeatherStackService _weatherStackService;
        private readonly ILogger<App> _logger;

        public App(IWeatherStackService weatherStackService, ILogger<App> logger)
        {
            _weatherStackService = weatherStackService;
            _logger = logger;
        }

        public async Task RunAsync(string[] args)
        {
            try
            {
                while (true)
                {
                    Console.Write("Input zipcode: ");
                    var zipcodeStr = Console.ReadLine();

                    if (!int.TryParse(zipcodeStr, out int zipcode))
                    {
                        Console.WriteLine("Please enter valid zipcode");
                        continue;
                    }

                    var response = await _weatherStackService.GetCurrentWeatherByZipCode(zipcode);

                    Console.WriteLine(response);
                }
               
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
