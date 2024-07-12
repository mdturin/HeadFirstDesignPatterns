using PizzaHouse.Concrets;
using PizzaHouse.Enums;

namespace PizzaHouse;

public class Program
{
    static void Main(string[] args)
    {
        var nyStore = new NYStylePizzaStore();
        var chicagoStore = new ChicagoStylePizzaStore();

        var nyCheese = nyStore
            .OrderPizza(PizzaType.NYStyleCheesePizza);
        Console.WriteLine(nyCheese.GetName());

        var chicagoCheese = chicagoStore
            .OrderPizza(PizzaType.ChicagoStyleCheesePizza);
        Console.WriteLine(chicagoCheese.GetName());
    }
}


