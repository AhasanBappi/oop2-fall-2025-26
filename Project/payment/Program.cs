using System;

abstract class Payment
{
    public abstract void ProcessPayment(double amount);
}

class BkashPayment : Payment
{
    private double lastAmount;

    public override void ProcessPayment(double amount)
    {
        this.lastAmount = amount;
        Console.WriteLine("Processing Bkash payment: " + this.lastAmount);
    }
}

class CreditCardPayment : Payment
{
    private double lastAmount;

    public override void ProcessPayment(double amount)
    {
        this.lastAmount = amount;
        Console.WriteLine("Processing Credit Card payment: " + this.lastAmount);
    }
}

class Program
{
    static void Main()
    {
        Payment p1 = new BkashPayment();
        Payment p2 = new CreditCardPayment();

        p1.ProcessPayment(500);
        p2.ProcessPayment(1200);
    }
}