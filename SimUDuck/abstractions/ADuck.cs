using SimUDuck.interfaces.behaviors;

namespace SimUDuck.abstractions;

public abstract class ADuck
{
    protected IFlyBehavior? FlyBehavior { get; set; }
    protected IQuackBehavior? QuackBehavior { get; set; }
    public abstract void Display();
    public void PerformFly() => FlyBehavior?.Fly();
    public void PerformQuack() => QuackBehavior?.Quack();
    public void Swim() => Console.WriteLine("Swimming");
}
