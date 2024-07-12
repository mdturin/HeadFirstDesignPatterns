using Starbuzz.Abstractions;
using Starbuzz.Interfaces;

namespace Starbuzz.Concrets;

public class Mocha : ACondimentDecorator
{
    public Mocha(IBevarage bevarage) : base(bevarage)
    {
        Description = "Mocha";
    }

    public override double Cost()
    {
        return Bevarage.Cost() + 0.20;
    }
}