namespace Weather_O_Rama.Interfaces;

public interface IObserver
{
    void Update(ISubject subject, IEventArgs args);
}
