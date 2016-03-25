using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CLass_Practice
{
    public partial class BattleScene : Form
    {

        protected Unit CurrentUnit = new Unit();
        public Unit SelectedUnit = null;
        public List<Unit> m_TA = new List<Unit>();
        public List<Unit> m_TB = new List<Unit>();

        public BattleScene(Party team1, Party team2, int CU, bool FirstUse)
        {
            List<Unit> teamA = new List<Unit>();
            List<Unit> teamB = new List<Unit>();
            teamA = team1.Members;
            teamB = team2.Members;

            m_TA = teamA;
            m_TB = teamB;
            InitializeComponent();
            List<PictureBox> sideAimages = new List<PictureBox>();
            sideAimages.Add(teamAcharacter_1);
            sideAimages.Add(teamAcharacter_2);
            sideAimages.Add(teamAcharacter_3);
            List<PictureBox> sideBimages = new List<PictureBox>();
            sideBimages.Add(teamBcharacter_1);
            sideBimages.Add(teamBcharacter_2);
            sideBimages.Add(teamBcharacter_3);
            List<TextBox> sideAinfoboxes = new List<TextBox>();
            sideAinfoboxes.Add(teamAcharacter_1_infobox);
            sideAinfoboxes.Add(teamAcharacter_2_infobox);
            sideAinfoboxes.Add(teamAcharacter_3_infobox);
            List<TextBox> sideBinfoboxes = new List<TextBox>();
            sideBinfoboxes.Add(teamBcharacter_1_infobox);
            sideBinfoboxes.Add(teamBcharacter_2_infobox);
            sideBinfoboxes.Add(teamBcharacter_3_infobox);
            for (int i = 0; i < 3; i++)
            {
                if (teamA[i].CharacterClass == 1)
                { sideAimages[i].BackgroundImage = Properties.Resources.Black_Mage1; }
                else if (teamA[i].CharacterClass == 2)
                { sideAimages[i].BackgroundImage = Properties.Resources.Archer1; }
                else if (teamA[i].CharacterClass == 3)
                { sideAimages[i].BackgroundImage = Properties.Resources.Blue_Mage1; }
                else if (teamA[i].CharacterClass == 4)
                { sideAimages[i].BackgroundImage = Properties.Resources.Warrior1; }
                else if (teamA[i].CharacterClass == 5)
                { sideAimages[i].BackgroundImage = Properties.Resources.Paladin1; }
                else if (teamA[i].CharacterClass == 6)
                { sideAimages[i].BackgroundImage = Properties.Resources.White_Mage1; }
                sideAinfoboxes[i].Text += teamA[i].Name + " Level: ";
                sideAinfoboxes[i].Text += teamA[i].Level + " Class: ";
                sideAinfoboxes[i].Text += Convert.ToString(teamA[i].GetType());
                sideAinfoboxes[i].Text += "\r\nHP: " + teamA[i].Health + "/" + teamA[i].MaxHealth;
            }
            for (int i = 0; i < 3; i++)
            {
                if (teamB[i].CharacterClass == 1)
                { sideBimages[i].BackgroundImage = Properties.Resources.Black_Mage2; }
                else if (teamB[i].CharacterClass == 2)
                { sideBimages[i].BackgroundImage = Properties.Resources.Archer2; }
                else if (teamB[i].CharacterClass == 3)
                { sideBimages[i].BackgroundImage = Properties.Resources.Blue_Mage2; }
                else if (teamB[i].CharacterClass == 4)
                { sideBimages[i].BackgroundImage = Properties.Resources.Warrior2; }
                else if (teamB[i].CharacterClass == 5)
                { sideBimages[i].BackgroundImage = Properties.Resources.Paladin2; }
                else if (teamB[i].CharacterClass == 6)
                { sideBimages[i].BackgroundImage = Properties.Resources.White_Mage2; }
                sideBinfoboxes[i].Text += teamB[i].Name + " Level: ";
                sideBinfoboxes[i].Text += teamB[i].Level + " Class: ";
                sideBinfoboxes[i].Text += Convert.ToString(teamB[i].GetType());
                sideBinfoboxes[i].Text += "\r\nHP: " + teamB[i].Health + "/" + teamB[i].MaxHealth;
            }
            CurrentUnit = teamA[CU];
            
            BattleEvents.LoadFile(@"..\..\Resources\BattleEvents.rtf");
            if (FirstUse)
            {
                BattleEvents.Clear();
                BattleEvents.SaveFile(@"..\..\Resources\BattleEvents.rtf");
            }
        }

        private void Ability1Button_Click(object sender, EventArgs e)
        {
            if (BattleEvents.Lines.Count() >= 6)
                BattleEvents.Clear();
            if(SelectedUnit != null)
            {
                CurrentUnit.Ability1(SelectedUnit, BattleEvents);
                for (int i = 0; i < 3; i++)
                {
                    if (m_TB[i].Name == CurrentUnit.Name)
                        m_TB[i] = CurrentUnit;
                    //BattleEvents.SaveFile(@"..\..\Resources\BattleEvents.rtf");
                    this.Close();
                }
                for (int i = 0; i < 3; i++)
                {
                    if (m_TA[i].Name == CurrentUnit.Name)
                        m_TA[i] = CurrentUnit;
                    //BattleEvents.SaveFile(@"..\..\Resources\BattleEvents.rtf");
                    this.Close();
                }
            }
        }

        private void Ability2Button_Click(object sender, EventArgs e)
        {
            if (BattleEvents.Lines.Count() >= 6)
                BattleEvents.Clear();
            if (SelectedUnit != null)
            {
                CurrentUnit.Ability2(SelectedUnit, BattleEvents);
                for (int i = 0; i < 3; i++)
                {
                    if (m_TB[i].Name == CurrentUnit.Name)
                        m_TB[i] = CurrentUnit;
                    //BattleEvents.SaveFile(@"..\..\Resources\BattleEvents.rtf");
                    this.Close();
                }
                for (int i = 0; i < 3; i++)
                {
                    if (m_TA[i].Name == CurrentUnit.Name)
                        m_TA[i] = CurrentUnit;
                    //BattleEvents.SaveFile(@"..\..\Resources\BattleEvents.rtf");
                    this.Close();
                }
            }
        }

        private void Ability3Button_Click(object sender, EventArgs e)
        {
            if (BattleEvents.Lines.Count() >= 6)
                BattleEvents.Clear();
            if (SelectedUnit != null)
            {
                CurrentUnit.Ability3(SelectedUnit, BattleEvents);
                for (int i = 0; i < 3; i++)
                {
                    if (m_TB[i].Name == CurrentUnit.Name)
                        m_TB[i] = CurrentUnit;
                    //BattleEvents.SaveFile(@"..\..\Resources\BattleEvents.rtf");
                    this.Close();
                }
                for (int i = 0; i < 3; i++)
                {
                    if (m_TA[i].Name == CurrentUnit.Name)
                        m_TA[i] = CurrentUnit;
                    //BattleEvents.SaveFile(@"..\..\Resources\BattleEvents.rtf");
                    this.Close();
                }
            }
        }

        private void teamBcharacter_1_Click(object sender, EventArgs e)
        {
            if (CurrentUnit.CharacterClass != 6)
            {
                teamBcharacter_1.BackColor = Color.FromArgb(Convert.ToInt32(50), Convert.ToInt32(255), Convert.ToInt32(0), Convert.ToInt32(0));
                teamBcharacter_2.BackColor = Color.Transparent;
                teamBcharacter_3.BackColor = Color.Transparent;
                teamAcharacter_1.BackColor = Color.Transparent;
                teamAcharacter_2.BackColor = Color.Transparent;
                teamAcharacter_3.BackColor = Color.Transparent;
                SelectedUnit = m_TB[0];
            }
        }

        private void teamBcharacter_2_Click(object sender, EventArgs e)
        {
            if (CurrentUnit.CharacterClass != 6)
            {
                teamBcharacter_1.BackColor = Color.Transparent;
                teamBcharacter_2.BackColor = Color.FromArgb(Convert.ToInt32(50), Convert.ToInt32(255), Convert.ToInt32(0), Convert.ToInt32(0));
                teamBcharacter_3.BackColor = Color.Transparent;
                teamAcharacter_1.BackColor = Color.Transparent;
                teamAcharacter_2.BackColor = Color.Transparent;
                teamAcharacter_3.BackColor = Color.Transparent;
                SelectedUnit = m_TB[1];
            }
        }

        private void teamBcharacter_3_Click(object sender, EventArgs e)
        {
            if (CurrentUnit.CharacterClass != 6)
            {
                teamBcharacter_1.BackColor = Color.Transparent;
                teamBcharacter_2.BackColor = Color.Transparent;
                teamBcharacter_3.BackColor = Color.FromArgb(Convert.ToInt32(50), Convert.ToInt32(255), Convert.ToInt32(0), Convert.ToInt32(0));
                teamAcharacter_1.BackColor = Color.Transparent;
                teamAcharacter_2.BackColor = Color.Transparent;
                teamAcharacter_3.BackColor = Color.Transparent;
                SelectedUnit = m_TB[2];
            }
        }

        private void teamAcharacter_1_Click(object sender, EventArgs e)
        {
            if (CurrentUnit.CharacterClass == 6)
            {
                teamAcharacter_1.BackColor = Color.FromArgb(Convert.ToInt32(50), Convert.ToInt32(0), Convert.ToInt32(255), Convert.ToInt32(0));
                teamAcharacter_2.BackColor = Color.Transparent;
                teamAcharacter_3.BackColor = Color.Transparent;
                teamBcharacter_1.BackColor = Color.Transparent;
                teamBcharacter_2.BackColor = Color.Transparent;
                teamBcharacter_3.BackColor = Color.Transparent;
                SelectedUnit = m_TA[0];
            }
        }

        private void teamAcharacter_2_Click(object sender, EventArgs e)
        {
            if (CurrentUnit.CharacterClass == 6)
            {
                teamAcharacter_1.BackColor = Color.Transparent;
                teamAcharacter_2.BackColor = Color.FromArgb(Convert.ToInt32(50), Convert.ToInt32(0), Convert.ToInt32(255), Convert.ToInt32(0));
                teamAcharacter_3.BackColor = Color.Transparent;
                teamBcharacter_1.BackColor = Color.Transparent;
                teamBcharacter_2.BackColor = Color.Transparent;
                teamBcharacter_3.BackColor = Color.Transparent;
                SelectedUnit = m_TA[1];
            }
        }

        private void teamAcharacter_3_Click(object sender, EventArgs e)
        {
            if (CurrentUnit.CharacterClass == 6)
            {
                teamAcharacter_1.BackColor = Color.Transparent;
                teamAcharacter_2.BackColor = Color.Transparent;
                teamAcharacter_3.BackColor = Color.FromArgb(Convert.ToInt32(50), Convert.ToInt32(0), Convert.ToInt32(255), Convert.ToInt32(0));
                teamBcharacter_1.BackColor = Color.Transparent;
                teamBcharacter_2.BackColor = Color.Transparent;
                teamBcharacter_3.BackColor = Color.Transparent;
                SelectedUnit = m_TA[2];
            }
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            Save_and_Load<Party> saveObject = new Save_and_Load<Party>();
            Party p1 = new Party();
            p1.Members = m_TA;
            Party p2 = new Party();
            p2.Members = m_TB;
            saveObject.Save(p1);
            saveObject.Save(p2);
        }
    }
}
