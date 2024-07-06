using SimUDuck.interfaces.behaviors;

namespace SimUDuck.concrets.behaviors;

public class MuteQuack : IQuackBehavior
{
    public void Quack()
    {
        Console.WriteLine("<< Silence >>");
    }
}
