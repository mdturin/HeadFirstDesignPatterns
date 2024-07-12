using PizzaHouse.Abstractions;
using PizzaHouse.Interfaces;

namespace PizzaHouse.Models;

public class CheesePizza(IPizzaIngredientFactory factory) 
    : APizza
{
    private readonly IPizzaIngredientFactory _factory = factory;

    public override APizza Prepare()
    {
        Dough = _factory.CreateDough();
        Sauce = _factory.CreateSauce();
        Cheese = _factory.CreateCheese();
        return this;
    }
}
