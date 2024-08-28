global using static System.Console;

string[] names = { "Leo", "Nairobi", "Kenya" };
string sen = string.Join(" | ", names);
WriteLine(sen);

string a = "I rock very hard";
var words = a.Split();

foreach (string word in words)
{
    WriteLine(word);
}
