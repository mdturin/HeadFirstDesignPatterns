using Weather_O_Rama.Concrets;
using Weather_O_Rama.Concrets.Displays;

namespace Weather_O_Rama;

public class Program
{
    public static void Main(string[] args)
    {
        var weather = new WeatherData();
        weather.MeasurementsChanged();

        var conditionsDisplay = new CurrentConditionsDisplay();
        weather.Register(conditionsDisplay);
        weather.MeasurementsChanged();

        var forecastDisplay = new ForecastDisplay();
        weather.Register(forecastDisplay);
        weather.MeasurementsChanged();

        var statisticsDisplay = new StatisticsDisplay();
        weather.Register(statisticsDisplay);
        weather.MeasurementsChanged();

        Console.ReadLine();
    }
}
