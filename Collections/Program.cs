using System.Collections;
using static System.Collections.IEnumerable;
using static System.Console;

namespace Collections;

enum FinancePlan { government_sponsored, private_sponsered, scholarship }

class Student : IComparable
{
    public string? Name { get; init; }
    public FinancePlan? Plan { get; init; }
    public int? ID { get; init; }

    public int CompareTo(int? iD, Student? s)
    {
        return CompareTo(s.ID, ID);
    }

    public override string ToString()
    {
        return $"Student :> {Name} on {Plan}";
    }
}


class Class : IEnumerable
{
    public DateTime YearStarted { get; init; }
    public (int, int) CurrentYearAndSemester { get; init; }
    public Student[]? Students { get; init; }

    IEnumerator IEnumerable.GetEnumerator()
    {
        foreach (var student in Students ?? Array.Empty<Student>())
        {
            yield return student;
        }
    }

}

class Program
{
    static void Main()
    {
        var students = new Student[]{
            new Student {Name="Denni", Plan=FinancePlan.government_sponsored},
            new Student {Name="Allan", Plan=FinancePlan.scholarship},
            new Student {Name="Wilkins", Plan=FinancePlan.private_sponsered}
        };
        Array.Reverse(students);
        var firstClass = new Class { YearStarted = DateTime.Now, CurrentYearAndSemester = (1, 1), Students = students };

        foreach (var s in firstClass)
        {
            WriteLine(s);
        }
    }
}

