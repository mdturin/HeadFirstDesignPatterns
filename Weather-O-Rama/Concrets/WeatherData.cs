using Weather_O_Rama.EventArgs;
using Weather_O_Rama.Interfaces;

namespace Weather_O_Rama.Concrets;

public class WeatherData : ISubject
{
    private readonly Random _random = new();
    private readonly WeatherDataArgs _dataArgs = new();

    public List<IObserver> Observers { get; set; } = [];

    public double GetHumidity() => _random.NextDouble() * 100;
    public double GetPressure() => _random.NextDouble() * 100;
    public double GetTemperature() => _random.NextDouble() * 100;

    public void MeasurementsChanged()
    {
        _dataArgs.Humidity = GetHumidity();
        _dataArgs.Pressure = GetPressure();
        _dataArgs.Temperature = GetTemperature();

        Notify();
    }

    public void Register(IObserver observer)
    {
        Observers.Add(observer);
    }

    public void Remove(IObserver observer)
    {
        Observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in Observers)
            observer.Update(this, _dataArgs);
    }
}