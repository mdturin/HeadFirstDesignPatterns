using System;

namespace SmartHome;

internal class Program
{
    static void Main(string[] args)
    {
        var controller = new RemoteController(5);
        controller.SetCommand(0, new LightCommand(new Light()));
        controller.SetCommand(1, new FanCommand(new Fan()));
        controller.SetCommand(2, new AcCommand(new Ac()));

        controller.Execute(0);

        controller.Execute(1);

        controller.Execute(2);

        controller.Execute(2);

        controller.Execute(1);

        controller.Execute(0);

        controller.Undo();
    }
}

public interface ICommand
{
    bool CanExecute();
    void Execute(object? sender);
    void Undo();
}

public enum ButtonState
{
    On,
    Off
}

public class Light
{
    protected ButtonState State { get; set; }
        = ButtonState.Off;
    public void ChangeState(ButtonState state)
        => State = state;
    public ButtonState GetState() => State;
    public void ToggleState()
    {
        if (State == ButtonState.On)
            ChangeState(ButtonState.Off);
        else
            ChangeState(ButtonState.On);
    }
}

public class Fan
{
    protected ButtonState State { get; set; }
        = ButtonState.Off;
    public void ChangeState(ButtonState state)
        => State = state;
    public ButtonState GetState() => State;
    public void ToggleState()
    {
        if (State == ButtonState.On)
            ChangeState(ButtonState.Off);
        else
            ChangeState(ButtonState.On);
    }
}

public class Ac
{
    protected ButtonState State { get; set; }
        = ButtonState.Off;
    public void ChangeState(ButtonState state)
        => State = state;
    public ButtonState GetState() => State;
    public void ToggleState()
    {
        if (State == ButtonState.On)
            ChangeState(ButtonState.Off);
        else
            ChangeState(ButtonState.On);
    }
}

public abstract class ACommand() : ICommand
{
    public virtual bool CanExecute() => true;

    public abstract void Execute(object? sender);

    public abstract void Undo();
}

public class LightCommand(Light light) : ACommand()
{
    public override void Execute(object? sender)
    {
        if (!CanExecute()) return;
        light.ToggleState();
        Console.WriteLine("Light State: " + light.GetState().ToString());
    }

    public override void Undo()
    {
        if (!CanExecute()) return;
        light.ToggleState();
        Console.WriteLine("Light State: " + light.GetState().ToString());
    }
}

public class FanCommand(Fan fan) : ACommand()
{
    public override void Execute(object? sender)
    {
        if (!CanExecute()) return;
        fan.ToggleState();
        Console.WriteLine("Fan State: " + fan.GetState().ToString());
    }

    public override void Undo()
    {
        if (!CanExecute()) return;
        fan.ToggleState();
        Console.WriteLine("Fan State: " + fan.GetState().ToString());
    }
}

public class AcCommand(Ac ac) : ACommand()
{
    public override void Execute(object? sender)
    {
        if (!CanExecute()) return;
        ac.ToggleState();
        Console.WriteLine("Ac State: " + ac.GetState().ToString());
    }

    public override void Undo()
    {
        if (!CanExecute()) return;
        ac.ToggleState();
        Console.WriteLine("Ac State: " + ac.GetState().ToString());
    }
}

public class NoCommand() : ACommand()
{
    public override void Execute(object? sender)
    {
    }

    public override void Undo()
    {
    }
}

public class RemoteController
{
    private ICommand UndoCommand { get; set; } = new NoCommand();
    private List<ICommand> Commands { get; set; } = [];
    public RemoteController(int slot)
    {
        ICommand noCommand = new NoCommand();
        Commands = Enumerable
            .Repeat(noCommand, slot)
            .ToList();
    }

    public void SetCommand(int slot, ICommand command)
    {
        if (slot >= 0 && slot < Commands.Count)
        {
            Commands[slot] = command;
        }
        else
        {
            throw new ArgumentOutOfRangeException(
                nameof(slot), slot, "Invalid command index");
        }
    }

    public void Execute(int slot)
    {
        if (slot >= 0 && slot < Commands.Count)
        {
            Commands[slot].Execute(this);
            UndoCommand = Commands[slot];
        }
        else
        {
            throw new ArgumentOutOfRangeException(
                nameof(slot), slot, "Invalid command index");
        }
    }

    public void Undo() => UndoCommand.Undo();
}