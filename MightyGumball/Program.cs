namespace MightyGumball;

internal class Program
{
    static void Main(string[] args)
    {
        var machine = new GumballMachine(5);
        machine.InsertQuarter();
        machine.TurnCrank();

        machine.InsertQuarter();
        machine.TurnCrank();

        machine.InsertQuarter();
        machine.TurnCrank();
    }
}

public enum GumballState : short
{
    Sold_Out,
    No_Quater,
    Has_Quarter,
    Sold,
    Winner
}

public interface IState
{
    void InsertQuarter();
    void EjectQuarter();
    void TurnCrank();
    void Dispense();
}

public class NoQuarterState(GumballMachine machine) : IState
{
    private readonly GumballMachine _machine = machine;

    public void Dispense()
        => Console.WriteLine("You need to pay first");

    public void EjectQuarter()
        => Console.WriteLine("You haven't inserted a quarter");

    public void InsertQuarter()
    {
        Console.WriteLine("You inserted a quarter");
        _machine.SetState(GumballState.Has_Quarter);
    }

    public void TurnCrank()
        => Console.WriteLine("You turned, but there's no quarter");
}

public class HasQuarterState(GumballMachine machine) : IState
{
    private readonly Random _random = new();
    private readonly GumballMachine _machine = machine;

    public void Dispense()
    {
        Console.WriteLine("No gumball dispensed");
    }

    public void EjectQuarter()
    {
        Console.WriteLine("Quarter returned");
        _machine.SetState(GumballState.No_Quater);
    }

    public void InsertQuarter()
    {
        Console.WriteLine("You can't insert another quarter");
    }

    public void TurnCrank()
    {
        Console.WriteLine("You turned...");
        _machine.SetState(GumballState.Sold);
        int winner = _random.Next(10);
        if (winner == 0 && _machine.GetCount() > 1)
            _machine.SetState(GumballState.Winner);
        else _machine.SetState(GumballState.Sold);
    }
}

public class SolidState(GumballMachine machine) : IState
{
    private readonly GumballMachine _machine = machine;

    public void Dispense()
    {
        _machine.ReleaseBall();
        if(_machine.GetCount() > 0)
        {
            _machine.SetState(GumballState.No_Quater);
        }
        else
        {
            Console.WriteLine("Oops, out of gumballs!");
            _machine.SetState(GumballState.Sold_Out);
        }
    }

    public void EjectQuarter()
    {
        Console.WriteLine("Sorry, you already turned the crank");
    }

    public void InsertQuarter()
    {
        Console.WriteLine("Please wait, we're already giving you a gumball");
    }

    public void TurnCrank()
    {
        Console.WriteLine("Turning twice doesn't get you another gumball!");
    }
}

public class SolidOutState(GumballMachine machine) : IState
{
    private readonly GumballMachine _machine = machine;

    public void Dispense()
    {
        Console.WriteLine("No gumball dispensed");
    }

    public void EjectQuarter()
    {
        Console.WriteLine("You can't eject, you haven't inserted a quarter yet");
    }

    public void InsertQuarter()
    {
        Console.WriteLine("You can't insert a quarter, the machine is sold out");
    }

    public void TurnCrank()
    {
        Console.WriteLine("You turned, but there are no gumballs");
    }
}

public class WinnerState(GumballMachine machine) : IState
{
    private readonly GumballMachine _machine = machine;

    public void Dispense()
    {
        _machine.ReleaseBall();
        if (_machine.GetCount() == 0)
        {
            _machine.SetState(GumballState.Sold_Out);
        }
        else
        {
            _machine.ReleaseBall();
            Console.WriteLine("YOU'RE A WINNER! You got two gumballs for your quarter");

            if(_machine.GetCount() > 0)
            {
                _machine.SetState(GumballState.No_Quater);
            }
            else
            {
                Console.WriteLine("Oops, out of gumballs!");
                _machine.SetState(GumballState.Sold_Out);
            }
        }
    }

    public void EjectQuarter()
    {
        Console.WriteLine("Sorry, you already turned the crank");
    }

    public void InsertQuarter()
    {
        Console.WriteLine("Please wait, we're already giving you a gumball");
    }

    public void TurnCrank()
    {
        Console.WriteLine("Turning twice doesn't get you another gumball!");
    }
}

public class GumballMachine
{
    private int _count = 0;
    private GumballState State { get; set; }
    private readonly Dictionary<GumballState, IState> _states = [];

    public GumballMachine(int numberGumballs)
    {
        _count = numberGumballs;
        _states.Add(GumballState.No_Quater, new NoQuarterState(this));
        _states.Add(GumballState.Has_Quarter, new HasQuarterState(this));
        _states.Add(GumballState.Sold, new SolidState(this));
        _states.Add(GumballState.Sold_Out, new SolidOutState(this));
        _states.Add(GumballState.Winner, new WinnerState(this));

        if (_count > 0)
            State = GumballState.No_Quater;
        else State = GumballState.Sold_Out;
    }

    public void SetState(GumballState state)
        => State = state;

    public void InsertQuarter() => _states[State].InsertQuarter();

    public void EjectQuarter() => _states[State].EjectQuarter();

    public void TurnCrank()
    {
        _states[State].TurnCrank();
        _states[State].Dispense();
    }

    public void ReleaseBall()
    {
        Console.WriteLine(
            "A gumball comes rolling out the slot...");
        if (_count > 0) _count = _count - 1;
    }

    public int GetCount() => _count;
}

