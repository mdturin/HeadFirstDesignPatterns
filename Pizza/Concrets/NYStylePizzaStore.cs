using PizzaHouse.Abstractions;
using PizzaHouse.Enums;
using PizzaHouse.Models;

namespace PizzaHouse.Concrets;

public class NYStylePizzaStore : APizzaStore
{
    public override Pizza CreatePizza(PizzaType type)
    {
        return type switch
        {
            PizzaType.NYStyleCheesePizza => new NYStyleCheesePizza(),
            PizzaType.NYStylePepperoniPizza => new NYStylePepperoniPizza(),
            _ => throw new ArgumentOutOfRangeException($"{type} is not valid!")
        };
    }
}
