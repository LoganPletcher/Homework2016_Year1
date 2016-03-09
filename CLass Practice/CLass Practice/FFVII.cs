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

public class Base_Class : IBase<Base_Class>
{
    public Random rng = new Random();
    private int m_HP;
    private int m_Att;
    private int m_S;
    private int m_DoT;
    private int m_CC;

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
}

public class Black_Mage<T> : Base_Class
{
    private Black_Mage(int h, int a)
    {
        this.Health = h;
        this.Attack = a;
        this.Stunned = 0;
        this.DamageOverTime = 0;
    }

    public override void Ability1(Base_Class enemy)
    {
        enemy.Health -= this.Attack + 2;
        enemy.DamageOverTime = 2;
    }

    public override void Ability2(Base_Class enemy)
    {
        for (int i = 0; i < 3; i++)
            enemy.Health -= rng.Next(0,2);
    }

    public override void Ability3(Base_Class enemy)
    {
        enemy.Health -= this.Attack + 4;
    }
}

public class Archer<T> : Base_Class
{
    private Archer(int h, int a)
    {
        this.Health = h;
        this.Attack = a;
        this.Stunned = 0;
        this.DamageOverTime = 0;
    }

    public override void Ability1(Base_Class enemy)
    {
        for (int i = 0; i < 2; i++)
           enemy.Health -= this.Attack + 3;
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
}

public class Blue_Mage<T> : Base_Class
{
    private Blue_Mage(int h, int a)
    {
        this.Health = h;
        this.Attack = a;
        this.Stunned = 0;
        this.DamageOverTime = 0;
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
