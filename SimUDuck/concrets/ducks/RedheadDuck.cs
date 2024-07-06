using SimUDuck.abstractions;
using SimUDuck.concrets.behaviors;

namespace SimUDuck.concrets.ducks;

public class RedheadDuck : ADuck
{
    public RedheadDuck()
    {
        QuackBehavior = new Quack();
        FlyBehavior = new FlyWithWings();
    }

    public override void Display()
    {
        Console.WriteLine("This is Redhead Duck");
    }
}