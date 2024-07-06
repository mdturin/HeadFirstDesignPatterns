using SimUDuck.abstractions;
using SimUDuck.concrets.behaviors;

namespace SimUDuck.concrets.ducks;

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