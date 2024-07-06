using SimUDuck.abstractions;
using SimUDuck.concrets.behaviors;

namespace SimUDuck.concrets.ducks;

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
