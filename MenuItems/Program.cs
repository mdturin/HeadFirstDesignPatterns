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

public class DinerMenu
{
    private int _numberOfItems = 0;
    private const int _max_Items = 6;
    private MenuItem[] MenuItems { get; set; } = [];

    public DinerMenu()
    {
        MenuItems = new MenuItem[_max_Items];

        AddItem("Vegetarian BLT",
                "(Fakin') Bacon with lettuce & tomato on whole wheat", true, 2.99);

        AddItem("BLT",
                "Bacon with lettuce & tomato on whole wheat", false, 2.99);

        AddItem("Soup of the day",
                "Soup of the day, with a side of potato salad", false, 3.29);

        AddItem("Hotdog",
                "A hot dog, with sauerkraut, relish, onions, topped with cheese",
                false, 3.05);
    }

    public void AddItem(
        string name, string description, bool vegetarian, double price)
    {
        if (_numberOfItems >= _max_Items)
            throw new OutOfMemoryException($"Maximum limit is: {_max_Items}");
        MenuItems[_numberOfItems++] = new MenuItem(name, description, vegetarian, price);
    }

    public MenuItem[] GetMenuItems() => MenuItems;
}