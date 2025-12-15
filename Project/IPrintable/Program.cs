using System;
interface IPrintable
{
    void Print();
}
interface ISerializable
{
    void Save();
}
class Report : IPrintable, ISerializable
{
    public void Print()
    {
        Console.WriteLine("Printing the report");
    }
    public void Save()
    {
        Console.WriteLine("Saving the report");
    }
}
class Program
{
    static void Main()
    {
        Report r = new Report();
        r.Print();
        r.Save();
    }
}