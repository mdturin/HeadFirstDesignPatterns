using HomeAutomation.Concrets;

namespace HomeAutomation;

internal class Program
{
    static void Main(string[] args)
    {
        var control = new RemoteControl(7);

        var livingRoomLight = new Light("Living Room");
        var kitchenLight = new Light("Kitchen");
    }
}
