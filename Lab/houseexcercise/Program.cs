using System;

public class House
{
    public int YearBuilt { get; private set; }
    public double Size { get; private set; }

    public House(int yearBuilt, double size)
    {
        YearBuilt = yearBuilt;
        Size = size;
    }

    private int HowOld()
    {
        int currentYear = DateTime.Now.Year;
        return currentYear - YearBuilt;
    }

    public bool CanBeSold()
    {
        int age = HowOld();
        return age > 15;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"\nHouse built in: {YearBuilt}");
        Console.WriteLine($"Size: {Size} sq.m");
        Console.WriteLine($"Age: {DateTime.Now.Year - YearBuilt} years");
        Console.WriteLine($"Can be sold: {CanBeSold()}");
    }
}

public class Program
{
    public static void Main()
    {
        Console.Write("Enter the year the house was built: ");
        int year = int.Parse(Console.ReadLine());

        Console.Write("Enter the size of the house (in sq.m): ");
        double size = double.Parse(Console.ReadLine());

        House house = new House(year, size);

        house.ShowInfo();
    }
}