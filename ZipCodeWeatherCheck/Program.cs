using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WeatherCheckLibrary.Services;
using WeatherCheckLibrary.Services.Interfaces;
using ZipCodeWeatherCheck;

using IHost host = CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    await services.GetRequiredService<App>().RunAsync(args);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((config) =>
        {
            config.AddJsonFile("appsettings.json");
        })
        .ConfigureServices((context, services) =>
        {
            services.AddLogging();
            services.AddSingleton<App>();
            services.AddSingleton<IWeatherStackService,WeatherStackService>();
            services.AddSingleton<IUserQuestionsServices,UserQuestionsServices>();
            services.AddHttpClient("WeatherStack", httpClient =>
            {
                httpClient.BaseAddress = new Uri(context.Configuration.GetSection("WeatherStack:Url").Value);
            });
        });

}
