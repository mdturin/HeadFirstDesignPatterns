using PizzaHouse.Abstractions;
using PizzaHouse.Enums;

namespace PizzaHouse.Interfaces;

public interface IPizzaStore
{
    APizza OrderPizza(PizzaType type);
    APizza CreatePizza(PizzaType type);
}
