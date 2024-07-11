using SimUDuck.Abstractions;
using SimUDuck.Concrets.Behaviors;

namespace SimUDuck.Concrets.Ducks;

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
