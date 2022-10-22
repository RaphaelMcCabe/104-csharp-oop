// Unit unit = new Unit("Skeleton", 100);
// Unit unit2 = new Unit("Demon", 100);
// Unit unit3 = new Unit("Ghost",100);
// Necromancer necromancer = new Necromancer("Necromancer",200);
// unit.ReportStatus();
// unit2.ReportStatus();
// unit3.ReportStatus();
// necromancer.ReportStatus();

Unit unit = SpawnNewUnit();
while (unit.isAlive = true)
{
    Console.WriteLine("A creature spawns!");
}

static Unit SpawnNewUnit()
{
    int number = Random.Shared.Next(minValue: 0, maxValue: 1);
       
    if(number == 0){
        return new Necromancer("Necromancer", 200);
    }
    if(number == 1)
    {
        return new Unit("Monster", 100);
    }

    return SpawnNewUnit();
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

        if (IsDead == false)
        {
            Console.WriteLine("The necromancer died for real!");
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
        Console.WriteLine("How much damage will you deal?");
        value = Convert.ToInt32(Console.ReadLine());
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