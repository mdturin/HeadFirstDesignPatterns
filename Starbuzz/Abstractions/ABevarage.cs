using Starbuzz.Interfaces;

namespace Starbuzz.Abstractions;

public abstract class ABevarage : IBevarage
{
    public abstract double Cost();
    public abstract string GetDescription();
}