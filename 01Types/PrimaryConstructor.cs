record Movie(string Title, int Length);

class School(string name)
// by passing values here, we have created an automatic constructor that takes name
{
    public string Name { get; set; } = name;
    public string Location { get; set; }
    public int NoOfStudents { get; init; }

    // now every-constructor must invoke the automatic constructor, making sure name is always set
    public School(string name, string location)
        : this(name)
    {
        Location = location;
    }

    public override string ToString()
    {
        return $"{Name} from {Location}";
    }
}

class PrimaryConstructor()
{
    public static void Run()
    {
        var s = new School("moi FA", "Huruma");
        WriteLine(s);
        var s1 = new School("Moi Girls") { Location = "Nairobi", NoOfStudents = 32 };
        var m = new Movie { Title = "Pulp fiction", Length = 20 };
    }
}
