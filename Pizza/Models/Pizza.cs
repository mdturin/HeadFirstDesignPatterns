namespace PizzaHouse.Models;

public abstract class Pizza
{
    protected string Name { get; set; }
    protected string Dough { get; set; }
    protected string Sauce { get; set; }
    protected List<string> Toppings { get; set; } = [];

    public virtual Pizza Prepare()
    {
        Console.WriteLine("Preparing: " + Name);
        Console.WriteLine("Tossing dough...");
        Console.WriteLine("Adding sauce...");
        Console.Write("Adding toppings: ");
        Console.WriteLine(string.Join(", ", Toppings));
        return this;
    }

    public virtual Pizza Bake()
    {
        Console.WriteLine("Bake for 25 minutes at 350");
        return this;
    }

    public virtual Pizza Cut()
    {
        Console.WriteLine("Cutting the pizza into diagonal slices");
        return this;
    }

    public virtual Pizza Box()
    {
        Console.WriteLine("Place pizza in official PizzaStore box");
        return this;
    }

    public string GetName() => Name;
}
