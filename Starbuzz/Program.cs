using Starbuzz.Concrets;

namespace Starbuzz;

public class Program
{
    public static void Main(string[] args)
    {
        var expresso = new Expresso();
        Console.WriteLine(expresso);

        var mocha = new Mocha(expresso);
        Console.WriteLine(mocha);
    }
}
