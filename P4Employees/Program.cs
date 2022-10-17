// See https://aka.ms/new-console-template for more information

using System.Diagnostics.Metrics;
using System.Threading.Channels;

Console.WriteLine("Hello, World!");

Employee[] employees = new Employee[100];
int count = 0;

while (true)
{
    Console.WriteLine("Do you want to:");
    Console.WriteLine("1: List all employees");
    Console.WriteLine("2: Add another employee");
    Console.WriteLine("3: Change tax rate");
    string input = Console.ReadLine();
    if (input == "1")
    {
        for (int i = 0; i < count; i++)
        {
            Employee tag = employees[i];
            Console.WriteLine($"Employee: {tag.name} Salary: {tag.salary} Tax ({Employee.tax}%: Salary After Taxes: ");
        }
    }
    if (input == "2")
    {
        {
            Employee tag = new Employee();
            Console.WriteLine("What's the name?");
            tag.name = Console.ReadLine();
            Console.WriteLine("What's their salary?");
            tag.salary = Convert.ToInt32(Console.ReadLine());
            employees[count] = tag;
            count++;
        }
    }
    
}
public class Employee
{
    public string name;
    public int salary;
    public static float tax = 30;
    
}

public void Print()
{
    int salaryAfterTax = (int)(salary * (1 - tax));
}
oogg