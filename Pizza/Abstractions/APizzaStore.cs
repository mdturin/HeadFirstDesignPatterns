using PizzaHouse.Enums;
using PizzaHouse.Interfaces;
using PizzaHouse.Models;

namespace PizzaHouse.Abstractions;

public abstract class APizzaStore : IPizzaStore
{
    public abstract Pizza CreatePizza(PizzaType type);

    public Pizza OrderPizza(PizzaType type)
    {
        return CreatePizza(type)
                .Prepare()
                .Bake()
                .Cut()
                .Box();
    }
}
