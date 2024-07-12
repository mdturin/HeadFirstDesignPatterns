using Weather_O_Rama.Abstractions;
using Weather_O_Rama.Interfaces;

namespace Weather_O_Rama.Concrets.Displays;

public sealed class StatisticsDisplay : ADisplay<StatisticsDisplay>
{
    private readonly ISubject _subject;
    public StatisticsDisplay(ISubject subject)
    {
        _subject = subject;
        _subject.Register(this);
    }
}
