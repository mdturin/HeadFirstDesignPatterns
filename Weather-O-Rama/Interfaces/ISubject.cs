namespace Weather_O_Rama.Interfaces;

public interface ISubject
{
    void Register(IObserver observer);
    void Remove(IObserver observer);
    void Notify(IObserver observer);
}
