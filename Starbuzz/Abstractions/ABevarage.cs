using Starbuzz.Interfaces;

namespace Starbuzz.Abstractions;

public abstract class ABevarage : IBevarage
{
    private readonly Random _random = new();
    protected string Description { get; set; }
    public virtual double Cost()
        => _random.NextDouble() * 100;
    public virtual string GetDescription()
        => Description;
    public override string ToString()
    {
        return GetDescription() + ": " + Cost().ToString("F2");
    }
}