﻿using HomeAutomation.Concrets;
using HomeAutomation.Interfaces;
using System.Text;

namespace HomeAutomation;

public class RemoteControl
{
    private ICommand UndoCommand { get; set; }
    private List<ICommand> OnCommands { get; set; } = [];
    private List<ICommand> OffCommands { get; set; } = [];

    public RemoteControl(int slot)
    {
        ICommand noCommand = new NoCommand();
        OnCommands = Enumerable
            .Repeat(noCommand, slot)
            .ToList();

        OffCommands = Enumerable
            .Repeat(noCommand, slot)
            .ToList();

        UndoCommand = noCommand;
    }

    public void SetCommand(
        int slot, ICommand onCommand, ICommand offCommand)
    {
        if (slot <= 0 || slot > OnCommands.Count)
            throw new ArgumentOutOfRangeException(
                $"{slot} is not valid control postion");

        OnCommands[slot - 1] = onCommand;
        OffCommands[slot - 1] = offCommand;
    }

    public void ExecuteOnButton(int slot)
    {
        if (slot <= 0 || slot > OnCommands.Count)
            throw new ArgumentOutOfRangeException(
                $"{slot} is not valid control postion");

        OnCommands[slot - 1].Execute();
        UndoCommand = OnCommands[slot - 1];
    }

    public void ExecuteOffButton(int slot)
    {
        if (slot <= 0 || slot > OnCommands.Count)
            throw new ArgumentOutOfRangeException(
                $"{slot} is not valid control postion");

        OffCommands[slot - 1].Execute();
        UndoCommand = OffCommands[slot - 1];
    }

    public void Undo() => UndoCommand.Undo();

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine(
            "---------------- Remote Control -----------------");
        for (var i = 0; i < OnCommands.Count; ++i)
        {
            sb.Append($"[slot {i + 1}]:\t");
            sb.Append(string.Format("{0, -25}", 
                OnCommands[i].GetType().Name));
            sb.AppendLine(OffCommands[i].GetType().Name);
        }

        sb.Append("[Undo] ");
        sb.AppendLine(UndoCommand.GetType().Name);

        return sb.ToString();
    }
}
