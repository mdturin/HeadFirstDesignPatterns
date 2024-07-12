using PizzaHouse.Enums;
using PizzaHouse.Interfaces;

namespace PizzaHouse.Abstractions;

public abstract class APizzaStore : IPizzaStore
{
    public abstract APizza CreatePizza(PizzaType type);

    public APizza OrderPizza(PizzaType type)
    {
        return CreatePizza(type)
                .Prepare()
                .Bake()
                .Cut()
                .Box();
    }
}
