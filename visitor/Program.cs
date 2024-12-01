public interface IVisitor
{
    void Visit(Manager manager);
    void Visit(Developer developer);
}

public class SalaryCalculator : IVisitor
{
    public void Visit(Manager manager)
    {
        Console.WriteLine($"Зарплата менеджера: {manager.Salary}");
    }

    public void Visit(Developer developer)
    {
        Console.WriteLine($"Зарплата разработчика: {developer.Salary}");
    }
}


public interface IEmployee
{
    void Accept(IVisitor visitor);
}

public class Manager : IEmployee
{
    public double Salary { get; set; }

    public Manager(double salary)
    {
        Salary = salary;
    }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class Developer : IEmployee
{
    public double Salary { get; set; }

    public Developer(double salary)
    {
        Salary = salary;
    }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

class Program
{
    static void Main(string[] args)
    {
        IEmployee[] employees = new IEmployee[]
        {
            new Manager(80000),
            new Developer(60000)
        };

        IVisitor salaryCalculator = new SalaryCalculator();

        foreach (var employee in employees)
        {
            employee.Accept(salaryCalculator);
        }
    }
}
