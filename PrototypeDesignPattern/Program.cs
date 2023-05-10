

Person p1 = new("Taha", "Pek", Department.A, 8500, 1);

Person p2 = p1.Clone();
p2.Name = "Mahmut";

Console.WriteLine(p2.Name);
Console.WriteLine(p1.Name);



// Abstract Prototyype
interface IPersonClonable
{
    Person Clone();
}

// Concrete Prototype
class Person: IPersonClonable
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public Department Department { get; set; }
    public int Salary { get; set; }
    public int Premium { get; set; }

    public Person(string name, string surname, Department department, int salary, int premium)
    {
        Name = name;
        Surname = surname;
        Department = department;
        Salary = salary;
        Premium = premium;
        Console.WriteLine("Person Oluşturuldu.");
    }

    public Person Clone()
    {
        // o anki instace 'ı klonlar
        return (Person)base.MemberwiseClone();
    }
}

enum Department
{
    A, B, C
}