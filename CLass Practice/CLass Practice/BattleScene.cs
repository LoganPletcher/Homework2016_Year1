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
    public partial class BattleScene : Form
    {
        public BattleScene(List<Base_Class> teamA, List<Base_Class> teamB)
        {
            
            InitializeComponent();
            List<PictureBox> sideAimages = new List<PictureBox>();
            sideAimages.Add(teamAcharacter_1);
            sideAimages.Add(teamAcharacter_2);
            sideAimages.Add(teamAcharacter_3);
            List<PictureBox> sideBimages = new List<PictureBox>();
            sideBimages.Add(teamBcharacter_1);
            sideBimages.Add(teamBcharacter_2);
            sideBimages.Add(teamBcharacter_3);
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
            }
        }
    }
}
