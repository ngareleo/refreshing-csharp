namespace _06LINQ;

using System.Linq;
using static System.Console;

enum House
{
    LANET,
    MOI,
    NANYUKI,
    MOMBASA,
}

enum Grade
{
    A,
    B,
    C,
    D,
    E,
}

record Student(string Name, int Id, Grade? Grade, House House)
{
    public static House[] Houses = Enum.GetValues<House>();
    public static int HousesCount = Houses.Length;

    public static House GetRandomHouse() => Houses[new Random().Next(HousesCount)];

    public override string ToString()
    {
        return $$""""
                 name:  {{Name}},
                 ID:    {{Id}},
                 grade: {{Grade}},
                 house: {{House}},
            """";
    }

    public static void PrettyPrintStudents(IEnumerable<Student> students)
    {
        int studentsPCol = 5;
        int rowPStudent = 4;
        var s = students.ToArray();
        // We print students details, 5 students wide per screen width, downwards
        // For each student we get a 2d array of bytes

        Func<Student, char[][]> flatten = delegate(Student s)
        {
            var rows = s.ToString().Split('\n');
            var res = new char[rowPStudent][];
            for (int i = 0; i < rowPStudent; i++)
            {
                res[i] = rows[i].ToArray();
            }
            return res;
        };

        /// <summary>We assume that all nested arrays have same shape</summary>
        Func<char[][][], int, char[][]> orderFlatList = delegate(char[][][] o, int max)
        {
            if (o.Length == 0)
            {
                return new char[0][];
            }
            var s = o[0].Length;
            var totalRows = o.Length / (max + 1) * s + o.Length / (max + 1);
            var result = new char[totalRows][];

            for (int i = 0, iter = 0, depth = 0; i < totalRows; i++, iter = i / max, depth = i % s)
            {
                if (i % rowPStudent == 0)
                {
                    result[iter] = new char[] { '\n' };
                    continue;
                }
                result[iter] = o[iter][depth];
            }
            return result;
        };

        var flatList = orderFlatList(students.Select(s => flatten(s)).ToArray(), studentsPCol);

        foreach (var line in flatList)
        {
            var str = string.Join("", line);
            WriteLine($"{str}");
        }
    }

    /// <summary>A factory for students assigning them a random house.</summary>
    public static IEnumerable<Student> StudentFactory(IEnumerable<string> names) =>
        names.Select((n) => new Student(n, 0, null, GetRandomHouse()));
}

class Program
{
    static void Main()
    {
        // IEnumerables are the basic unit for C#
        string[] names = { "Harry", "Tom", "Jerry", "Tate", "Charlene", "Obama" };
        // This can be referred to as a local sequence because its a local collection of something

        var shortNames = names.Where((n) => n.Length <= 3);
        Pretty("\nShort names : ", shortNames);
        var namesWithRs = names.Where((n) => n.ToUpper().Contains("R"));
        Pretty("\nNames with R", namesWithRs);

        var students = Student.StudentFactory(names);
        Pretty(students);

        var twoStudentsInNanyukiHouse = students.Where((s) => s.House == House.NANYUKI).Take(2);
        students.Append(new Student("Francis", 23, null, House.NANYUKI));

        Student.PrettyPrintStudents(twoStudentsInNanyukiHouse);

        // This is defined as a query expression
        var aStudentInLanet = (from s in students where s.House == House.LANET select s).First();
        WriteLine($"\n\nA student in Lanet {aStudentInLanet}");

        int factor = 2;
        var nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 10, 12, 21 }; // Query is declared here
        var even = nums.Where((n) => n % factor == 0);

        factor = 3;
        Pretty(even); // This is when the query is executed

        // The enumerable will execute not when declared but when enumerated
        // i.e. inside of Pretty

        // There are exceptions to this rule,
        // 1. Using a terminal Operators that return a single value such as Count() and First()
        // 2. Using converter operators that convert the end result to an Object like `ToList`

        var doubled = nums.Select((n) => n.ToString()).Aggregate((a, b) => $"{a}|{b}");

        // The query is called lazily at this point
        WriteLine($"Doubled: {doubled}");

        // Imagine this query did something expensive like write some value to a file

        // Iterating over the result would re-execute the query over and over. Costing you a tonne
        var payload = nums.Select((n) => ExpensiveWriteToFile(n).ToString())
            .Aggregate((acc, el) => $"{acc}, {el}");

        WriteLine($"PayloadValue {payload}");
    }

    static int ExpensiveWriteToFile(int value)
    {
        // Imagine this was an expensive write to a server
        return value *= 4;
    }

    static void Pretty<T>(string left, IEnumerable<T> e)
    {
        var str = e.Where(s => s != null)
            .Select(s => s?.ToString())
            .Aggregate((acc, val) => $"{acc}, {val}");
        WriteLine($"[ {left}\n{str} ]");
    }

    static void Pretty<T>(IEnumerable<T> e)
    {
        var str = e.Where(s => s != null)
            .Select(s => s?.ToString())
            .Aggregate((acc, val) => $"{acc}, {val}");
        WriteLine($"[ \n{str} ]");
    }

    static void Pretty<T>(string left, IEnumerable<T> e, string right)
    {
        WriteLine(left);
        foreach (var v in e)
        {
            WriteLine(v);
        }
        WriteLine(right);
    }
}
