using System;

abstract class Member
{
    private string name;
    private int memberId;

    public Member(string name, int memberId)
    {
        this.name = name;
        this.memberId = memberId;
    }

    public abstract int CalculateFee();
}

class StudentMember : Member

{
    public StudentMember(string name, int id) : base(name, id)
    {
    }

    public override int CalculateFee()
    {
        return 300;
    }
}

class RegularMember : Member
{
    public RegularMember(string name, int id) : base(name, id)
    {
    }

    public override int CalculateFee()
    {
        return 500;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Member s = new StudentMember("Rahim", 1);
        Member r = new RegularMember("Karim", 2);

        Console.WriteLine("Student Fee: " + s.CalculateFee());
        Console.WriteLine("Regular Fee: " + r.CalculateFee());
    }
}