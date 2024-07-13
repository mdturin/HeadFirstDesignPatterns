using HomeAutomation.Interfaces;

namespace HomeAutomation.Concrets;

public class Stereo(string name)
{
    private int Volume { get; set; }
    private readonly string _name = name;
    public void On()
    {
        Console.WriteLine($"{_name}: Stereo is on");
    }

    public void Off()
    {
        Console.WriteLine($"{_name}: Stereo is off");
    }

    public void SetCD()
    {
        Console.WriteLine($"{_name}: Stereo is setting CD");
    }

    public void SetVolume(int volume)
    {
        Volume = volume;
        Console.WriteLine(
            $"{_name}: Stereo is set Volume to: {volume}");
    }
}

public class StereoOnWithCDCommand(Stereo stereo) : ICommand
{
    private readonly Stereo _stereo = stereo;

    public void Execute()
    {
        _stereo.On();
        _stereo.SetCD();
        _stereo.SetVolume(10);
    }

    public void Undo()
    {
        _stereo.Off();
    }
}

public class StereoOffCommand(Stereo stereo) : ICommand
{
    private readonly Stereo _stereo = stereo;

    public void Execute()
    {
        _stereo.Off();
    }

    public void Undo()
    {
        _stereo.On();
        _stereo.SetCD();
        _stereo.SetVolume(10);
    }
}