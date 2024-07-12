using PizzaHouse.Enums;
using System.Security.Claims;

namespace PizzaHouse.Interfaces;

public interface IPizzaIngredientFactory
{
    Dough CreateDough();
    Sauce CreateSauce();
    Cheese CreateCheese();
    Veggies[] CreateVeggies();
    Pepperoni CreatePepperoni();
    Clams CreateClam();
}
