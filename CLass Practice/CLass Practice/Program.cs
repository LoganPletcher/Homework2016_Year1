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
                    BattleScene BS = new BattleScene(teamA, teamB, i, FirstUse);
                    Application.Run(BS);
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
                    TeamBbattlescene TBbs = new TeamBbattlescene(teamA, teamB, i);
                    Application.Run(TBbs);
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

        static bool End()
        {
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

            init(FSM);

            Console.ReadLine();
        }
    }

}
