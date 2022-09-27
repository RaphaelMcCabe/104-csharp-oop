// See https://aka.ms/new-console-template for more information
using System.Threading.Channels;
Console.WriteLine("Hello, World!");

Person[] person = new Person[3];
Animal animal = new Animal();
Car car = new Car();
int i;

Console.WriteLine(person);
Console.WriteLine(animal);
Console.WriteLine(car);

for ( i = 0; i < person.Length; i++)
    
{
    person[i] = new Person();
    Console.WriteLine("Tell me a persons name");
    person[i].names = Console.ReadLine();
}

for ( i = 0; i < person.Length; i++)
{
    person[i].IntroduceYourself();
}
public class Person
{
    public void IntroduceYourself()
    {
        Console.WriteLine($"Hello my name is {names}");
    }
    public string names;
}
public class Animal{}
public class Car{}

