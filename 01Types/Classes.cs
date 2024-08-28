using static System.Console;

class Vehicle
{
    // This is initialized before the constructor
    public int Mileage = 10;

    // You can declare constants within classes which are evaluated during compile time
    public const string CompanyName = "LEO's Limited";
    public static readonly string CompanyNameAlt = "Leo's limited";

    // both statements are semantically the same only that the const is evaluated much earlier

    public string Owner { get; set; } // Owner is an automatic property
    public string Brand;
    public int YearOfManufacture;
    public decimal Cost;
    public int ProductionNumber;
    public string ShippingNumber;

    public int MarketAge // this is a property like a field but has some logic
    {
        get { return DateTime.Now.Year - YearOfManufacture; }
    }

    public Vehicle(string owner, string brand, decimal cost, int yearOfManufacture)
    {
        Owner = owner;
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

    public Vehicle(
        string owner,
        string brand,
        decimal cost,
        int yearOfManufacture,
        int productionNumber
    )
        : this(owner, brand, cost, yearOfManufacture) => ProductionNumber = productionNumber;

    // C# allows for the use of "expression-bodies members" or arrow-functions as we know them

    // The deconstruct method allow you to destructure an instance to respective
    public void Deconstruct(
        out string brand,
        out decimal cost,
        out int yearOfManufacture,
        out int marketAge
    ) => (brand, cost, yearOfManufacture, marketAge) = (Brand, Cost, YearOfManufacture, MarketAge);

    public int[] Trips { get; }

    public void AddTrip(int distance)
    {
        Trips.Append(distance);
    }

    public int this[int index]
    {
        get { return Trips[index]; }
    }
}

class Classes
{
    public static void Run()
    {
        Vehicle a = new Vehicle("Leo", "Golf", 1_121_434, 2001);
        WriteLine($"Vehicle model {a.Brand}");

        var (brand, cost, _, marketAge) = a; // To allow you to do this, you can use the deconstruct
        // you can also
        (var b1, var b2, _, _) = a; // The first one is more idiomatic
        WriteLine($"Your car costs {cost} Ksh");
        WriteLine($"How old is this car? {marketAge}");

        a.AddTrip(1_200);
        a.AddTrip(699);
        a.AddTrip(21);
        a.AddTrip(222);
        WriteLine("Total number of trips ", a.Trips);
        WriteLine("Second trip ", a[1]); // this invokes the this[int index] method of the instance
    }
}
