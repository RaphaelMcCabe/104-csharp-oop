// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Class person = new Class();
Class animal = new Class();
Class car = new Class();

person.name = "Person";
animal.name = "Animal";
car.name = "Car";

person.Call();
animal.Call();
car.Call();
public class Class
{
    public string name;

    public void Call()
    {
        Console.WriteLine(name);
    }
    }