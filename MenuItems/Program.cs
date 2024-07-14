namespace DinerAndPancake;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

public class MenuItem(
    string name, double price, bool vegetarian, string description)
{
    private string Name { get; set; } = name;
    private double Price { get; set; } = price;
    private bool Vegetarian { get; set; } = vegetarian;
    private string Description { get; set; } = description;

    public string GetName() => Name;
    public double GetPrice() => Price;
    public bool IsVegetarian() => Vegetarian;
    public string GetDescription() => Description;
}