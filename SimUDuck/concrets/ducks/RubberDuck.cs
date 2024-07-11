using SimUDuck.Abstractions;
using SimUDuck.Concrets.Behaviors;

namespace SimUDuck.Concrets.Ducks;

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
