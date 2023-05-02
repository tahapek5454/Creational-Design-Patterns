

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
    public void Run()
    {
        Console.WriteLine("Selam ben A");
    }
}

class B : IProduct
{
    public void Run()
    {
        throw new NotImplementedException();
    }
}

class C : IProduct
{
    public void Run()
    {
        throw new NotImplementedException();
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
        IProduct _product = null;

        switch (type)
        {
            case ProductType.A:
                _product = new A();
                //...
                break;
            case ProductType.B:
                _product = new B();
                //...
                break;
            case ProductType.C:
                _product = new C();
                //...
                break;
            default:
                break;
        }

        return _product;
    }
}

#endregion
