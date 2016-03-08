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
    bool Stunned
    { get; set; }
    bool DamageOverTime
    { get; set; }
}

public class Base_Class : IBase<Base_Class>
{
    public Random rnd = new Random();
    private int m_HP;
    private int m_Att;
    private bool m_S = false;
    private bool m_DoT = false;

    public int Attack
    {
        get
        { return m_Att; }
        set
        { m_Att = value; }
    }

    public bool DamageOverTime
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

    public bool Stunned
    {
        get
        { return m_S; }
        set
        { m_S = value; }
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
    private int m_HP;
    private int m_Att;
    private bool m_S = false;
    private bool m_DoT = false;

    private Black_Mage(int h, int a)
    {
        this.Health = h;
        this.Attack = a;
    }

    public override void Ability1(Base_Class enemy)
    {
        enemy.Health -= this.Attack + 2;
        enemy.DamageOverTime = true;
    }

    public override void Ability2(Base_Class enemy)
    {
        for (int i = 0; i < 3; i++)
            enemy.Health -= rnd.Next(0,2);
    }

    public override void Ability3(Base_Class enemy)
    {
        enemy.Health -= this.Attack + 4;
    }
}

public class Archer<T> : Base_Class
{
    private int m_HP;
    private int m_Att;
    private bool m_S = false;
    private bool m_DoT = false;

    private Archer(int h, int a)
    {
        this.Health = h;
        this.Attack = a;
    }

    public override void Ability1(Base_Class enemy)
    {
        for (int i = 0; i < 2; i++)
           enemy.Health -= this.Attack + 3;
    }

    public override void Ability2(Base_Class enemy)
    {
        enemy.Health -= this.Attack;
        enemy.Stunned = true;
    }

    public override void Ability3(Base_Class enemy)
    {
        enemy.Health -= this.Attack + 4;
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
