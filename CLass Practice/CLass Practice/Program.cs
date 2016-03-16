using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IAttack<T>
{
    void attack(T enemy);
}

public interface IStats
{
    float Health
    { get;set; }
    float Attack
    { get;set; }
    string ObjectName
    { get;set; }
}

namespace CLass_Practice
{
    class Warrior : IAttack<Warrior>, IStats
    {
        private float m_HP;
        private float m_Att;
        private string m_Name;

        public float Health
        {
            get
            { return m_HP; }
            set
            { m_HP = value; }
        }

        public float Attack
        {
            get
            { return m_Att; }
            set
            { m_Att = value; }
        }

        public string ObjectName
        {
            get
            { return m_Name; }
            set
            { m_Name = value; }
        }

        public virtual void SayName()
        {
        }

        public void attack(Warrior enemy)
        {
            enemy.m_HP -= this.m_Att;
        }

    }

    class Ninja : Warrior
    {
        public Ninja(float h, float a, string n)
        {
            this.Health = h;
            this.Attack = a;
            this.ObjectName = n;
        }

        public override void SayName()
        {
            Console.WriteLine("I am " + base.ObjectName);
            Console.WriteLine(this.Health);
            //Console.ReadLine();
            //w.HP -= base.Att;
        }

    }

    class Duck : Warrior
    {
        public Duck(float h, float a, string n)
        {
            this.Health = h;
            this.Attack = a;
            this.ObjectName = n;
        }

        public override void SayName()
        {
            Console.WriteLine("Quack (I am " + base.ObjectName + ")");
            Console.WriteLine(this.Health);
            //Console.ReadLine();
            //w.HP -= base.Att;
        }

    }

    class Program
    {

        enum PlayerStates
        {
            init,
            teamAturn,
            teamBturn,
            victory,
        }

        static void Main(string[] args)
        {
            Finite_State_Machine FSM = new Finite_State_Machine(PlayerStates.init);
            Combat battle = new Combat();
            FSM.AddState(PlayerStates.init);
            FSM.AddState(PlayerStates.teamAturn);
            FSM.AddState(PlayerStates.teamBturn);
            FSM.AddState(PlayerStates.victory);
            
            FSM.AddTransition(PlayerStates.init, PlayerStates.teamAturn);
            FSM.AddTransition(PlayerStates.teamAturn, PlayerStates.teamBturn);
            FSM.AddTransition(PlayerStates.teamBturn, PlayerStates.teamAturn);
            FSM.AddTransition(PlayerStates.teamAturn, PlayerStates.victory);
            FSM.AddTransition(PlayerStates.teamBturn, PlayerStates.victory);

            FSM.info();

            FSM.ChangeStates("init->teamAturn");
            FSM.ChangeStates("teamAturn->teamBturn");
            FSM.ChangeStates("teamAturn->victory");

            

            FSM.info();

            Console.ReadLine();
            //List<Warrior> fighters = new List<Warrior>();

            //for(int i = 1; i <= 4; i++)
            //{
            //    Ninja Guy = new Ninja(10, 5, "Student " + i);
            //    Duck Matthew = new Duck(4, 1, "Mr Matt Clone " + i);
            //    fighters.Add(Guy);
            //    fighters.Add(Matthew);
            //}
            //fighters[0].Health = 4;

            //for(int i = 0; i < fighters.Count; i++)
            //{
            //    if (i < fighters.Count - 1)
            //        fighters[i].attack(fighters[i + 1]);
            //    else
            //        fighters[i].attack(fighters[0]);
            //}
            //foreach ( Warrior w in fighters)
            //{
            //    w.SayName();
            //}
            //Console.ReadLine();
        }
    }

}
