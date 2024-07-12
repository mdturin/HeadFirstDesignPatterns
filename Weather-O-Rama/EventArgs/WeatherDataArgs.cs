using Weather_O_Rama.Interfaces;

namespace Weather_O_Rama.EventArgs;

public class WeatherDataArgs : IEventArgs
{
    public double Humidity { get; set; }
    public double Pressure { get; set; }
    public double Temperature { get; set; }
}
