using SimUDuck.Abstractions;
using SimUDuck.Concrets.Behaviors;

namespace SimUDuck.Concrets.Ducks;

public class MallardDuck : ADuck
{
    public MallardDuck()
    {
        QuackBehavior = new Quack();
        FlyBehavior = new FlyWithWings();
    }

    public override void Display()
    {
        Console.WriteLine("This is Mallard Duck");
    }
}
