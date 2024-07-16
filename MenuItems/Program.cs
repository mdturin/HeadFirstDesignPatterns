namespace DinerAndPancake;

internal class Program
{
    static void Main(string[] args)
    {
        var dinerMenu = new DinerMenu();
        var pancakeMenu = new PancakeHouseMenu();
        var waitress = new Waitress(dinerMenu, pancakeMenu);

        waitress.PrintMenu();
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

public interface IIterator
{
    bool HasNext();
    MenuItem? Next();
}

public class DinerMenuIterator(MenuItem[] items) : IIterator
{
    private int _position = 0;
    private MenuItem[] Items { get; set; } = items;

    public bool HasNext() 
        => !(_position >= Items.Length || Items[_position] == null);

    public MenuItem? Next() 
        => HasNext() ? Items[_position++] : null;
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

    public IIterator CreateIterator() => new DinerMenuIterator(MenuItems);
}

public class PancakeHouseMenuIterator(List<MenuItem> items) : IIterator
{
    private int _position = 0;
    private List<MenuItem> Items { get; set; } = items;

    public bool HasNext()
        => !(_position >= Items.Count || Items[_position] == null);

    public MenuItem? Next()
        => HasNext() ? Items[_position++] : null;
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

    public IIterator CreateIterator() 
        => new PancakeHouseMenuIterator(MenuItems);
}

public class Waitress(DinerMenu dinerMenu, PancakeHouseMenu pancakeHouseMenu)
{
    private DinerMenu DinerMenu { get; set; } = dinerMenu;
    private PancakeHouseMenu PancakeHouseMenu { get; set; } = pancakeHouseMenu;

    public void PrintMenu()
    {
        var dinerIterator = DinerMenu.CreateIterator();
        var pancakeIterator = PancakeHouseMenu.CreateIterator();

        Console.WriteLine("---Breakfast---");
        PrintMenu(pancakeIterator);

        Console.WriteLine("---Lunch---");
        PrintMenu(dinerIterator);
    }

    private void PrintMenu(IIterator iterator)
    {
        while (iterator.HasNext())
        {
            var item = iterator.Next();
            Console.WriteLine(
                $"{item!.GetName()}, {item.GetPrice()} -> {item.GetDescription()}");
        }
    }
}