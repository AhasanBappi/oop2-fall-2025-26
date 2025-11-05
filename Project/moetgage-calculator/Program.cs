using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Simple Calculator");
            Console.WriteLine("-----------------");
            Console.WriteLine("1. Addition (+)");
            Console.WriteLine("2. Subtraction (-)");
            Console.WriteLine("3. Multiplication (*)");
            Console.WriteLine("4. Division (/)");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option (1-5): ");


            cultureInfo bdculture = new cultureInfo("bn-BD");

            Console.WriteLine($"\nMOnthly payment: {monthlypayment.ToString{"c", bdculture)}");
            Console.WriteLine($"Total paid: {totalpaid payment:.ToString{"c", bdculture)}");
            Console.WriteLine($"Total interest: {totalInterest.ToString{"c", bdculture)}");
        }
    }
}
