// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string[] names = new string[3];

for (int i = 0; i < names.Length; i++)
{
    Console.WriteLine("Give me a name");
    names[i] = Console.ReadLine();
}
Console.WriteLine($"{names[0]},{names[1]},{names[2]}");
