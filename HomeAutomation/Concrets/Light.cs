using HomeAutomation.Interfaces;

namespace HomeAutomation.Concrets;

public class Light(string name)
{
    private readonly string _name = name;

    public void On()
    {
        Console.WriteLine($"{_name}: Light is on");
    }

    public void Off()
    {
        Console.WriteLine($"{_name}: Light is off");
    }
}

public class LightOnCommand(Light light) : ICommand
{
    private readonly Light _light = light;

    public void Execute()
    {
        _light.On();
    }

    public void Undo()
    {
        _light.Off();
    }
}

public class LightOffCommand(Light light) : ICommand
{
    private readonly Light _light = light;

    public void Execute()
    {
        _light.Off();
    }

    public void Undo()
    {
        _light.On();
    }
}
