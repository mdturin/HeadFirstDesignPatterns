using SimUDuck.Interfaces.Behaviors;

namespace SimUDuck.Concrets.Behaviors;

public class FlyNoWay : IFlyBehavior
{
    public void Fly()
    {
        Console.WriteLine("Can't Fly");
    }
}
