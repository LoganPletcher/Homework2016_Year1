using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// The Base interface for the Base_Class
/// </summary>
public interface IBase<T>
{
    string Name
    { get; set; }
    int Health
    { get; set; }
    int Attack
    { get; set; }
    void Ability1(T enemy);
    void Ability2(T enemy);
    void Ability3(T enemy);
    int Stunned
    { get; set; }
    int DamageOverTime
    { get; set; }
    int CharacterClass
    { get; set; }
}

public interface ILevelingSystem<T>
{
    int Level
    { get; set; }
    int ExperiencePoints
    { get; set; }
    int ExperiencetoLevelUp
    { get; set; }
    void LevelingUp();
}

[Serializable()]
public class Base_Class : IBase<Base_Class>, ILevelingSystem<Base_Class>
{
    public Random rng = new Random();
    private string m_Name;
    private int m_HP;
    private int m_Att;
    private int m_S;
    private int m_DoT;
    private int m_CC;
    private int m_LVL;
    private int m_XP;
    private int m_MaxXP;

    public string Name
    {
        get
        { return m_Name; }
        set
        { m_Name = value; }
    }
    
    public int Attack
    {
        get
        { return m_Att; }
        set
        { m_Att = value; }
    }

    public int DamageOverTime
    {
        get
        { return m_DoT; }
        set
        { m_DoT = value; }
    }

    public int Health
    {
        get
        { return m_HP; }
        set
        { m_HP = value; }
    }

    public int Stunned
    {
        get
        { return m_S; }
        set
        { m_S = value; }
    }

    public int CharacterClass
    {
        get
        { return m_CC; }
        set
        { m_CC = value; }
    }

    public virtual void Ability1(Base_Class enemy)
    {    }

    public virtual void Ability2(Base_Class enemy)
    {    }

    public virtual void Ability3(Base_Class enemy)
    {    }
    
    public int Level
    {
        get
        { return m_LVL; }
        set
        { m_LVL = value; }
    }

    public int ExperiencePoints
    {
        get
        { return m_XP; }
        set
        { m_XP = value; }
    }

    public int ExperiencetoLevelUp
    {
        get
        { return m_MaxXP; }
        set
        { m_MaxXP = value; }
    }

    public virtual void LevelingUp()
    {
        ExperiencePoints -= ExperiencetoLevelUp;
        Level++;
        ExperiencetoLevelUp *= Level;
    }
}

public class Black_Mage : Base_Class
{
    public Black_Mage(string n, int l)
    {
        this.Name = n;
        this.Level = l;
        this.Health = 20 + (l * 5);
        this.Attack = 3 + (l * 1);
        this.Stunned = 0;
        this.DamageOverTime = 0;
        this.CharacterClass = 1;
    }

    public override void Ability1(Base_Class enemy)
    {
        enemy.Health -= this.Attack + 2;
        Console.WriteLine(this.Name + " dealt " + (this.Attack + 2) + " magic damage to " + enemy.Name);
        enemy.DamageOverTime = 2;
        Console.WriteLine(this.Name + " poisoned " + enemy.Name + "for 2 rounds with dark magic.");

    }

    public override void Ability2(Base_Class enemy)
    {
        for (int i = 0; i < 3; i++)
        {
            int damage = rng.Next(0, 2);
            enemy.Health -= damage;
            Console.WriteLine(enemy.Name + " took " + damage + " magic damage.");
        }
    }

    public override void Ability3(Base_Class enemy)
    {
        enemy.Health -= this.Attack + 4;
        Console.WriteLine(enemy.Name + " took " + (this.Attack + 4) + " magic damage.");
    }

    public override void LevelingUp()
    {
        base.LevelingUp();
        this.Health += 5;
        this.Attack += 1;
    }
}

public class Archer : Base_Class
{
    public Archer(string n, int l)
    {
        this.Name = n;
        this.Level = l;
        this.Health = 20 + (l * 6);
        this.Attack = 3 + (l * 2);
        this.Stunned = 0;
        this.DamageOverTime = 0;
        this.CharacterClass = 2;
    }

