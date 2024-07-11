namespace Weather_O_Rama.Interfaces;

public interface IObserver
{
    void Update(double temperature, double humidity, double pressure);
}
