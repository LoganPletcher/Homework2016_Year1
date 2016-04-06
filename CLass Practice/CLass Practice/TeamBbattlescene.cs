using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Threading;

namespace CLass_Practice
{
    public partial class TeamBbattlescene : Form
    {
        public Random rng = new Random();
        public Unit SelectedUnit = null;
        public Unit CurrentUnit = new Unit();
        public Party m_TA = new Party();
        public Party m_TB = new Party();
        List<PictureBox> sideAimages = new List<PictureBox>();
        List<PictureBox> sideBimages = new List<PictureBox>();
        List<int> sideBimageLefts = new List<int>();
        List<TextBox> sideAinfoboxes = new List<TextBox>();
        List<TextBox> sideBinfoboxes = new List<TextBox>();
        List<int> sideBtextLefts = new List<int>();

        public TeamBbattlescene(Party team1, Party team2, int CU)
        {
            m_TA = team1;
            m_TB = team2;
            InitializeComponent();
            
            sideAimages.Add(teamAcharacter_1);
            sideAimages.Add(teamAcharacter_2);
            sideAimages.Add(teamAcharacter_3);
            sideBimages.Add(teamBcharacter_1);
            sideBimages.Add(teamBcharacter_2);
            sideBimages.Add(teamBcharacter_3);
            
            sideBimageLefts.Add(teamBcharacter_1.Left);
            sideBimageLefts.Add(teamBcharacter_2.Left);
            sideBimageLefts.Add(teamBcharacter_3.Left);
            
            sideAinfoboxes.Add(teamAcharacter_1_infobox);
            sideAinfoboxes.Add(teamAcharacter_2_infobox);
            sideAinfoboxes.Add(teamAcharacter_3_infobox);
            sideBinfoboxes.Add(teamBcharacter_1_infobox);
            sideBinfoboxes.Add(teamBcharacter_2_infobox);
            sideBinfoboxes.Add(teamBcharacter_3_infobox);
            
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

            BattleEvents.LoadFile(@"..\..\Resources\BattleEvents.rtf");
            this.WindowState = FormWindowState.Maximized;
            if (this.Height < 1080)
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
            CurrentUnit = team2.Members[CU];
        }

        private void TeamBbattlescene_Load(object sender, EventArgs e)
        {
            int SU = rng.Next(0, 3);
            int Ability = rng.Next(0,3);
            if (BattleEvents.Lines.Count() >= 6)
                BattleEvents.Clear();
            if (CurrentUnit.CharacterClass != 6)
            {
                while (m_TA.Members[SU].Health < 0)
                    SU = rng.Next(0, 3);
                if (Ability == 0)
                    CurrentUnit.Ability1(m_TA.Members[SU], BattleEvents);
                if (Ability == 1)
                    CurrentUnit.Ability2(m_TA.Members[SU], BattleEvents);
                if (Ability == 2)
                    CurrentUnit.Ability3(m_TA.Members[SU], BattleEvents);
            }
            else
            {
                while (m_TB.Members[SU].Health < 0)
                    SU = rng.Next(0, 3);
                if (Ability == 0)
                    CurrentUnit.Ability1(m_TB.Members[SU], BattleEvents);
                if (Ability == 1)
                    CurrentUnit.Ability2(m_TB.Members[SU], BattleEvents);
                if (Ability == 2)
                    CurrentUnit.Ability3(m_TB.Members[SU], BattleEvents);
            }
            for (int i = 0; i < 3; i++)
            {
                sideAinfoboxes[i].Clear();
                sideAinfoboxes[i].Text += m_TA.Members[i].Name + " Level: ";
                sideAinfoboxes[i].Text += m_TA.Members[i].Level + " Class: ";
                sideAinfoboxes[i].Text += Convert.ToString(m_TA.Members[i].GetType());
                sideAinfoboxes[i].Text += "\r\nHP: " + m_TA.Members[i].Health + "/" + m_TA.Members[i].MaxHealth;
                sideBinfoboxes[i].Clear();
                sideBinfoboxes[i].Text += m_TB.Members[i].Name + " Level: ";
                sideBinfoboxes[i].Text += m_TB.Members[i].Level + " Class: ";
                sideBinfoboxes[i].Text += Convert.ToString(m_TB.Members[i].GetType());
                sideBinfoboxes[i].Text += "\r\nHP: " + m_TB.Members[i].Health + "/" + m_TB.Members[i].MaxHealth;
            }
        }

        private void Continue(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
