using Weather_O_Rama.Concrets.Displays;
using Weather_O_Rama.Interfaces;

namespace Weather_O_Rama.Concrets;

public class WeatherData : ISubject
{
    private readonly Random _random = new();
    private readonly ForecastDisplay _forecastDisplay = new();
    private readonly StatisticsDisplay _statisticsDisplay = new();
    private readonly CurrentConditionsDisplay _currentConditionsDisplay = new();

    public double GetTemperature() => _random.NextDouble() * 100;
    public double GetHumidity() => _random.NextDouble() * 100;
    public double GetPressure() => _random.NextDouble() * 100;

    public WeatherData()
    {

    }

    public void MeasurementsChanged()
    {
    }

    public void Register(IObserver observer)
    {
        throw new NotImplementedException();
    }

    public void Remove(IObserver observer)
    {
        throw new NotImplementedException();
    }

    public void Notify(IObserver observer)
    {
        throw new NotImplementedException();
    }
}