

//... code

GarantiBank gb = ProductCreator.GetIstance(ProductType.GarantiBank) as GarantiBank;
gb.Connection();
gb = ProductCreator.GetIstance(ProductType.GarantiBank) as GarantiBank;
gb.SendMonet(54);

HalkBank HB = ProductCreator.GetIstance(ProductType.HalkBank) as HalkBank;
HB.Connection();
HB = ProductCreator.GetIstance(ProductType.HalkBank) as HalkBank;
HB.SendMonet(54);
//.. code




#region Abstract Product

interface IBank
{
    void Connection();
    void SendMonet(int amount);
}

#endregion

#region Concrete Product

class GarantiBank : IBank
{
    string _userCode, _password;
    private GarantiBank(string userCode, string password)
    {
        Console.WriteLine($"{nameof(GarantiBank)} has been created ! ");
        _userCode= userCode;
        _password= password;
    }

    static GarantiBank()
        => _garantiBank = new GarantiBank("asd", "123");

    static GarantiBank _garantiBank;

    public static GarantiBank GetInstance => _garantiBank;
    public void Connection()
        => Console.WriteLine($"{nameof(GarantiBank)} - Connected");

    public void SendMonet(int amount)
        => Console.WriteLine($"{nameof(GarantiBank)} - {amount} money Sent");
}

class HalkBank : IBank
{
    string _userCode, _password;
    private HalkBank(string userCode, string password)
    {
        Console.WriteLine($"{nameof(HalkBank)} has been created ! ");
        _userCode = userCode;
        _password = password;
    }
    static HalkBank()
        => _halkBank = new HalkBank("asdf", "123456");
    private static HalkBank _halkBank;

    public static HalkBank GetInstance => _halkBank;
    public void Connection()
        => Console.WriteLine($"{nameof(HalkBank)} - Connected");

    public void SendMonet(int amount)
        => Console.WriteLine($"{nameof(HalkBank)} - {amount} money Sent");

}

class CredentialVakifBank : IBank
{

    string _userCode, _password;
    private CredentialVakifBank(string userCode, string password)
    {
        Console.WriteLine($"{nameof(CredentialVakifBank)} has been created ! ");
        _userCode = userCode;
        _password = password;
    }

    static CredentialVakifBank()
        => _credentialVakifBank = new CredentialVakifBank("asdasds", "1");

    private static CredentialVakifBank _credentialVakifBank;

    public static CredentialVakifBank GetInstance => _credentialVakifBank;
    public void Connection()
        => Console.WriteLine($"{nameof(CredentialVakifBank)} - Connected");

    public void SendMonet(int amount)
        => Console.WriteLine($"{nameof(CredentialVakifBank)} - {amount} money Sent");
}

#endregion

#region Abstract Factory
interface IFactory
{
    IBank CreateProduct();
}
#endregion

#region Concrete Factory
class GarantiBankFactory : IFactory
{
    private GarantiBankFactory()
    {
        Console.WriteLine($"{nameof(GarantiBankFactory)} - Factory Has been creeated ! ");
    }
    static GarantiBankFactory()
        => _garantiBankFactory = new GarantiBankFactory();    
    
    private static GarantiBankFactory _garantiBankFactory;

    public static GarantiBankFactory GetInstance => _garantiBankFactory;
    public IBank CreateProduct()
    {
        return GarantiBank.GetInstance;
    }
}

class HalkBankFactory : IFactory
{
    private HalkBankFactory()
    {
        Console.WriteLine($"{nameof(HalkBankFactory)} - factory has benn created");
    }
    static HalkBankFactory()
        => _halkBankFactory= new HalkBankFactory();
    private static HalkBankFactory _halkBankFactory;
    public static HalkBankFactory GetInstance => _halkBankFactory;
    public IBank CreateProduct()
    {
        return HalkBank.GetInstance;
    }
}

class CredentialVakifBankFactory : IFactory
{
    private CredentialVakifBankFactory()
    {
        Console.WriteLine($"{nameof(CredentialVakifBankFactory)} - Factory Has been created");
    }
    static CredentialVakifBankFactory()
        => _credentialVakifBankFactory = new CredentialVakifBankFactory();  
    private static CredentialVakifBankFactory _credentialVakifBankFactory;

    public static CredentialVakifBankFactory GetInstance => _credentialVakifBankFactory;

    public IBank CreateProduct()
    {
        return CredentialVakifBank.GetInstance;
    }
}
#endregion

#region Creator

enum ProductType
{
    GarantiBank, HalkBank, CredentialVakifBank
}

class ProductCreator
{
    public static IBank GetIstance(ProductType type)
    {
        IFactory? _factory = type switch
        {
            ProductType.GarantiBank => GarantiBankFactory.GetInstance,
            ProductType.HalkBank => HalkBankFactory.GetInstance,
            ProductType.CredentialVakifBank => CredentialVakifBankFactory.GetInstance,
            _ => null
        };

        if (_factory == null) return null;

        return _factory.CreateProduct();
    }
}

#endregion
