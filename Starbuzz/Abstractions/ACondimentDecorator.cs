using Starbuzz.Interfaces;

namespace Starbuzz.Abstractions;

public abstract class ACondimentDecorator(IBevarage bevarage) : ABevarage
{
    private IBevarage Bevarage { get; } = bevarage;
}
