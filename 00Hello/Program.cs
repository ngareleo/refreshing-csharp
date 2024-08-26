using static System.Console; // using static imports types and hence you can import static methods Like here we've imported all the static methods of System.Console

struct Point
{
    public int X,
        Y;
}

class OopPoint
{
    public int X,
        Y;
}

class Program
{
    static void Main()
    {
        int @using = 200; // You can use @ to override a reserved keyword
        WriteLine("We overwrote using to @using " + @using);

        int a = 12343;
        long b = a; // implicit conversion of a to a long
        // Implicit conversions are allowed when
        // 1. The compiler can guarantee that the conversion will complete
        // 2. No information is lost during the conversion


        short c = (short)b; // explicit conversion of c to a short

        // Value types vs Reference types
        // Value types are in-built supported by the compiler like numeric, char, and bool
        // Reference comprise of classes, delegates, interfaces and arrays

        // The content of value types are always values
        // You can create custom value-types using Structs

        var d = new Point();
        d.X = 20;
        var e = d;
        e.X = 30;
        WriteLine("Value of D.X is still " + d.X);
        // The value of d is unchanged
        // This is when you assign a value type, we make a copy

        // A class is an example of a reference type
        var f = new OopPoint();
        f.X = 40;
        var g = f;
        f.X = 60;
        WriteLine("Value of F.X is now " + f.X);
        // The value of f has been changed by symbol g
        // Assigning a reference-type copies the reference to the object not the value of the object
        // So G is a copy of a reference to F but both point to the same object

        // Reference types can be assigned a value of null but value types cannot be null
        // d = null; // will lead to a compile time error

        // In terms of memory,
        // Value types occupy the exact amount of memory needed
        // The instance of struct Point would then occupy 8 bytes of memory
        // As for reference types, they require separate memory addresses. For the reference and for the object

        // The object takes up as many bytes as the fields need, plus administrative field with little overhead
        // The overhead is taken up by type information, lock information (for multithreading) and info for the GC
        // Each reference requires some more 4 or 8 bytes depending on whether the .NET runtime is running on 32 or 64 bit

        // You can insert a underscores to add more readability
        int h = 2_323_923;
        var j = 0b_1001_0110_1011_000; // It fares better for binary numbers by adding 0b
        WriteLine("Value of j is " + j);

        // The compiler infers value as float or double if it comes across a decimal point or a E
        // Otherwise, the literal's type will be the first type that the value can fit the literal

        // integral types can be converted to floating types implicitly
        double k = h;
        k += 0.232432;
        WriteLine("After conversion to float " + k);
        // The vice-versa must be explicit
        int l = (int)k;
        WriteLine("After converting K back to float " + l);

        // Division of an integral type always omits the remainder
        WriteLine(l / 283);

        // In terms of overflow, values can overflow during runtime
        byte m = 32;
        m *= 202;
        WriteLine(m); // The value of m is now 64
        // You can wrap to raise a runtime exception using checked()

        // You can use this syntax to catch overflows
        // checked
        // {
        //     m *= 101;
        //     Console.WriteLine(m); // The value of m is now 64
        // }


        // Strings and Characters
        char n = 'n'; // This takes up 2-bytes
        char o = '\u006f'; // You specify any unicode character by prefixing \u
        WriteLine("O is now a unicode character " + o);

        // For strings, in C#, backlashes are computed in place
        // To override this behavior you can use a verbatim string literal
        string p = @"Hello /nTraveler/n";
        WriteLine(p);

        // C# also supports raw strings using """ (triple quotes)
        string q = """
            {
                "name": "Leo",
                "language": "python"
            }
            """; // The indentation is controlled by the indentation of the closing tag
        WriteLine(q);

        // C# also supports string interpolation by prefixing the string with the $ symbol
        string r = "Kunta Kinte";
        WriteLine($"My name is {r}");
        // Any type can be interpolated. C# will convert the string by calling ToString() on the type

        /// raw strings are also interpolated
        string html = $"""
            <div>
                <p>{p}</p>
            </div>
            """;

        // You can even do this
        // The double $$ changes the sequence from {} to {{}}
        // Should come in handy later
        string PlaceInPlace = $$"""The value of { html : {{html}} } """;
        WriteLine(PlaceInPlace);

        char[] s = new char[5];
        char[] t = { 'a', 'b', 'c', 'd', 'e', 'f', 'g' };
        // arrays once created cannot change size

        // from C# 12 you can also use []
        // char[] t1 = ['1', '2', '3'];
        // You can pass this directly to a function
        // before:
        // toString(new char[] {'l', 'e', '0'})
        // after:
        // toString(['a', 'b', 'c', 'd'])

        // you can index the array from the front and from the back
        WriteLine($"From the front of T {t[0]}");
        WriteLine($"From the back of T {t[^1]}");

        // You can also create slices in C#
        char[] u = t[..2]; // First two
        Pretty(u);
        char[] u1 = t[2..]; // From index { 2 } going forward
        Pretty(u1);
        // You can even get the last n
        char[] u2 = t[^3..]; // The last two
        Pretty(u2);

        // initializing an array, creates an array of n default elements
        int[] u3 = new int[10];
        Pretty(u3); // should print 10 zeros, since 0 is the default value for integrals
        Point[] u4 = new Point[10];
        Pretty(u4); // as for structs, their default value is the default value for each field
        WriteLine($$"""First point { x: {{u4[0].X}}, y: {{u4[0].Y}} }""");

        // as for reference types, the default value is null
        OopPoint[] u5 = new OopPoint[3];
        Pretty(u5);

        // You can initialize multi-dim arrays like this
        int[,] u6 =
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
        };
    }

    private static void Pretty<T>(T[] elements)
    {
        Write("{ ");
        foreach (T t in elements)
        {
            Write($"{t}, ");
        }
        WriteLine("}");
    }
}
