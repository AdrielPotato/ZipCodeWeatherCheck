using Microsoft.Extensions.Logging;
using WeatherCheckLibrary.Entities;
using WeatherCheckLibrary.Services.Interfaces;

namespace ZipCodeWeatherCheck
{
    public class App
    {
        private readonly IWeatherStackService _weatherStackService;
        private readonly IUserQuestionsServices _questionsServices;
        private readonly ILogger<App> _logger;

        public App(IWeatherStackService weatherStackService, IUserQuestionsServices questionsServices, ILogger<App> logger)
        {
            _weatherStackService = weatherStackService;
            _questionsServices = questionsServices;
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
                        Console.WriteLine("Please enter a valid zipcode");
                        continue;
                    }

                    (bool Success, CurrentWeatherResponse current, WeatherStackError error) = await _weatherStackService.GetCurrentWeatherByZipCode(zipcode);

                    if (!Success)
                    {
                        Console.WriteLine("Please enter a valid zipcode");
                        continue;
                    }

                    var weather = current.Current;
                    Console.WriteLine($"{_questionsServices.ShouldIGoOutside(weather.WeatherCode)}, Weather is {weather.WeatherDescriptions.FirstOrDefault()} ");
                    Console.WriteLine($"{_questionsServices.ShouldIWearSunscreen(weather.UVIndex)}, Current UV Index: {weather.UVIndex}");
                    Console.WriteLine($"{_questionsServices.CanIFlyMyKite(weather.WeatherCode, weather.WindSpeed)}, Wind speed is {weather.WindSpeed}");
                }

            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
