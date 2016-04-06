using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLass_Practice
{
    public partial class VictoryWindow : Form
    {

        public Party m_TA = new Party();
        public Party m_TB = new Party();
        public Finite_State_Machine fsm;

        public VictoryWindow(Finite_State_Machine FSM, Party team1, Party team2, bool teamAwin)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            m_TA = team1;
            m_TB = team2;
            fsm = FSM;
            if (teamAwin)
            {
                int avg = (m_TB.Members[0].Level + m_TB.Members[1].Level + m_TB.Members[2].Level) / 3;
                int XPreward = avg * 100;
                foreach (Unit u in m_TA.Members)
                {
                    u.ExperiencePoints += XPreward;
                    if (u.ExperiencePoints >= u.ExperiencetoLevelUp)
                        u.LevelingUp();
                    u.Refresh();
                }
                Vtext.Text = "You Win!";
            }
            else
            {
                Vtext.Text = "You Lose";
                saveButton.Visible = false;
            }
        }
        
        private void VictoryWindow_Load(object sender, EventArgs e)
        {
            BackgroundImage = Properties.Resources.fire_49;
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            fsm.ChangeStates("victory->Prebattle");
            this.Close();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Save_and_Load<Party> sl = new Save_and_Load<Party>();
            sl.Save(m_TA);
        }
    }
}
