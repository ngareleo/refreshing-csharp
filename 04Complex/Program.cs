using static System.Console;
namespace _04Complex;

// A delegate is an object that knows how to call a function
// this transformer is compatible with any method that takes an int and returns an int
delegate T Transformer<T>(T x);

// Adding a ref keyword before a struct ensures that the struct will always live on the stack and not the heap
ref struct Operation<T>
{
    public string? Name { get; set; }
    public Transformer<T>? Op { get; set; }
}


class Program
{
   
    static T Transform<T>(T value, Operation<T> o)
    {
        if (o.Op == null) {
            throw new ArgumentException("cannot provide operation with null values");
        }
        T res = o.Op(value);
        WriteLine($"Transformation [{o.Name}] {value} to {res}");
        return res;
    }

    static void Main()
    {
        var operation = new Operation<double> { Name = "Tan", Op = Math.Tan };
        double _ = Transform(10.223, operation);
    }
}

