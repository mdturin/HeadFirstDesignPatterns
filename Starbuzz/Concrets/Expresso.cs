using Starbuzz.Abstractions;
using Starbuzz.Enums;

namespace Starbuzz.Concrets;

public class Expresso : ABevarage
{
    public Expresso(CoffeeSize size = CoffeeSize.Regular)
    {
        Size = size;
        Description = "Expresso";
    }

    public override double Cost()
    {
        return 1.99 * SizeToCostRatio();
    }
}
