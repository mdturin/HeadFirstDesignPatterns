namespace Weather_O_Rama.Interfaces;

public interface IDisplay
{
    protected double Humidity { get; set; }
    protected double Pressure { get; set; }
    protected double Temperature { get; set; }
    void Display();
}
