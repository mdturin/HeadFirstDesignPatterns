using Weather_O_Rama.Interfaces;

namespace Weather_O_Rama.Concrets.Displays;

public sealed class CurrentConditionsDisplay : IDisplay
{
    public double Humidity { get; set; }
    public double Pressure { get; set; }
    public double Temperature { get; set; }

    public void Display() => Console.WriteLine(
        string.Format("{0}: H-{1} P-{2} T-{3}"),
        nameof(CurrentConditionsDisplay),
        Humidity,
        Pressure,
        Temperature);

    public void Update(double temperature, double humidity, double pressure)
    {
        Humidity = humidity;
        Pressure = pressure;
        Temperature = temperature;
    }
}
