using SimUDuck.Interfaces.Behaviors;

namespace SimUDuck.Concrets.Behaviors;

public class Squeak : IQuackBehavior
{
    public void Quack()
    {
        Console.WriteLine("Squeak");
    }
}
