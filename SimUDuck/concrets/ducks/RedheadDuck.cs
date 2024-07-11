using SimUDuck.Abstractions;
using SimUDuck.Concrets.Behaviors;

namespace SimUDuck.Concrets.Ducks;

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