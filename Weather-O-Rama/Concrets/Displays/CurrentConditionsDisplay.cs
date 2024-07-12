using Weather_O_Rama.Abstractions;
using Weather_O_Rama.Interfaces;

namespace Weather_O_Rama.Concrets.Displays;

public sealed class CurrentConditionsDisplay : ADisplay<CurrentConditionsDisplay>
{
    private readonly ISubject _subject;
    public CurrentConditionsDisplay(ISubject subject)
    {
        _subject = subject;
        _subject.Register(this);
    }

    public override Task Update(ISubject subject, IEventArgs args)
    {
        Task.Delay(1000).Wait();
        return base.Update(subject, args);
    }
}
