using SimUDuck.abstractions;
using SimUDuck.concrets.behaviors;

namespace SimUDuck.concrets.ducks;

public class RubberDuck : ADuck
{
    public RubberDuck()
    {
        FlyBehavior = new FlyNoWay();
        QuackBehavior = new Squeak();
    }

    public override void Display()
    {
        Console.WriteLine("This is Mallard Duck");
    }
}
