using Weather_O_Rama.Concrets;

namespace Weather_O_Rama;

public class Program
{
    public static void Main(string[] args)
    {
        var weather = new WeatherData();
        weather.MeasurementsChanged();
    }
}
