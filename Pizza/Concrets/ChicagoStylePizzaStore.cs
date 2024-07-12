using PizzaHouse.Abstractions;
using PizzaHouse.Enums;
using PizzaHouse.Interfaces;
using PizzaHouse.Models;

namespace PizzaHouse.Concrets;

internal class ChicagoStylePizzaStore : APizzaStore
{
    private readonly IPizzaIngredientFactory _factory = new ChicagoPizzaIngredientFactory();

    public override APizza CreatePizza(PizzaType type)
    {
        return type switch
        {
            PizzaType.ChicagoStyleCheesePizza => new CheesePizza(_factory)
                .SetName("Chicago Style Cheese Pizza"),

            _ => throw new ArgumentOutOfRangeException(
                $"{type} is not valid pizza!"),
        };
    }
}
