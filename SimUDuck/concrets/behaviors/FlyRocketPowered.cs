using SimUDuck.interfaces.behaviors;

namespace SimUDuck.concrets.behaviors;

public class FlyRocketPowered : IFlyBehavior
{
    public void Fly()
    {
        Console.WriteLine("Flying with Rocket");
    }
}
