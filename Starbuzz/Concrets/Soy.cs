using Starbuzz.Abstractions;
using Starbuzz.Interfaces;

namespace Starbuzz.Concrets;

public class Soy : ACondimentDecorator
{
    public Soy(IBevarage bevarage) : base(bevarage)
    {
        Description = "Soy";
    }
}
