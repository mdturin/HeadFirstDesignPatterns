using SimUDuck.concrets.behaviors;
using SimUDuck.concrets.ducks;

namespace SimUDuck;

internal class Program
{
    static void Main(string[] args)
    {
        var mallard = new MallardDuck();
        mallard.PerformQuack();
        mallard.PerformFly();

        var model = new ModelDuck();
        model.PerformFly();
        model.SetFlyBehavior(new FlyRocketPowered());
        model.PerformFly();
    }
}
