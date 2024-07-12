using Starbuzz.Concrets;
using Starbuzz.Interfaces;

namespace Starbuzz;

public class Program
{
    public static void Main(string[] args)
    {
        var expresso = new Expresso();
        Console.WriteLine(expresso);

        IBevarage darkRoast = new DarkRoast();
        darkRoast = new Mocha(darkRoast);
        darkRoast = new Mocha(darkRoast);
        darkRoast = new Whip(darkRoast);
        Console.WriteLine(darkRoast);

        IBevarage houseBlend = new HouseBlend();
        houseBlend = new Soy(houseBlend);
        houseBlend = new Mocha(houseBlend);
        houseBlend = new Whip(houseBlend);
        Console.WriteLine(houseBlend);
    }
}
