using Starbuzz.Enums;
using Starbuzz.Interfaces;

namespace Starbuzz.Abstractions;

public abstract class ABevarage : IBevarage
{
    private readonly Random _random = new();
    protected string Description { get; set; }
    protected CoffeeSize Size = CoffeeSize.Regular;

    public virtual string GetDescription() => Description;
    public virtual double Cost() 
        => _random.NextDouble() * 100 * SizeToCostRatio();

    protected double SizeToCostRatio()
    {
        return Size switch
        {
            CoffeeSize.Venti => 0.5,
            CoffeeSize.Regular => 1,
            CoffeeSize.Tall => 1.5,
            _ => throw new ArgumentOutOfRangeException($"{Size} is not valid!")
        };
    }

    public override string ToString()
    {
        return GetDescription() + ": " + Cost().ToString("F2");
    }
}