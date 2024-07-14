namespace DinerAndPancake;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

public class MenuItem(
    string name, string description, bool vegetarian, double price)
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

public class PancakeHouseMenu
{
    private List<MenuItem> MenuItems { get; set; } = [];
    public PancakeHouseMenu()
    {
        AddItem("K&B's Pancake Breakfast",
                "Pancakes with scrambled eggs and toast",
                true,
                2.99);

        AddItem("Regular Pancake Breakfast",
                "Pancakes with fried eggs, sausage",
                false,
                2.99);

        AddItem("Blueberry Pancakes",
                "Pancakes made with fresh blueberries",
                true,
                3.49);

        AddItem("Waffles",
                "Waffles with your choice of blueberries or strawberries",
                true,
                3.59);
    }

    public void AddItem(
        string name, string description, bool vegetarian, double price)
    {
        MenuItems
            .Add(new MenuItem(name, description, vegetarian, price));
    }

    public List<MenuItem> GetMenuItems() => MenuItems;
}