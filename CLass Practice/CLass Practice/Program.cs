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
            Application.Run(new LoadingScene(partyA));

            TeamABuilt = (partyA.Members.Count >= 3) ? true : false;
            if (!TeamABuilt)            
                partyA = new Party(PartyType.CHARACTER, 1);

            int sum = 0;
            foreach (Unit u in partyA.Members)            
                sum += u.Level;

            int avgLvl = sum / partyA.Members.Count;
            partyB = new Party(PartyType.ENEMY, avgLvl);

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
                if (teamA.Members[i].Health > 0)
                {
                    if (teamA.Members[i].Stunned <= 0)
                    {
                        BattleScene BS = new BattleScene(teamA, teamB, i, FirstUse);
                        Application.Run(BS);
                    }
                    else
                        teamA.Members[i].Stunned--;
                    if(teamA.Members[i].DamageOverTime > 0)
                    {
                        teamA.Members[i].Health -= teamA.Members[i].Level;
                        teamA.Members[i].DamageOverTime--;
                    }
                    if (teamB.Members[0].Health <= 0 && teamB.Members[1].Health <= 0 && teamB.Members[2].Health <= 0)
                        FSM.ChangeStates("teamAturn->victory");
                    if (Convert.ToString(FSM.CurrentState) == Convert.ToString(PlayerStates.victory))
                    {
                        victory(FSM, sl, teamA, teamB, true);
                    }
                    if (teamA.Members[0].Health <= 0 && teamA.Members[1].Health <= 0 && teamA.Members[2].Health <= 0)
                        FSM.ChangeStates("teamBturn->victory");
                    if (Convert.ToString(FSM.CurrentState) == Convert.ToString(PlayerStates.victory))
                    {
                        victory(FSM, sl, teamA, teamB, false);
                    }
                }
            }
            FSM.ChangeStates("teamAturn->teamBturn");
            FSM.info();
            if (Convert.ToString(FSM.CurrentState) == Convert.ToString(PlayerStates.teamBturn))
            {
                teamBturn(FSM, sl, teamA, teamB);
            }
            return false;
        }

        static bool teamBturn(Finite_State_Machine FSM, Save_and_Load<Party> sl, Party teamA, Party teamB)
        {
            for (int i = 0; i < 3; i++)
            {
                if (teamB.Members[i].Health > 0)
                {
                    if (teamB.Members[i].Stunned <= 0)
                    {
                        TeamBbattlescene TBbs = new TeamBbattlescene(teamA, teamB, i);
                        Application.Run(TBbs);
                    }
                    else
                        teamB.Members[i].Stunned--;
                    if (teamB.Members[i].DamageOverTime > 0)
                    {
                        teamB.Members[i].Health -= teamB.Members[i].Level;
                        teamB.Members[i].DamageOverTime--;
                    }
                    if (teamA.Members[0].Health <= 0 && teamA.Members[1].Health <= 0 && teamA.Members[2].Health <= 0)
                        FSM.ChangeStates("teamBturn->victory");
                    if (Convert.ToString(FSM.CurrentState) == Convert.ToString(PlayerStates.victory))
                    {
                        victory(FSM, sl, teamA, teamB, false);
                    }
                }
            }
            FSM.ChangeStates("teamBturn->teamAturn");
            FSM.info();
            if (Convert.ToString(FSM.CurrentState) == Convert.ToString(PlayerStates.teamAturn))
            {
                teamAturn(FSM, sl, teamA, teamB);
            }
            return false;
        }

        static bool victory(Finite_State_Machine FSM, Save_and_Load<Party> sl, Party teamA, Party teamB, bool teamAwin)
        {
            VictoryWindow vw = new VictoryWindow(FSM, teamA, teamB, teamAwin);
            Application.Run(vw);
            if (Convert.ToString(FSM.CurrentState) == Convert.ToString(PlayerStates.Prebattle))
                Prebattle(FSM, sl);
            return false;
        }

        [STAThread]
        static void Main(string[] args)
        {
            Finite_State_Machine FSM = new Finite_State_Machine(PlayerStates.init);
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
            FSM.AddTransition(PlayerStates.victory, PlayerStates.Prebattle);
            FSM.info();

            init(FSM);

            Console.ReadLine();
        }
    }

}
