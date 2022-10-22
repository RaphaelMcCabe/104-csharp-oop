Unit unit = new Unit("Skeleton", 100);
Unit unit2 = new Unit("Demon", 100);
Unit unit3 = new Unit("Ghost",100);
Necromancer necromancer = new Necromancer("Necromancer",200);
unit.ReportStatus();
unit2.ReportStatus();
unit3.ReportStatus();
necromancer.ReportStatus();

while (necromancer.Health > 0 )
{
    Console.WriteLine("Deal damage to the Necromancer");
    necromancer.TakeDamage(Convert.ToInt32(Console.ReadLine()));
    necromancer.ReportStatus();
    if (necromancer.IsDead == false)
    {
        Console.WriteLine("The Necromancer died for real!");
    }
   
}

public class Necromancer : Unit
{
    private bool hasRessurected;
    public void Ressurect()
    {
        Console.WriteLine("The Necromancer ressurects itself!");
        hasRessurected = true;
        health = maxHealth / 2;
    }
    public Necromancer(string name, int maxHealth) : base(name, maxHealth)
    {
        
    }
    public override void TakeDamage(int value)
    {
        base.TakeDamage(value);
        if (Health == 0 && !hasRessurected)
        {
            Ressurect();
        }
    }
}
public class Unit
{
    protected int maxHealth;
    protected int health;
    public int id;
    public static int nextID;
    string name;
    public bool isAlive = true;
    
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

    public virtual void TakeDamage(int value)
    {
        Health -= value;
    }

    public bool IsDead
    {
        get
        {
            if (Health == 0)
            {
                isAlive = false;
                return false;
            }
            return true;
        }
    }
}