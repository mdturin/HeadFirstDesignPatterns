using HomeAutomation.Concrets;

namespace HomeAutomation;

internal class Program
{
    static void Main(string[] args)
    {
        var livingRoomLight = new Light("Living Room");
        var kitchenLight = new Light("Kitchen");
        var ceilingFan = new CeilingFan("Living Room");
        var garageDoor = new GarageDoor("Garage");
        var stereo = new Stereo("Living Room");

        var livingRoomLightOn = new LightOnCommand(livingRoomLight);
        var livingRoomLightOff = new LightOffCommand(livingRoomLight);

        var kitchenLightOn = new LightOnCommand(kitchenLight);
        var kitchenLightOff = new LightOffCommand(kitchenLight);

        var ceilingFanOn = new CeilingFanOnCommand(ceilingFan);
        var ceilingFanOff = new CeilingFanOffCommand(ceilingFan);

        var garageDoorUp = new GarageDoorUpCommand(garageDoor);
        var garageDoorDown = new GarageDoorDownCommand(garageDoor);

        var stereoOnWithCD = new StereoOnWithCDCommand(stereo);
        var stereoOff = new StereoOffCommand(stereo);

        var control = new RemoteControl(7);
        control.SetCommand(1, livingRoomLightOn, livingRoomLightOff);
        control.SetCommand(2, kitchenLightOn, kitchenLightOff);
        control.SetCommand(3, ceilingFanOn, ceilingFanOff);
        control.SetCommand(4, stereoOnWithCD, stereoOff);

        Console.WriteLine(control);

        control.ExecuteOnButton(1);
        control.ExecuteOffButton(1);

        control.ExecuteOnButton(2);
        control.ExecuteOffButton(2);

        control.ExecuteOnButton(3);
        control.ExecuteOffButton(3);

        control.ExecuteOnButton(4);
        control.ExecuteOffButton(4);
    }
}
