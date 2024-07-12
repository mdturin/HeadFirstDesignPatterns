using PizzaHouse.Enums;
using PizzaHouse.Models;

namespace PizzaHouse.Interfaces;

public interface IPizzaStore
{
    Pizza OrderPizza(PizzaType type);
    Pizza CreatePizza(PizzaType type);
}
