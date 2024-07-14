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
    }
}

public interface IEventArgs { }
public interface IStateEventArgs : IEventArgs
{
    ButtonState State { get; set; }
}

public abstract class AStateEventArgs(ButtonState state) : IStateEventArgs
{
    public ButtonState State { get; set; } = state;
}

public class CommandArgs(ButtonState state) : AStateEventArgs(state) { }

public interface ICommand
{
    bool CanExecute();
    void Execute(object? sender, IEventArgs args);
}

public enum ButtonState
{
    On,
    Off
}

public abstract class AState(ButtonState state = ButtonState.Off)
{
    protected ButtonState State { get; set; } = state;
    public void ChangeState(ButtonState state)
        => State = state;
    public ButtonState GetState() => State;
}

public class None : AState { }

public class Light : AState { }

public class Fan : AState { }

public class Ac : AState { }

public abstract class ACommand(AState state) : ICommand
{
    private readonly AState _state = state;

    public virtual bool CanExecute() => true;

    public virtual void Execute(object? sender, IEventArgs args)
    {
        if (!CanExecute()) return;
        if (args is AStateEventArgs stateArgs)
            _state.ChangeState(stateArgs.State);
    }

    public ButtonState GetState() => _state.GetState();
}

public class LightCommand(AState light) : ACommand(light) { }
public class FanCommand(AState fan) : ACommand(fan) { }
public class AcCommand(AState ac) : ACommand(ac) { }
public class NoCommand(None none) : ACommand(none) 
{
    public override bool CanExecute() => false;
}

public class RemoteController
{
    private List<ICommand> Commands { get; set; } = [];
    public RemoteController(int slot)
    {
        ICommand noCommand = new NoCommand(new None());
        Commands = Enumerable
            .Repeat(noCommand, slot)
            .ToList();
    }

    public void SetCommand(int slot, ICommand command)
    {
        if (slot >= 0 && slot < Commands.Count)
            Commands[slot] = command;
        else
            throw new ArgumentOutOfRangeException(
                nameof(slot), slot, "Invalid command index");
    }

    public void Execute(int slot, IEventArgs eventArgs)
    {
        if (slot >= 0 && slot < Commands.Count)
        {
            Commands[slot].Execute(this, eventArgs);
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
            if (Commands[slot] is ACommand command)
            {
                var state = command.GetState();
                var toggleState = ToggleState(state);
                var args = new CommandArgs(toggleState);
                Execute(slot, args);
            }
        }
        else
        {
            throw new ArgumentOutOfRangeException(
                nameof(slot), slot, "Invalid command index");
        }
    }

    private static ButtonState ToggleState(ButtonState state)
    {
        if (state == ButtonState.On)
            return ButtonState.Off;
        if (state == ButtonState.Off)
            return ButtonState.On;
        throw new ArgumentOutOfRangeException(
                nameof(state), state, "Invalid State");
    }
}