
namespace _06LINQ;

using static System.Console;
using System.Linq;


enum House { LANET, MOI, NANYUKI, MOMBASA }
enum Grade { A, B, C, D, E }

record Student(string Name, int Id, Grade? Grade, House House)
{
    public static House[] Houses = Enum.GetValues<House>();
    public static int HousesCount = Houses.Length;

    public static House GetRandomHouse() => Houses[new Random().Next(HousesCount)];

    public override string ToString()
    {
        return $$""""
               {
                 name:  {{Name}},
                 ID:    {{Id}},
                 grade: {{Grade}},
                 house: {{House}}
               }
            """";
    }

    /// <summary>A factory for students assigning them a random house.</summary>
    public static IEnumerable<Student> StudentFactory(IEnumerable<string> names)
        => names.Select((n) => new Student(n, 0, null, GetRandomHouse()));

}

class Program
{

    static void Main()
    {
        // IEnumerables are the basic unit for C#
        string[] names = { "Harry", "Tom", "Jerry", "Tate", "Messi", "Obama" };
        // This can be referred to as a local sequence because its a local collection of something


        var shortNames = names.Where((n) => n.Length <= 3);
        Pretty("\nShort names : ", shortNames);
        var namesWithRs = names.Where((n) => n.ToUpper().Contains("R"));
        Pretty("\nNames with R", namesWithRs);

        var students = Student.StudentFactory(names);
        Pretty(students);


        var twoStudentsInNanyukiHouse = students.Where((s) => s.House == House.NANYUKI).Take(2);
        // Values are captured during execution
        students.Append(new Student("Vasily", 23, null, House.NANYUKI));

        Pretty("\n\nTwo students in Nanyuki house ", twoStudentsInNanyukiHouse);

        // This is defined as a query expression
        var aStudentInLanet = (from s in students
                               where s.House == House.LANET
                               select s
                               ).First();
        WriteLine($"\n\nA student in Lanet {aStudentInLanet}");

        int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 10, 12, 21 };
        var even = nums.Where((n) => n % 2 == 0);
        // The enumerable will execute not when declared but when enumerated. Meaning, you read from the enumerator
        // That's inside of Pretty

        nums.Append(100);
        // We inputs are captured during declaration. So you cannot inject anything after

        Pretty(even);
    }



    static void Pretty<T>(string left, IEnumerable<T> e, string right = "")
    {
        WriteLine(left);
        foreach (var v in e)
        {
            WriteLine(v);
        }
        if (!string.IsNullOrEmpty(right))
        {
            WriteLine("additional");
        }
    }
    static void Pretty<T>(IEnumerable<T> e, string? right = null)
    {
        foreach (var v in e)
        {
            WriteLine(v);
        }
        if (!string.IsNullOrEmpty(right))
        {
            WriteLine("additional");
        }

    }
}

