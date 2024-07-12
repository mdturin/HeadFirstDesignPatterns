using Starbuzz.Abstractions;

namespace Starbuzz.Concrets;

public class HouseBlend : ABevarage
{
    public HouseBlend() => Description = "House Blend Coffee";
    public override double Cost()
    {
        return 0.89;
    }
}
