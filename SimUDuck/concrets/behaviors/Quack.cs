using SimUDuck.Interfaces.Behaviors;

namespace SimUDuck.Concrets.Behaviors;

public class Quack : IQuackBehavior
{
    void IQuackBehavior.Quack()
    {
        Console.WriteLine("Quack");
    }
}
