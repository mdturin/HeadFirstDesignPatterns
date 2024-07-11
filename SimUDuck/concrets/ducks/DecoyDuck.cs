using SimUDuck.Abstractions;
using SimUDuck.Concrets.Behaviors;

namespace SimUDuck.Concrets.Ducks;

public class DecoyDuck : ADuck
{
    public DecoyDuck()
    {
        FlyBehavior = new FlyNoWay();
        QuackBehavior = new MuteQuack();
    }

    public override void Display()
    {
        Console.WriteLine("This is Mallard Duck");
    }
}