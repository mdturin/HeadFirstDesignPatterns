using SimUDuck.interfaces.behaviors;

namespace SimUDuck.concrets.behaviors;

public class Quack : IQuackBehavior
{
    void IQuackBehavior.Quack()
    {
        Console.WriteLine("Quack");
    }
}
