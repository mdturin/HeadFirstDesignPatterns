namespace HomeAutomation.Interfaces;

public interface ICommand
{
	void Execute();
	void Undo();
}