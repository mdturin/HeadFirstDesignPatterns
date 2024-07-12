namespace Starbuzz;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

public class Bevarage
{
    private string Description { get; set; }
    private bool Milk { get; set; }
    private bool Soy { get; set; }
    private bool Mocha { get; set; }
    private bool Whip { get; set; }
    private readonly Random _random = new();

    public string GetDescription() => Description;
    public double Cost() => _random.NextDouble() * 100;

    public bool HasMilk() => Milk;
    public bool SetMilk() => Milk = true;

    public bool HasSoy() => Soy;
    public bool SetSoy() => Soy = true;

    public bool HasMocha() => Mocha;
    public bool SetMocha() => Mocha = true;

    public bool HasWhip() => Whip;
    public bool SetWhip() => Whip = true;
}