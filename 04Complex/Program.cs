using static System.Console;
namespace _04Complex;

// A delegate is an object that knows how to call a function
// this transformer is compatible with any method that takes an int and returns an int
delegate T Transformer<T>(T x);

// delegates are only considered equal when they point to the same functions
// otherwise two delegates even if they have same signatures cannot be equal

delegate T Quantifier<T>(T t);

// The general advice is to fancy using records whenever you want to deal with immutable data.
// In which case this works well for servers, which only handle data through storage and bridging the db with the client
// 
// It is a compile time construct, its still treated as a class (referencial type) by the CLR
// However it gurantees immutability and they come with structural equality instead of referencial equality.
// This makes it very performant.
record Movie
{
    public string? Title { get; init; }
    public List<MovieGenre>? Genres { get; init; }
    public string? Description { get; init; }
    public int? Length { get; init; }
}

enum MovieGenre { comedy, drama, action, adventure, science_fiction, thriller, horror }

// Adding a ref keyword before a struct ensures that the struct will always live on the stack and not the heap
ref struct Operation<T>
{
    public string? Name { get; set; }
    public Transformer<T>? Op { get; set; }
}

enum ConnectionMethod { GET, POST, PUT };

class Connection
{
    public readonly static TimeSpan Timeout = TimeSpan.FromSeconds(2);
    public string? Url { get; init; }
    public ConnectionMethod Method { get; init; }
    public DateTime Opened = DateTime.Now;

    ~Connection() => WriteLine("This instance's last moment before the GC sweeps it away");

}


class Program
{
    static bool Classify(Movie movie) => movie switch
    {
        { Length: var l, Genres: var g } => l < 90 && g.Contains(MovieGenre.comedy) || (g.Contains(MovieGenre.drama))
    };

    static (int, int, int) DateTupled()
    {
        var d = DateTime.Now;
        return (d.Year, d.Month, d.Day);
    }

    static void TryTransform<T>(T value, Operation<T> o, out T output)
    {
        if (o.Op == null) {
            throw new ArgumentException("cannot provide operation with null values");
        }
        output = o.Op(value);
        // All of them get called but only the value of the last value is called
        WriteLine($"Transformation [{o.Name}] {value} to {output}");
    }


    static void Main()

    {
        Transformer<double> tan = delegate (double x)
        {
            var v = Math.Tan(x);
            WriteLine($"[Tan] Got {x}, Spitting {v}");
            return v;
        };
        Transformer<double> sin = delegate (double x)
        {
            var v = Math.Sin(x);
            WriteLine($"[Sin] Got {x}, Spitting {v}");
            return v;
        };
        Transformer<double> cos = delegate (double x)
        {
            var v = Math.Cos(x);
            WriteLine($"[Cos] Got {x}, Spitting {v}");
            return v;
        };
        var operation = new Operation<double> { Name = "Tan | Sin | Cos", Op = tan + sin + cos };
        double o;
        TryTransform(10.223, operation, out o);

        if (o < 0) { }

        WriteLine(tan == sin);
        WriteLine(nameof(operation));

        using (var enumerator = "random".GetEnumerator())
            while (enumerator.MoveNext())
            {
                WriteLine($"{enumerator.Current}");
            }

        var conn = new Connection { Url = "http:/232-232-323-0/", Method = ConnectionMethod.POST };

        var dic = new Dictionary<string, int>
        {
            ["nancy"] = 0,
            ["derrick"] = 1,
            ["mayo"] = 4,
        };

        var dic2 = ("nancy", 0); // constructing a tuple
        (string name, int odds) = dic2; // deconstructing a tuple or 
        var (y, m, d) = DateTupled();
        WriteLine($$"""
                { d: {{d}},
                  m: {{m}},
                  y: {{y}}
                }
                """);


        // Patterns are awesome
        string[] names = { "Leo", "Nyau", "Kendrik", "Mako", "Liam" };
        if (names is [_, ..,var mako, "Liam"] && mako == "Mako")
        {
            WriteLine("Patterns are awesome");
        }
    }
}

