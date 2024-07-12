using Starbuzz.Abstractions;

namespace Starbuzz.Concrets;

public class Expresso : ABevarage
{
    public Expresso() => Description = "Expresso";
    public override double Cost()
    {
        return 1.99;
    }
}
