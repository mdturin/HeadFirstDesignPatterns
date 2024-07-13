using HomeAutomation.Interfaces;

namespace HomeAutomation.Concrets;

public class GarageDoor(string name)
{
    private readonly string _name = name;

    public void On()
    {
        Console.WriteLine($"{_name}: Door is on");
    }

    public void Off()
    {
        Console.WriteLine($"{_name}: Door is off");
    }
}

public class GarageDoorUpCommand(GarageDoor door) : ICommand
{
    private readonly GarageDoor _door = door;

    public void Execute()
    {
        _door.On();
    }
}

public class GarageDoorDownCommand(GarageDoor door) : ICommand
{
    private readonly GarageDoor _door = door;

    public void Execute()
    {
        _door.Off();
    }
}