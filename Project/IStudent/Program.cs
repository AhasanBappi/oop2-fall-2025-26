using System;
interface IStudent
{
    void Display();
}
class Student : IStudent
{
    private string name;
    private int[] marks = new int[3];
    public Student(string name)
    {
        this.name = name;
    }
    public int this[int index]
    {
        get { return marks[index]; }
        set { marks[index] = value; }
    }
    public void Display()
    {
        Console.WriteLine("Student Name: " + name);
        for (int i = 0; i < marks.Length; i++)
        {
            Console.WriteLine("Mark " + (i + 1) + ": " + marks[i]);
        }
    }
}
class Program
{
    static void Main()
    {
        Student s = new Student("Ahsan");
        s[0] = 80;
        s[1] = 75;
        s[2] = 90;
        s.Display();
    }
}