using SimUDuck.Interfaces.Behaviors;

namespace SimUDuck.Concrets.Behaviors;

public class FlyWithWings : IFlyBehavior
{
    public void Fly()
    {
        Console.WriteLine("Flying");
    }
}
