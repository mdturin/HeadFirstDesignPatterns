namespace HomeAutomation;

internal class Program
{
    static void Main(string[] args)
    {
        var control = new RemoteControl(7);
        Console.WriteLine(control);
    }
}
