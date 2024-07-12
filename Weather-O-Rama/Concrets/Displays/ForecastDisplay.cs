using Weather_O_Rama.Abstractions;
using Weather_O_Rama.Interfaces;

namespace Weather_O_Rama.Concrets.Displays;

public sealed class ForecastDisplay : ADisplay<ForecastDisplay>
{
    private readonly ISubject _subject;
    public ForecastDisplay(ISubject subject)
    {
        _subject = subject;
        _subject.Register(this);
    }
}
