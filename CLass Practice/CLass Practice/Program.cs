using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace CLass_Practice
{
    class Program
    {

        enum PlayerStates
        {
            init,
            Prebattle,
            teamAturn,
            teamBturn,
            victory,
        }

        static bool init(Finite_State_Machine FSM)
        {
            Save_and_Load<Party> sl = new Save_and_Load<Party>();
            FSM.ChangeStates("init->Prebattle");
            FSM.info();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Convert.ToString(FSM.CurrentState) == Convert.ToString(PlayerStates.Prebattle))
            { Prebattle(FSM, sl); }
            return false;
        }

        static bool Prebattle(Finite_State_Machine FSM, Save_and_Load<Party> sl)
        {
            bool TeamABuilt = false;
            Party partyA = new Party();
            Party partyB = new Party();
            // Party teamA = new Party();
            //Party teamB = new Party();
            Application.Run(new LoadingScene(partyA));

            int sum = 0;
            foreach (Unit u in partyA.Members)            
                sum += u.Level;
            


            TeamABuilt = (partyA.Members.Count >= 3) ? true : false;
            if (!TeamABuilt)            
                partyA = new Party(PartyType.CHARACTER, 1);


            int avgLvl = sum / partyA.Members.Count;
            partyB = new Party(PartyType.ENEMY, avgLvl);

            //if (partyA.Members.Count >= 3) { TeamABuilt = true; }
            //else { TeamABuilt = false; }
            /*
            //int AverageLevel;
            //Random rng = new Random();
            
            //if (TeamABuilt == false)
            //{
            //    for (int i = 0; i < 3; i++)
            //    {
            //        int Cclass = rng.Next(1, 7);
            //        if (Cclass == 1) { Black_Mage Character = new Black_Mage("Character" + i, 1); teamA.Add(Character); }
            //        else if (Cclass == 2) { Archer Character = new Archer("Character" + i, 1); teamA.Add(Character); }
            //        else if (Cclass == 3) { Blue_Mage Character = new Blue_Mage("Character" + i, 1); teamA.Add(Character); }
            //        else if (Cclass == 4) { Fighter Character = new Fighter("Character" + i, 1); teamA.Add(Character); }
            //        else if (Cclass == 5) { Paladin Character = new Paladin("Character" + i, 1); teamA.Add(Character); }
            //        else if (Cclass == 6) { White_Mage Character = new White_Mage("Character" + i, 1); teamA.Add(Character); }
            //    }
            //}
            //AverageLevel = (teamA[0].Level + teamA[1].Level + teamA[2].Level) / 3;
            //Party teamB = new Party();
            //for (int i = 0; i < 3; i++)
            //{
            //    int Cclass = rng.Next(1, 7);
            //    if (Cclass == 1) { Black_Mage Enemy = new Black_Mage("Enemy" + i, AverageLevel); teamB.Add(Enemy); }
            //    else if (Cclass == 2) { Archer Enemy = new Archer("Enemy" + i, AverageLevel); teamB.Add(Enemy); }
            //    else if (Cclass == 3) { Blue_Mage Enemy = new Blue_Mage("Enemy" + i, AverageLevel); teamB.Add(Enemy); }
            //    else if (Cclass == 4) { Fighter Enemy = new Fighter("Enemy" + i, AverageLevel); teamB.Add(Enemy); }
            //    else if (Cclass == 5) { Paladin Enemy = new Paladin("Enemy" + i, AverageLevel); teamB.Add(Enemy); }
            //    else if (Cclass == 6) { White_Mage Enemy = new White_Mage("Enemy" + i, AverageLevel); teamB.Add(Enemy); }
            //}
            //Application.Run(new BattleScene(teamA, teamB));
            */
            FSM.ChangeStates("Prebattle->teamAturn");
            FSM.info();
            if (Convert.ToString(FSM.CurrentState) == Convert.ToString(PlayerStates.teamAturn))
            {
                teamAturn(FSM, sl, partyA, partyB);
            }
            Environment.Exit(0);
            return false;
        }

        static bool teamAturn(Finite_State_Machine FSM, Save_and_Load<Party> sl, Party teamA, Party teamB)
        {
            bool FirstUse = false;
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                    FirstUse = true;
                else
                    FirstUse = false;
                BattleScene BS = new BattleScene(teamA, teamB, i, FirstUse);
                Application.Run(BS);
            }
            return false;
        }

        [STAThread]
        static void Main(string[] args)
        {
            Finite_State_Machine FSM = new Finite_State_Machine(PlayerStates.init);
            //Combat battle = new Combat();
            FSM.AddState(PlayerStates.init);
            FSM.AddState(PlayerStates.Prebattle);
            FSM.AddState(PlayerStates.teamAturn);
            FSM.AddState(PlayerStates.teamBturn);
            FSM.AddState(PlayerStates.victory);

            FSM.AddTransition(PlayerStates.init, PlayerStates.Prebattle);
            FSM.AddTransition(PlayerStates.Prebattle, PlayerStates.teamAturn);
            FSM.AddTransition(PlayerStates.teamAturn, PlayerStates.teamBturn);
            FSM.AddTransition(PlayerStates.teamBturn, PlayerStates.teamAturn);
            FSM.AddTransition(PlayerStates.teamAturn, PlayerStates.victory);
            FSM.AddTransition(PlayerStates.teamBturn, PlayerStates.victory);
            FSM.info();

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new BattleScene());

            init(FSM);

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
