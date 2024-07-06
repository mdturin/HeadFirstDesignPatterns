using SimUDuck.concrets.ducks;

namespace SimUDuck;

internal class Program
{
    static void Main(string[] args)
    {
        var mallard = new MallardDuck();
        mallard.PerformQuack();
        mallard.PerformFly();
    }
}
