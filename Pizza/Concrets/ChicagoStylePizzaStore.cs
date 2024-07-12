using PizzaHouse.Abstractions;
using PizzaHouse.Enums;
using PizzaHouse.Models;

namespace PizzaHouse.Concrets;

internal class ChicagoStylePizzaStore : APizzaStore
{
    public override Pizza CreatePizza(PizzaType type)
    {
        return type switch
        {
            PizzaType.ChicagoStyleCheesePizza => new ChicagoStyleCheesePizza(),
            PizzaType.ChicagoStylePepperoniPizza => new ChicagoStylePepperoniPizza(),
            _ => throw new ArgumentOutOfRangeException($"{type} is not valid!")
        };
    }
}
