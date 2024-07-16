using System.Collections;

namespace DinerAndPancake;

internal class Program
{
    static void Main(string[] args)
    {
        var dinerMenu = new DinerMenu();
        var pancakeMenu = new PancakeHouseMenu();
        var cafeMenu = new CafeMenu();

        var waitress = new Waitress(
            dinerMenu, pancakeMenu, cafeMenu);

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

public class DinerMenuIterator(MenuItem[] items) : IEnumerator
{
    private int _position = -1;

    public object Current => Items[_position];

    private MenuItem[] Items { get; set; } = items;

    public bool MoveNext() 
        => ++_position < Items.Length && Items[_position] != null;

    public void Reset() => _position = 0;
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

    public IEnumerator CreateIterator()
        => new DinerMenuIterator(MenuItems);
}

public class PancakeHouseMenuIterator(List<MenuItem> items) : IEnumerator
{
    private int _position = 0;

    public object Current => Items[_position];

    private List<MenuItem> Items { get; set; } = items;

    public bool MoveNext()
        => ++_position < Items.Count && Items[_position] != null;

    public void Reset() => _position = 0;
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

    public IEnumerator CreateIterator() 
        => new PancakeHouseMenuIterator(MenuItems);
}

public class CafeMenu
{
    private readonly Dictionary<string, MenuItem> _menuItems = [];

    public CafeMenu()
    {
        AddItem("Veggie Burger and Air Fries",
            "Veggie burger on a whole wheat bun, lettuce, tomato, and fries",
            true, 3.99);

        AddItem("Soup of the day",
            "A cup of the soup of the day, with a side salad",
            false, 3.69);

        AddItem("Burrito",
            "A large burrito, with whole pinto beans, salsa, guacamole",
            true, 4.29);
    }

    public void AddItem(
        string name, string description, bool vegetarian, double price)
    {
        MenuItem menuItem = new MenuItem(name, description, vegetarian, price);
        _menuItems.Add(name, menuItem);
    }

    public IEnumerator CreateIterator()
        => new CafeMenuMenuIterator(_menuItems.Values);
}

public class CafeMenuMenuIterator(IEnumerable<MenuItem> items) : IEnumerator
{
    private readonly IEnumerator<MenuItem> _enumerator = items.GetEnumerator();

    public object Current => _enumerator.Current;

    public bool MoveNext() => _enumerator.MoveNext();

    public void Reset() => _enumerator.Reset();
}

public class Waitress(DinerMenu dinerMenu, PancakeHouseMenu pancakeHouseMenu, CafeMenu cafeMenu)
{
    private DinerMenu DinerMenu { get; set; } = dinerMenu;
    private PancakeHouseMenu PancakeHouseMenu { get; set; } = pancakeHouseMenu;
    private CafeMenu CafeMenu { get; set; } = cafeMenu;

    public void PrintMenu()
    {
        var dinerIterator = DinerMenu.CreateIterator();
        var pancakeIterator = PancakeHouseMenu.CreateIterator();
        var cafeIterator = CafeMenu.CreateIterator();

        Console.WriteLine("---Breakfast---");
        PrintMenu(pancakeIterator);

        Console.WriteLine("---Lunch---");
        PrintMenu(dinerIterator);

        Console.WriteLine("---Dinner---");
        PrintMenu(cafeIterator);
    }

    private void PrintMenu(IEnumerator enumerator)
    {
        while (enumerator.MoveNext())
        {
            var item = enumerator.Current as MenuItem;
            Console.WriteLine(
                $"{item!.GetName()}, {item.GetPrice()} -> {item.GetDescription()}");
        }
    }
}