    public override void Ability1(Base_Class enemy)
    {
        for (int i = 0; i < 2; i++)
        {
            enemy.Health -= this.Attack + 3;
            Console.WriteLine(enemy.Name + " took " + (this.Attack + 3) + " ranged damage.");
        }
    }

    public override void Ability2(Base_Class enemy)
    {
        enemy.Health -= this.Attack;
        enemy.Stunned = 2;
    }

    public override void Ability3(Base_Class enemy)
    {
        enemy.Health -= this.Attack + 6;
    }

    public override void LevelingUp()
    {
        base.LevelingUp();
        this.Health += 6;
        this.Attack += 2;
    }
}

public class Blue_Mage : Base_Class
{
    public Blue_Mage(string n, int l)
    {
        this.Name = n;
        this.Level = l;
        this.Health = 20 + (l * 5);
        this.Attack = 3 + (l * 1);
        this.Stunned = 0;
        this.DamageOverTime = 0;
        this.CharacterClass = 3;
    }

    public override void Ability1(Base_Class enemy)
    {
        enemy.DamageOverTime = 2;
        enemy.Stunned = 2;
    }

    public override void Ability2(Base_Class enemy)
    {
        enemy.Health -= (this.Attack + 2);
        enemy.Stunned = 4;
    }

    public override void Ability3(Base_Class enemy)
    {
        enemy.Health -= this.Attack;
        enemy.DamageOverTime = 4;
    }

    public override void LevelingUp()
    {
        base.LevelingUp();
        this.Health += 5;
        this.Attack += 1;
    }
}

public class Fighter : Base_Class
{
    public Fighter(string n, int l)
    {
        this.Name = n;
        this.Level = l;
        this.Health = 25 + (l * 7);
        this.Attack = 6 + (l * 2);
        this.Stunned = 0;
        this.DamageOverTime = 0;
        this.CharacterClass = 4;
    }

    public override void Ability1(Base_Class enemy)
    {
        enemy.Health -= (this.Attack + 6);
    }

    public override void Ability2(Base_Class enemy)
    {
        enemy.Health -= (this.Attack + 2);
        enemy.DamageOverTime = 2;
    }

    public override void Ability3(Base_Class enemy)
    {
        enemy.Health -= (this.Attack + this.Attack);
    }

    public override void LevelingUp()
    {
        base.LevelingUp();
        this.Health += 7;
        this.Attack += 2;
    }
}

public class Paladin : Base_Class
{
    public Paladin(string n, int l)
    {
        this.Name = n;
        this.Health = 25 + (l * 7);
        this.Attack = 6 + (l * 2);
        this.Stunned = 0;
        this.DamageOverTime = 0;
        this.CharacterClass = 5;
    }

    public override void Ability1(Base_Class enemy)
    {
        enemy.Health -= (this.Attack + 10);
        enemy.Stunned = 0;
    }

    public override void Ability2(Base_Class enemy)
    {
        enemy.Health -= (this.Attack + 10);
        enemy.DamageOverTime = 0;
    }

    public override void Ability3(Base_Class enemy)
    {
        enemy.Health -= (this.Attack + 6);
    }

    public override void LevelingUp()
    {
        base.LevelingUp();
        this.Health += 7;
        this.Attack += 2;
    }
}

public class White_Mage : Base_Class
{
    public White_Mage(string n, int l)
    {
        this.Name = n;
        this.Health = 25 + (l * 5);
        this.Attack = 2 + (l * 1);
        this.Stunned = 0;
        this.DamageOverTime = 0;
        this.CharacterClass = 6;
    }

    public override void Ability1(Base_Class enemy)
    {
        enemy.Health += this.Attack + 10;
    }

    public override void Ability2(Base_Class enemy)
    {
        enemy.Stunned = 0;
    }

    public override void Ability3(Base_Class enemy)
    {
        enemy.DamageOverTime = 0;
    }

    public override void LevelingUp()
    {
        base.LevelingUp();
        this.Health += 5;
        this.Attack += 1;
    }
}

namespace CLass_Practice
{
    class FFVII
    {
        //List<Base_Class> Team_A = new List<Base_Class>();
        //
        //List<Base_Class> Team_B = new List<Base_Class>();

    }
}
