using static System.Console;

class Vehicle
{
    // This is initialized before the constructor
    public int Mileage = 10;

    // You can declare constants within classes which are evaluated during compile time
    public const string CompanyName = "LEO's Limited";
    public static readonly string CompanyNameAlt = "Leo's limited";

    // both statements are semantically the same only that the const is evaluated much earlier

    public string Brand;
    public int YearOfManufacture;
    public decimal Cost;
    public int ProductionNumber;
    public string ShippingNumber;

    public Vehicle(string brand, decimal cost, int yearOfManufacture)
    {
        Brand = brand;
        Cost = cost;
        YearOfManufacture = yearOfManufacture;
    }

    public Vehicle(
        string brand,
        decimal cost,
        int yearOfManufacture,
        int productionNumber,
        string shippingNumber
    ) =>
        (Brand, Cost, YearOfManufacture, ProductionNumber, ShippingNumber) = (
            brand,
            cost,
            yearOfManufacture,
            productionNumber,
            shippingNumber
        );

    // They call this a "deconstructing assignment".
    //I guess because you can deconstruct an instance by initializing Deconstruct() method

    public Vehicle(string brand, decimal cost, int yearOfManufacture, int productionNumber)
        : this(brand, cost, yearOfManufacture) => ProductionNumber = productionNumber;

    // C# allows for the use of "expression-bodies members" or arrow-functions as we know them

    // The deconstruct method allow you to destructure an instance to respective
    public void Deconstruct(out string brand, out decimal cost, out int yearOfManufacture)
    {
        brand = Brand;
        cost = Cost;
        yearOfManufacture = YearOfManufacture;
    }
}

class Program
{
    static void Main()
    {
        Vehicle a = new Vehicle("Golf", 2_121_434, 2001);
        WriteLine($"Vehicle model {a.Brand}");

        var (brand, cost, _) = a; // To allow you to do this, you can use the deconstruct
        // you can also
        (var b1, var b2, _) = a; // The first one is more idiomatic
        WriteLine($"Your car costs {cost} Ksh");
    }
}
