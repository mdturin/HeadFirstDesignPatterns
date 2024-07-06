using SimUDuck.interfaces.behaviors;

namespace SimUDuck.concrets.behaviors;

public class Squeak : IQuackBehavior
{
    public void Quack()
    {
        Console.WriteLine("Squeak");
    }
}
