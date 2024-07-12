using PizzaHouse.Abstractions;
using PizzaHouse.Enums;
using PizzaHouse.Interfaces;
using PizzaHouse.Models;

namespace PizzaHouse.Concrets;

public class NYStylePizzaStore : APizzaStore
{
    private readonly IPizzaIngredientFactory _factory = new NYPizzaIngredientFactory();

    public override APizza CreatePizza(PizzaType type)
    {
        return type switch
        {
            PizzaType.NYStyleCheesePizza => new CheesePizza(_factory)
                .SetName("New York Style Cheese Pizza"),

            _ => throw new ArgumentOutOfRangeException(
                $"{type} is not valid pizza!"),
        };
    }
}
