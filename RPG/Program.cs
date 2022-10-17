Unit unit = new Unit("Skeleton", 100);
Unit unit2 = new Unit("Demon", 100);
Unit unit3 = new Unit("Ghost",100);
Unit unit4 = new Unit("Leet", 1337);
unit.ReportStatus();
unit2.ReportStatus();
unit3.ReportStatus();
unit4.ReportStatus();


    public class Unit
{
    private int maxHealth;
    private int health;
    public int id;
    public static int nextID;
    string name;

    public Unit(string name, int maxHealth)
    {
        this.name = name;
        id = nextID;
        nextID++;
        this.maxHealth = maxHealth;
        health = maxHealth;
    }

    public int Health
    {
        private set
        {
            if (health < 0)
            {
                health = 0;
            }

            if (health > maxHealth)
            {
                health = maxHealth;
            }
        }
        get
        {
            return health;
        }
    }
    
    public void ReportStatus()
    {
        Console.WriteLine($"{id}# {name} {Health}/{maxHealth}");
    }
    
}



