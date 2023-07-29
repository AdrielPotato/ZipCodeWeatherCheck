using WeatherCheckLibrary.Entities;

namespace WeatherCheckLibrary.Services.Interfaces
{
    public interface IWeatherStackService
    {
        Task<(bool Success, CurrentWeatherResponse, WeatherStackError)> GetCurrentWeatherByZipCode(int zipCode);
    }
}
