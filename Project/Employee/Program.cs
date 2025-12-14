using System;

abstract class Employee
{
    public double basicSalary;

    public abstract double GetTotalSalary();
}

class Manager : Employee
{
    public override double GetTotalSalary()
    {
        return basicSalary + 2000;
    }
}

class Worker : Employee
{
    public override double GetTotalSalary()
    {
        return basicSalary + 800;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Manager m = new Manager();
        m.basicSalary = 10000;

        Worker w = new Worker();
        w.basicSalary = 8000;

        Console.WriteLine("Manager Salary: " + m.GetTotalSalary());
        Console.WriteLine("Worker Salary: " + w.GetTotalSalary());
    }
}