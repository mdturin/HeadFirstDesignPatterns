using Starbuzz.Interfaces;

namespace Starbuzz.Abstractions;

public abstract class ACondimentDecorator(IBevarage bevarage) 
    : ABevarage
{
    protected IBevarage Bevarage { get; } = bevarage;

    public override double Cost()
    {
        return Bevarage.Cost() + base.Cost();
    }

    public override string GetDescription()
    {
        return Bevarage.GetDescription() + ", " + base.GetDescription();
    }

    public override string ToString()
    {
        return GetDescription() + ": " + Cost().ToString("F2");
    }
}
