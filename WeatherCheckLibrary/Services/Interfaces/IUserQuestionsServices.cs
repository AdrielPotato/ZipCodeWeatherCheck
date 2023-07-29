namespace WeatherCheckLibrary.Services.Interfaces
{
    public interface IUserQuestionsServices
    {
        string CanIFlyMyKite(int weatherCode, int windSpeed);
        string ShouldIGoOutside(int weatherCode);
        string ShouldIWearSunscreen(int uvIndex);
    }
}