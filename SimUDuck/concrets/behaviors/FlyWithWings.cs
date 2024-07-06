using SimUDuck.interfaces.behaviors;

namespace SimUDuck.concrets.behaviors;

public class FlyWithWings : IFlyBehavior
{
    public void Fly()
    {
        Console.WriteLine("Flying");
    }
}
