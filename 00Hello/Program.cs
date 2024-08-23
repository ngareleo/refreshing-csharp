using System;

// We've created a value type 
public struct Point
{
    public int X,
        Y;
}

class Program
{
    static void Main()
    {
        int @using = 200; // You can use @ to override a reserved keyword
        Console.WriteLine("We overwrote using to @using ", @using);

        int a = 12343;
        long b = a; // implicit conversion of a to a long
        // Implicit conversions are allowed when
        // 1. The compiler can guarantee that the conversion will complete
        // 2. No information is lost during the conversion


        short c = (short)b; // explicit conversion of c to a short

        // Value types vs Reference types
        // Value types are in-built supported by the compiler
        // Reference comprise of classes, delegates, interfaces and arrays

        // The content of value types are always values
        // You can create custom value-types using Structs
    }
}
