using PizzaHouse.Abstractions;
using PizzaHouse.Interfaces;

namespace PizzaHouse.Models;

public class ClamPizza(IPizzaIngredientFactory ingredientFactory) : APizza
{
    private readonly IPizzaIngredientFactory _ingredientFactory = ingredientFactory;

    public override APizza Prepare()
    {
        Dough = _ingredientFactory.CreateDough();
        Sauce = _ingredientFactory.CreateSauce();
        Cheese = _ingredientFactory.CreateCheese();
        Clams = _ingredientFactory.CreateClam();
        return this;
    }
}
