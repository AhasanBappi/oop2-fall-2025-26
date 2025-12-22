using System;

namespace DelegateDemo
{


    public delegate int Operation(int a, int b);

    class Program
    {
        static int Add(int x, int y)
        {
            return x + y;
        }

        static int Subtract(int x, int y)
        {
            return x - y;
        }

        static void Calculate(int a, int b, Operation op)
        {
            int result = op(a, b);
            Console.WriteLine("Result: " + result);
        }

        static void Main(string[] args)
        {
            Calculate(10, 5, Add);
            Calculate(10, 5, Subtract);
        }
    }
}