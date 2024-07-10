using SimUDuck.abstractions;
using SimUDuck.concrets.behaviors;

namespace SimUDuck.concrets.ducks;

public class ModelDuck : ADuck
{
    public ModelDuck()
    {
        FlyBehavior = new FlyNoWay();
        QuackBehavior = new Quack();
    }

    public override void Display()
    {
        Console.WriteLine("Model Duck");
    }
}
