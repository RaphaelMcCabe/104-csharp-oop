// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


Unit unit = new Unit("Skeleton");
Unit unit2 = new Unit("Demon");
Unit unit3 = new Unit("Ghost");
unit.ReportStatus();
unit2.ReportStatus();
unit3.ReportStatus();

public class Unit
{
    public int id;
    public static int nextID;
    string name;
    public Unit(string name)
    {
        this.name = name;
        id = nextID;
        nextID++;
    }
    
    public void ReportStatus()
    {
        Console.WriteLine($"{id}# {name}");
        
        return;
    }
    
    
    
    
}


