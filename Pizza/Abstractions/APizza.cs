using PizzaHouse.Enums;

namespace PizzaHouse.Abstractions;

public abstract class APizza
{
    protected string Name { get; set; }

    protected Dough Dough { get; set; }
    protected Sauce Sauce { get; set; }
    protected Clams Clams { get; set; }
    protected Cheese Cheese { get; set; }
    protected Pepperoni Pepperoni { get; set; }
    protected Veggies[] Veggies { get; set; } = [];

    public abstract APizza Prepare();

    public virtual APizza Bake()
    {
        Console.WriteLine("Bake for 25 minutes at 350");
        return this;
    }

    public virtual APizza Cut()
    {
        Console.WriteLine("Cutting the pizza into diagonal slices");
        return this;
    }

    public virtual APizza Box()
    {
        Console.WriteLine("Place pizza in official PizzaStore box");
        return this;
    }

    public string GetName() => Name;

    public APizza SetName(string name)
    {
        Name = name;
        return this;
    }
}
