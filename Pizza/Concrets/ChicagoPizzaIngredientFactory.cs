using PizzaHouse.Enums;
using PizzaHouse.Interfaces;

namespace PizzaHouse.Concrets;

public class ChicagoPizzaIngredientFactory
    : IPizzaIngredientFactory
{
    public Cheese CreateCheese()
        => Cheese.Reggiano;

    public Clams CreateClam()
        => Clams.Fresh;

    public Dough CreateDough()
        => Dough.ThinCrust;

    public Pepperoni CreatePepperoni()
        => Pepperoni.Sliced;

    public Sauce CreateSauce()
        => Sauce.Marinara;

    public Veggies[] CreateVeggies()
    {
        return
        [
            Veggies.Garlic,
            Veggies.Onion,
            Veggies.Mushroom,
            Veggies.RedPepper
        ];
    }
}
