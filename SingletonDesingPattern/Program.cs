


Example ex1 = Example.GetInstance;
Example ex2 = Example.GetInstance;
Example ex3 = Example.GetInstance;
Example ex4 = Example.GetInstance;
Example ex5 = Example.GetInstance;

class Example
{
    private Example() {

        Console.WriteLine($"{nameof(Example)} nesnesi oluşturuldu");
    }

    #region 2.Yöntem için
    // static constructor en en en başta bir kere çağrılır daha sonra çağrılmaz.
    //static Example()
    //{
    //    _example= new Example();
    //}
    #endregion

    //öncekini ya da ilk defa olusturulacak Example nesnesini tutmak için
    private static Example _example;

    //talep etmek için statik membera gitmek gerekir.(metod ya property)
    public static Example GetInstance
    {
        get
        {
            if(_example == null) 
                _example= new Example();

            return _example;


            #region 2. Yöntem için
            // zaten static constructor her halikarde 1 kere çalışacak 
            // kontorlsuz direkt dönderebilirsin.
            // return _example;
            #endregion
        }
    }
        
          
}