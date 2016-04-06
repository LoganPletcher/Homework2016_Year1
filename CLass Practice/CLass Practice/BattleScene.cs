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
            
            m_TA = team1.Members;
            m_TB = team2.Members;
            InitializeComponent();
            List<PictureBox> sideAimages = new List<PictureBox>();
            sideAimages.Add(teamAcharacter_1);
            sideAimages.Add(teamAcharacter_2);
            sideAimages.Add(teamAcharacter_3);
            List<PictureBox> sideBimages = new List<PictureBox>();
            sideBimages.Add(teamBcharacter_1);
            sideBimages.Add(teamBcharacter_2);
            sideBimages.Add(teamBcharacter_3);
            List<int> sideBimageLefts = new List<int>();
            sideBimageLefts.Add(teamBcharacter_1.Left);
            sideBimageLefts.Add(teamBcharacter_2.Left);
            sideBimageLefts.Add(teamBcharacter_3.Left);
            List<TextBox> sideAinfoboxes = new List<TextBox>();
            sideAinfoboxes.Add(teamAcharacter_1_infobox);
            sideAinfoboxes.Add(teamAcharacter_2_infobox);
            sideAinfoboxes.Add(teamAcharacter_3_infobox);
            List<TextBox> sideBinfoboxes = new List<TextBox>();
            sideBinfoboxes.Add(teamBcharacter_1_infobox);
            sideBinfoboxes.Add(teamBcharacter_2_infobox);
            sideBinfoboxes.Add(teamBcharacter_3_infobox);
            List<int> sideBtextLefts = new List<int>();
            sideBtextLefts.Add(teamBcharacter_1_infobox.Left);
            sideBtextLefts.Add(teamBcharacter_2_infobox.Left);
            sideBtextLefts.Add(teamBcharacter_3_infobox.Left);
            for (int i = 0; i < 3; i++)
            {
                if (team1.Members[i].CharacterClass == 1)
                { sideAimages[i].BackgroundImage = Properties.Resources.Black_Mage1; }
                else if (team1.Members[i].CharacterClass == 2)
                { sideAimages[i].BackgroundImage = Properties.Resources.Archer1; }
                else if (team1.Members[i].CharacterClass == 3)
                { sideAimages[i].BackgroundImage = Properties.Resources.Blue_Mage1; }
                else if (team1.Members[i].CharacterClass == 4)
                { sideAimages[i].BackgroundImage = Properties.Resources.Warrior1; }
                else if (team1.Members[i].CharacterClass == 5)
                { sideAimages[i].BackgroundImage = Properties.Resources.Paladin1; }
                else if (team1.Members[i].CharacterClass == 6)
                { sideAimages[i].BackgroundImage = Properties.Resources.White_Mage1; }
                sideAinfoboxes[i].Text += team1.Members[i].Name + " Level: ";
                sideAinfoboxes[i].Text += team1.Members[i].Level + " Class: ";
                sideAinfoboxes[i].Text += Convert.ToString(team1.Members[i].GetType());
                sideAinfoboxes[i].Text += "\r\nHP: " + team1.Members[i].Health + "/" + team1.Members[i].MaxHealth;
            }
            for (int i = 0; i < 3; i++)
            {
                if (team2.Members[i].CharacterClass == 1)
                { sideBimages[i].BackgroundImage = Properties.Resources.Black_Mage2; }
                else if (team2.Members[i].CharacterClass == 2)
                { sideBimages[i].BackgroundImage = Properties.Resources.Archer2; }
                else if (team2.Members[i].CharacterClass == 3)
                { sideBimages[i].BackgroundImage = Properties.Resources.Blue_Mage2; }
                else if (team2.Members[i].CharacterClass == 4)
                { sideBimages[i].BackgroundImage = Properties.Resources.Warrior2; }
                else if (team2.Members[i].CharacterClass == 5)
                { sideBimages[i].BackgroundImage = Properties.Resources.Paladin2; }
                else if (team2.Members[i].CharacterClass == 6)
                { sideBimages[i].BackgroundImage = Properties.Resources.White_Mage2; }
                sideBinfoboxes[i].Text += team2.Members[i].Name + " Level: ";
                sideBinfoboxes[i].Text += team2.Members[i].Level + " Class: ";
                sideBinfoboxes[i].Text += Convert.ToString(team2.Members[i].GetType());
                sideBinfoboxes[i].Text += "\r\nHP: " + team2.Members[i].Health + "/" + team2.Members[i].MaxHealth;
            }
            CurrentUnit = team1.Members[CU];
            
            BattleEvents.LoadFile(@"..\..\Resources\BattleEvents.rtf");
            if (FirstUse)
            {
                BattleEvents.Clear();
                BattleEvents.SaveFile(@"..\..\Resources\BattleEvents.rtf");
            }
            this.WindowState = FormWindowState.Maximized;
            if(this.Height < 1080)
            {
                if (this.Height < 900)
                {
                    if (this.Height < 720)
                        this.BattleEvents.Width = 330;
                    else
                        this.BattleEvents.Width = 550;
                }
                else
                    this.BattleEvents.Width = 710;
            }
            foreach (PictureBox pb in sideAimages)
            {
                if (this.Height < 1080)
                {
                    pb.Top = (pb.Top * Height) / 970;
                    pb.Left = (pb.Left * Width) / 1830;
                    if (this.Height < 900)
                    {
                        if (this.Height < 720)
                        {
                            pb.Height = (int)((double)321 / 1.8);
                            pb.Width = (int)((double)291 / 1.8);
                        }
                        else
                        {
                            pb.Height = (int)((double)321 / 1.5);
                            pb.Width = (int)((double)291 / 1.5);
                        }
                    }
                    else
                    {
                        pb.Height = (int)((double)321 / 1.2);
                        pb.Width = (int)((double)291 / 1.2);
                    }
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (this.Height < 1080)
                {
                    sideBimages[i].Top = (sideBimages[i].Top * Height) / 970;
                    sideBimages[i].Left = ((sideBimageLefts[i] * Width) / 1830) - 36;
                    if (this.Height < 900)
                    {
                        if (this.Height < 720)
                        {
                            sideBimages[i].Height = (int)((double)321 / 1.8);
                            sideBimages[i].Width = (int)((double)291 / 1.8);
                        }
                        else
                        {
                            sideBimages[i].Height = (int)((double)321 / 1.5);
                            sideBimages[i].Width = (int)((double)291 / 1.5);
                        }
                    }
                    else
                    {
                        sideBimages[i].Height = (int)((double)321 / 1.2);
                        sideBimages[i].Width = (int)((double)291 / 1.2);
                    }
                }
            }
            foreach (TextBox pb in sideAinfoboxes)
            {
                if (this.Height < 1080)
                {
                    pb.Top = ((pb.Top * Height) / 970) - 20;
                    pb.Left = (pb.Left * Width) / 1830;
                    if (this.Height < 900)
                    {
                        if (this.Height < 720)
                        {
                            pb.Width = (int)((double)291 / 1.8);
                        }
                        else
                            pb.Width = (int)((double)291 / 1.5);
                    }
                    else
                        pb.Width = (int)((double)291 / 1.2);
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (this.Height < 1080)
                {
                    sideBinfoboxes[i].Top = ((sideBinfoboxes[i].Top * Height) / 970) - 20;
                    sideBinfoboxes[i].Left = ((sideBtextLefts[i] * Width) / 1830) - 36;
                    if (this.Height < 900)
                    {
                        if (this.Height < 720)
                        {
                            sideBinfoboxes[i].Width = (int)((double)291 / 1.8);
                        }
                        else
                            sideBinfoboxes[i].Width = (int)((double)291 / 1.5);
                    }
                    else
                        sideBinfoboxes[i].Width = (int)((double)291 / 1.2);
                }
            }
        }

        private void Ability1Button_Click(object sender, EventArgs e)
        {
            if (BattleEvents.Lines.Count() >= 6)
                BattleEvents.Clear();
            if(SelectedUnit != null)
            {
                if (SelectedUnit.Health > 0)
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
                        if (m_TA[i].Name == SelectedUnit.Name)
                            m_TA[i] = SelectedUnit;
                        //BattleEvents.SaveFile(@"..\..\Resources\BattleEvents.rtf");
                        this.Close();
                    }
                }
                else
                    BattleEvents.Text += "Unit is already dead. Choose another one.\r\n";
            }
        }

        private void Ability2Button_Click(object sender, EventArgs e)
        {
            if (BattleEvents.Lines.Count() >= 6)
                BattleEvents.Clear();
            if (SelectedUnit != null)
            {
                if (SelectedUnit.Health > 0)
                {
                    CurrentUnit.Ability2(SelectedUnit, BattleEvents);
                    for (int i = 0; i < 3; i++)
                    {
                        if (m_TB[i].Name == SelectedUnit.Name)
                            m_TB[i] = SelectedUnit;
                        //BattleEvents.SaveFile(@"..\..\Resources\BattleEvents.rtf");
                        this.Close();
                    }
                    for (int i = 0; i < 3; i++)
                    {
                        if (m_TA[i].Name == SelectedUnit.Name)
                            m_TA[i] = SelectedUnit;
                        //BattleEvents.SaveFile(@"..\..\Resources\BattleEvents.rtf");
                        this.Close();
                    }
                }
                else
                    BattleEvents.Text += "Unit is already dead. Choose another one.\r\n";
            }
        }

        private void Ability3Button_Click(object sender, EventArgs e)
        {
            if (BattleEvents.Lines.Count() >= 6)
                BattleEvents.Clear();
            if (SelectedUnit != null)
            {
                if (SelectedUnit.Health > 0)
                {
                    CurrentUnit.Ability3(SelectedUnit, BattleEvents);
                    for (int i = 0; i < 3; i++)
                    {
                        if (m_TB[i].Name == SelectedUnit.Name)
                            m_TB[i] = SelectedUnit;
                        //BattleEvents.SaveFile(@"..\..\Resources\BattleEvents.rtf");
                        this.Close();
                    }
                    for (int i = 0; i < 3; i++)
                    {
                        if (m_TA[i].Name == SelectedUnit.Name)
                            m_TA[i] = SelectedUnit;
                        //BattleEvents.SaveFile(@"..\..\Resources\BattleEvents.rtf");
                        this.Close();
                    }
                }
                else
                    BattleEvents.Text += "Unit is already dead. Choose another one.\r\n";
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
