
var t1 = Task.Run(() =>
{
    Console.WriteLine("Task1");

    Example ex1 = Example.GetInstance;
});

var t2 = Task.Run(() =>
{
    Console.WriteLine("Task2");

    Example ex1 = Example.GetInstance;
});

await Task.WhenAll(t2, t1);

class Example
{
    private Example()
    {
        Console.WriteLine($"{nameof(Example)} has been created.");
    }

    private static Example _example;

    private static object key = new object();
    public static Example GetInstance
    {
        get
        {
            lock (key)
            {
                //kontorle yalniz biri girebilir digeri bekler
                // yoksa ayni anda girip iki kere olusuturuyorlar yok diye
                //simdi biri giricek kitlicek anahatari cebine koyacak
                // bir tane olusuturucak sonra ne olucak zaten olustugu için digeri olusturmayacak
                if (_example == null)
                    _example = new Example();
            }
            return _example;
            // ikinci yontemi kullancaksan bu tarz islere gerek kalmaz statik contructor bir kere çalışır illa
        }
    }
}