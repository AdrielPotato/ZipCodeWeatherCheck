using WeatherCheckLibrary.Constants;
using WeatherCheckLibrary.Entities;
using WeatherCheckLibrary.Services.Interfaces;

namespace WeatherCheckLibrary.Services
{
    public class UserQuestionsServices : IUserQuestionsServices
    {
        private const string Yes = "Yes";
        private const string No = "No";
        private const int UVIndexThreshold = 3;
        private const int WindSpeedKiteThreshold = 15;

        public UserQuestionsServices()
        {
        }

        public void PrintQuestions()
        {
            Console.WriteLine("Should I go outside? ");
        }

        public string ShouldIGoOutside(int weatherCode)
        {
            if (WeatherStackValues.RainyWeatherCodes.Contains(weatherCode))
                return QuestionValues.ShouldIGoOutSideQuestion + No;

            return QuestionValues.ShouldIGoOutSideQuestion + Yes;
        }

        public string ShouldIWearSunscreen(int uvIndex)
        {
            if (uvIndex <= UVIndexThreshold)
                return QuestionValues.ShouldIWearSunscreenQuestion + No;

            return QuestionValues.ShouldIWearSunscreenQuestion + Yes;
        }

        public string CanIFlyMyKite(int weatherCode, int windSpeed)
        {
            if (!WeatherStackValues.RainyWeatherCodes.Contains(weatherCode) && windSpeed <= WindSpeedKiteThreshold)
                return QuestionValues.CanIFlyMyKiteQuestion + No;

            return QuestionValues.CanIFlyMyKiteQuestion + Yes;
        }
    }
}
