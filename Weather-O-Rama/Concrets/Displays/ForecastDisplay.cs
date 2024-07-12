using Weather_O_Rama.EventArgs;
using Weather_O_Rama.Interfaces;

namespace Weather_O_Rama.Concrets.Displays;

public sealed class ForecastDisplay : IDisplay, IObserver
{
    public double Humidity { get; set; }
    public double Pressure { get; set; }
    public double Temperature { get; set; }

    public void Display() => Console.WriteLine(
        string.Format("{0}: H-{1} P-{2} T-{3}"),
        nameof(ForecastDisplay),
        Humidity,
        Pressure,
        Temperature);

    public void Update(ISubject subject, IEventArgs args)
    {
        if (args is WeatherDataArgs data)
        {
            Humidity = data.Humidity;
            Pressure = data.Pressure;
            Temperature = data.Temperature;
        }
    }
}
