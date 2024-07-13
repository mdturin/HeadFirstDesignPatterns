namespace NotificationSystem;

internal class Program
{
    static void Main(string[] args)
    {
        var user = new User()
        {
            Name = "Md Turin",
            Email = "Turin@Test.Com",
            BirthOfDate = new DateTime(2000, 1, 1)
        };

        var userService = new UserService();
        var emailService = new EmailService(userService);
        var welcomeService = new WelcomeService(userService);
        userService.UserRegister(user);
    }
}

public interface IEventArgs
{
}

public interface IObserver
{
    void Update(ISubject sender, IEventArgs args);
}

public interface ISubject
{
    void Register(params IObserver[] observers);
    void Remove(params IObserver[] observers);
    void Notify(IEventArgs args);
}

public class User
{
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime BirthOfDate { get; set; }
}

public class UserRegisteredEventArgs: IEventArgs
{
    public User User { get; set; }
}

public class UserService : ISubject
{
    private List<IObserver> Observers { get; set; } = [];

    public void Notify(IEventArgs args)
    {
        Parallel.ForEach(Observers, (obs) =>
        {
            obs.Update(this, args);
        });
    }

    public void Register(params IObserver[] observers)
    {
        lock (Observers)
        {
            Observers.AddRange(observers);
        }
    }

    public void Remove(params IObserver[] observers)
    {
        lock (Observers)
        {
            foreach (var obs in observers)
                Observers.Remove(obs);
        }
    }

    public void UserRegister(User user)
    {
        var args = new UserRegisteredEventArgs()
        {
            User = user
        };

        Notify(args);
    }
}

public class EmailService : IObserver
{
    public EmailService(ISubject subject)
    {
        subject.Register(this);
    }

    public void SendMail(User user)
    {
        Console.WriteLine($"Sending Mail: {user.Email}");
    }

    public void Update(ISubject sender, IEventArgs args)
    {
        if(args is UserRegisteredEventArgs userArgs)
        {
            SendMail(userArgs.User);
        }
    }
}

public class WelcomeService : IObserver
{
    public WelcomeService(ISubject subject)
    {
        subject.Register(this);
    }

    public void WelcomeUser(User user)
    {
        Console.WriteLine($"Welcome {user.Name}.");
    }

    public void Update(ISubject sender, IEventArgs args)
    {
        if (args is UserRegisteredEventArgs userArgs)
        {
            WelcomeUser(userArgs.User);
        }
    }
}