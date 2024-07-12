using Weather_O_Rama.EventArgs;
using Weather_O_Rama.Interfaces;

namespace Weather_O_Rama.Abstractions;

public abstract class ADisplay<T> : IDisplay, IObserver
{
    public double Humidity { get; set; }
    public double Pressure { get; set; }
    public double Temperature { get; set; }

    public virtual void Display()
    {
        Console.WriteLine(
            $"{nameof(T)}: H-{Humidity:F2} P-{Pressure:F2} T-{Temperature:F2}");
    }

    public virtual Task Update(ISubject subject, IEventArgs args)
    {
        if (args is WeatherDataArgs data)
        {
            Humidity = data.Humidity;
            Pressure = data.Pressure;
            Temperature = data.Temperature;
        }

        Display();
        return Task.CompletedTask;
    }
}
