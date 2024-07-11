namespace Weather_O_Rama.Interfaces;

public interface ISubject
{
    protected List<IObserver> Observers { get; set; }

    void Register(IObserver observer);
    void Remove(IObserver observer);
    void Notify();
}
