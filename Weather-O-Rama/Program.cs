using Weather_O_Rama.Concrets;
using Weather_O_Rama.Concrets.Displays;

namespace Weather_O_Rama;

public class Program
{
    public static void Main(string[] args)
    {
        var weather = new WeatherData();
        weather.MeasurementsChanged();

        _ = new CurrentConditionsDisplay(weather);
        weather.MeasurementsChanged();

        _ = new ForecastDisplay(weather);
        weather.MeasurementsChanged();

        _ = new StatisticsDisplay(weather);
        weather.MeasurementsChanged();

        Console.ReadLine();
    }
}
