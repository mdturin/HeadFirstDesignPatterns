using System.Reflection;

namespace PaymentGateway;

internal class Program
{
    static void Main(string[] args)
    {
        var factory = new PaymentFactory();
        var payPal = factory
            .CreatePaymentMethod(PaymentType.PayPal);
        payPal.Transfer(1000);
    }
}

[AttributeUsage(AttributeTargets.Class)]
public class PaymentAttribute : Attribute
{
    public PaymentType Type { get; set; }
}

public interface IPayment
{
    void Transfer(double value);
}

[Payment(Type = PaymentType.CreditCard)]
public class CreditCard : IPayment
{
    public void Transfer(double value)
    {
        Console.WriteLine($"Paying {value} from credit card");
    }
}

[Payment(Type = PaymentType.PayPal)]
public class PayPal : IPayment
{
    public void Transfer(double value)
    {
        Console.WriteLine($"Paying {value} from pay pal");
    }
}

[Payment(Type = PaymentType.BankTransfer)]
public class BankTransfer: IPayment
{
    public void Transfer(double value)
    {
        Console.WriteLine($"Paying {value} from bank");
    }
}

public enum PaymentType
{
    CreditCard,
    PayPal,
    BankTransfer
}

public class PaymentFactory
{
    private readonly Dictionary<PaymentType, Type> _types = [];
    public static List<Type> GetImplementationsOfInterface<T>()
    {
        var interfaceType = typeof(T);
        var assembly = Assembly.GetExecutingAssembly();
        return assembly.GetTypes()
            .Where(t => interfaceType.IsAssignableFrom(t) && t.IsClass)
            .ToList();
    }

    public PaymentFactory()
    {
        var implementations = GetImplementationsOfInterface<IPayment>();
        foreach(var implementation in implementations)
        {
            var attr = implementation.GetCustomAttribute<PaymentAttribute>();
            if(attr != null)
                _types.TryAdd(attr.Type, implementation);
        }
    }

    public IPayment CreatePaymentMethod(PaymentType type)
    {
        if(_types.TryGetValue(type, out var implementation))
        {
            var instance = Activator.CreateInstance(implementation);
            if (instance is IPayment _instance)
                return _instance;

            throw new Exception($"Couldn't create object of type: {instance}");
        }

        throw new ArgumentOutOfRangeException(nameof(type), type, "Invalid payment type");
    }
}