using SimUDuck.interfaces.behaviors;

namespace SimUDuck.concrets.behaviors;

public class FlyNoWay : IFlyBehavior
{
    public void Fly()
    {
        Console.WriteLine("Can't Fly");
    }
}
