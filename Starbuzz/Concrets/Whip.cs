using Starbuzz.Abstractions;
using Starbuzz.Interfaces;

namespace Starbuzz.Concrets;

public class Whip : ACondimentDecorator
{
    public Whip(IBevarage bevarage) : base(bevarage)
    {
        Description = "Whip";
    }
}
