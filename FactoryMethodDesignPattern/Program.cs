

//... code

A? product = ProductCreator.GetIstance(ProductType.A) as A;
product?.Run();

//.. code




#region Abstract Product

interface IProduct
{
    void Run();
}

#endregion

#region Concrete Product

class A : IProduct
{

    public A()
    {
        Console.WriteLine($"{nameof(A)} has been created !");
    }

    public void Run()
    {
        Console.WriteLine("Selam ben A");
    }
}

class B : IProduct
{

    public B()
    {
        Console.WriteLine($"{nameof(B)} has been created !");
    }
    public void Run()
    {
        throw new NotImplementedException();
    }
}

class C : IProduct
{

    public C()
    {
        Console.WriteLine($"{nameof(C)} has been created !");
    }

    public void Run()
    {
        throw new NotImplementedException();
    }
}

#endregion

#region Abstract Factory
interface IFactory
{
    IProduct CreateProduct();
}
#endregion

#region Concrete Factory
class AFactory : IFactory
{
    public IProduct CreateProduct()
    {
        return new A();
    }
}

class BFactory : IFactory
{
    public IProduct CreateProduct()
    {
        return new B();
    }
}

class CFactory : IFactory
{
    public IProduct CreateProduct()
    {
        return new C();
    }
}
#endregion

#region Creator

enum ProductType
{
    A, B, C
}

class ProductCreator
{
    public static IProduct GetIstance(ProductType type)
    {
        IFactory? _factory = type switch
        {
            ProductType.A => new AFactory(),
            ProductType.B => new BFactory(),
            ProductType.C => new CFactory(),
            _ => null
        };

        if (_factory == null) return null;

        return _factory.CreateProduct();
    }
}

#endregion
