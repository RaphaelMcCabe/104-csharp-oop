<<<<<<< Updated upstream
﻿while (true)
{
    Unit unit = SpawnNewUnit();
    while (unit.isAlive)
    {
        unit.ReportStatus();
        Console.WriteLine("How much damage do you want to deal?");
        unit.TakeDamage(Convert.ToInt32(Console.ReadLine()));
    }
    if (!unit.isAlive)
    {
        Console.WriteLine("The creature has died");
    }
}
static Unit SpawnNewUnit()
{
    Console.WriteLine("A creature spawns!");
    int number = Random.Shared.Next(minValue: 0, maxValue: 4);
       
    if(number == 0){
        return new Necromancer("Necromancer", 200);
    }
    if(number == 1)
    {
        return new Skeleton("Skeleton", 250);
    }

    if(number == 2)
    {
        return new Hedgehog("Hedgehog", 200);
    }

    if (number == 3)
    {
        return new Bomb("Bomb", 500);
    }

    return SpawnNewUnit();
}

public class Hero : Unit
{
    public Hero(string name, int maxHealth) : base(name, maxHealth)
    {
    }
}


public class Bomb : Unit
{
    private int timer = 5;
    public Bomb(string name, int maxHealth) : base(name, maxHealth)
    {}

    public override void TakeDamage(int value)
    {
        base.TakeDamage(value);
        {
            if (timer <= 5)
            {
                Console.WriteLine($"The bomb will explode in {timer} turns");
                timer--;
            }

            if (timer <= 0)
            {
                health = 0;
                Console.WriteLine("The Bomb explodes!!!!!");
            }
        }
    }
}

public class Hedgehog : Unit
{
    public int defenseMode;
    
    public Hedgehog(string name, int maxHealth) : base(name, maxHealth)
    {}
    public override void TakeDamage(int value)
    {
        if(defenseMode <= 0)
        {
            base.TakeDamage(value);
            defenseMode = 2;
            Console.WriteLine("The hedgehog goes into defense mode!!!");
        }
=======
﻿Unit unit = new Unit("Skeleton", 100);
Unit unit2 = new Unit("Demon", 100);
Unit unit3 = new Unit("Ghost",100);
Unit unit4 = new Unit("Leet", 1337);

unit.ReportStatus();
unit2.ReportStatus();
unit3.ReportStatus();
unit4.ReportStatus();
>>>>>>> Stashed changes

        else if (defenseMode > 0)
        {
            defenseMode--;
            Console.WriteLine("The hedgehog is in defense mode :l!");
            if (defenseMode == 0)
            {
                Console.WriteLine("The hedgehog has left defense mode :(");
            }
        }

    }
    
}

public class Skeleton : Unit
{
    public Skeleton(string name, int maxHealth) : base(name, maxHealth)
    {}
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
public abstract class Unit
{
    protected int maxHealth;
    protected int health;
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

    public virtual void TakeDamage(int value)
    {
        Health -= value;
    }

    public bool isAlive
    {
        get
        {
            if (Health == 0)
            {
                return false;
            }
            return true;
        }
    }
}



