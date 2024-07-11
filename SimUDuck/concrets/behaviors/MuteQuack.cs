using SimUDuck.Interfaces.Behaviors;

namespace SimUDuck.Concrets.Behaviors;

public class MuteQuack : IQuackBehavior
{
    public void Quack()
    {
        Console.WriteLine("<< Silence >>");
    }
}
