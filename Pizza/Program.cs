using PizzaHouse.Concrets;
using PizzaHouse.Enums;

namespace PizzaHouse;

public class Program
{
    static void Main(string[] args)
    {
        var nyStore = new NYStylePizzaStore();
        var nyCheese = nyStore
            .OrderPizza(PizzaType.NYStyleCheesePizza);
        Console.WriteLine(nyCheese.GetName());

        var cheeseStore = new ChicagoStylePizzaStore();
        var chicagoCheese = cheeseStore
            .OrderPizza(PizzaType.ChicagoStyleCheesePizza);
        Console.WriteLine(chicagoCheese.GetName());
    }
}
