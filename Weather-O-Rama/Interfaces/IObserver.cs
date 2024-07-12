namespace Weather_O_Rama.Interfaces;

public interface IObserver
{
    Task Update(ISubject subject, IEventArgs args);
}
