



ArabaDirector director = new();
Araba araba = director.Builder(new OpelBuilder());
araba.ToString();

araba = director.Builder(new MercedesBuilder());
araba.ToString();

// Product
class Araba
{
    public string Marka { get; set; }
    public string Model { get; set; }
    public double Km { get; set; }
    public bool Vites { get; set; }

    public override string ToString()
    {
        Console.WriteLine($"{Marka} arabada {Model} modelinde {Km} ' de {Vites} vites");

        return base.ToString();
    }
}


// Abstract Builder
interface IAarabaBuilder
{
    public Araba Araba { get; }
    void SetMarka();
    void SetModel();
    void SetKm();
    void SetVites();
}

// Concrete Builder
class OpelBuilder : IAarabaBuilder
{

    public Araba Araba { get;  }

    public OpelBuilder()
    {
        Araba = new Araba();
    }

    public void SetKm()
        => Araba.Km = 0;

    public void SetMarka()
        => Araba.Marka = "Opel Corsa";


    public void SetModel()
        => Araba.Model = "1999";

    public void SetVites()
        => Araba.Vites = true;
}

class MercedesBuilder : IAarabaBuilder
{
    public Araba Araba { get; }

    public MercedesBuilder()
    {
        Araba = new Araba();
    }

    public void SetKm()
        => Araba.Km = 0;

    public void SetMarka()
        => Araba.Marka = "Mercedes Benz";


    public void SetModel()
        => Araba.Model = "2015";

    public void SetVites()
        => Araba.Vites = true;
}

// Director

class ArabaDirector
{
    public Araba Builder(IAarabaBuilder aarabaBuilder)
    {

        aarabaBuilder.SetMarka();
        aarabaBuilder.SetKm();
        aarabaBuilder.SetModel();
        aarabaBuilder.SetVites();


        return aarabaBuilder.Araba;
    }
}