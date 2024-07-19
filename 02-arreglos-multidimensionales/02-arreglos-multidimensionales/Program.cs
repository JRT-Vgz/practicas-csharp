
using System.ComponentModel.Design;

Dictionary<int, string> Dict = new Dictionary<int, string>();

Dict.Add(1, "uno");
Dict.Add(2, "dos");
Dict.Add(3, "tres");

foreach (string item in Dict.Values)
{
    Console.WriteLine(item);
}


foreach (string item in Dict.Values)
{
    Console.WriteLine(item);
}


Console.WriteLine(Dict.Keys[2]);