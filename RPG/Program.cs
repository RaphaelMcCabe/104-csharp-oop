Unit unit = new Unit("Skeleton", 100);
Unit unit2 = new Unit("Demon", 100);
Unit unit3 = new Unit("Ghost",100);
Unit unit4 = new Unit("Necromancer",200);
unit.ReportStatus();
unit2.ReportStatus();
unit3.ReportStatus();
unit4.ReportStatus();

while (unit4.Health > 0)
{
    Console.WriteLine("How much damage do you want to deal to the Necromancer");
    unit4.Damage(Convert.ToInt32(Console.ReadLine()));
    unit4.ReportStatus();
}

public class Necromancer : Unit
{
    private bool hasRessurected;
    public void Ressurect()
    {
        if (Health <= 0)
        {
            
        }
    }
    
    public Necromancer(string name, int maxHealth) : base(name, maxHealth)
    {
        
    }
    public override void Damage(int value)
    {
        base.Damage(value);
        if (Health < 0 && !hasRessurected)
        {
            Ressurect();
        }
    }
}


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
            if (value < 0)
            {
                health = 0;
            }

            if (value >= maxHealth)
            {
                health = maxHealth;
            }

            if (value >= 0 && value <= maxHealth)
            {
                health = value;
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

    public virtual void Damage(int value)
    {
        Health -= value;
    }
}