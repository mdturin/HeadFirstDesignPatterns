namespace Weather_O_Rama;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

public interface IDisplay
{
    protected double Humidity { get; set; }
    protected double Pressure { get; set; }
    protected double Temperature { get; set; }
    void Display();
    void Update(double temperature, double humidity, double pressure);
}

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

public sealed class StatisticsDisplay : IDisplay
{
    public double Humidity { get; set; }
    public double Pressure { get; set; }
    public double Temperature { get; set; }

    public void Display() => Console.WriteLine(
        string.Format("{0}: H-{1} P-{2} T-{3}"),
        nameof(StatisticsDisplay),
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

public sealed class ForecastDisplay : IDisplay
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

    public void Update(double temperature, double humidity, double pressure)
    {
        Humidity = humidity;
        Pressure = pressure;
        Temperature = temperature;
    }
}

public class WeatherData
{
    private readonly Random _random = new();
    private readonly ForecastDisplay _forecastDisplay = new();
    private readonly StatisticsDisplay _statisticsDisplay = new();
    private readonly CurrentConditionsDisplay _currentConditionsDisplay = new();

    public double GetTemperature() => _random.NextDouble() * 100;
    public double GetHumidity() => _random.NextDouble() * 100;
    public double GetPressure() => _random.NextDouble() * 100;

    public void MeasurementsChanged() {
        var humidity = GetHumidity();
        var pressure = GetPressure();
        var temperature = GetTemperature();

        _forecastDisplay.Update(temperature, humidity, pressure);
        _statisticsDisplay.Update(temperature, humidity, pressure);
        _currentConditionsDisplay.Update(temperature, humidity, pressure);
    }
}