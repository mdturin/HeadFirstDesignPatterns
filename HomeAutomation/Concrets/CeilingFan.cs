using HomeAutomation.Interfaces;

namespace HomeAutomation.Concrets;

public class CeilingFan(string name)
{
    private readonly string _name = name;

    public void On()
    {
        Console.WriteLine($"{_name}: Fan is on");
    }

    public void Off()
    {
        Console.WriteLine($"{_name}: Fan is off");
    }
}

public class CeilingFanOnCommand(CeilingFan fan) : ICommand
{
    private readonly CeilingFan _fan = fan;

    public void Execute()
    {
        _fan.On();
    }

    public void Undo()
    {
        _fan.Off();
    }
}

public class CeilingFanOffCommand(CeilingFan fan) : ICommand
{
    private readonly CeilingFan _fan = fan;

    public void Execute()
    {
        _fan.Off();
    }

    public void Undo()
    {
        _fan.On();
    }
}
