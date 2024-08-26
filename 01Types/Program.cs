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

    public Vehicle(string brand, decimal cost, int yearOfManufacture)
    {
        Brand = brand;
        Cost = cost;
        YearOfManufacture = yearOfManufacture;
    }
}

class Program
{
    static void Main()
    {
        Vehicle a = new Vehicle("Golf", 1202, 2001);
        WriteLine($"Vehicle model {a.Brand}");
    }
}
