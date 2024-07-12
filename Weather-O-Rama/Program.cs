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

        Console.ReadLine();
    }
}
