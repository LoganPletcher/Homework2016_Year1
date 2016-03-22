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
    public partial class LoadingScene : Form
    {
        
        List<Base_Class> PlayerTeam = new List<Base_Class>();

        public LoadingScene(List<Base_Class> PT)
        {
            PlayerTeam = PT;
            InitializeComponent();
        }

        OpenFileDialog ofd = new OpenFileDialog();

        private void Yes_Click(object sender, EventArgs e)
        {
            Save_and_Load<List<Base_Class>> sl = new Save_and_Load<List<Base_Class>>();
            //ofd.ShowDialog();
            List<Base_Class> LoadedTeam = sl.Load("PlayerTeam1");
            //Fighter Character1 = new Fighter("Logan", 3);
            PlayerTeam.Add(LoadedTeam[0]);
            //Blue_Mage Character2 = new Blue_Mage("Daniel", 3);
            PlayerTeam.Add(LoadedTeam[1]);
            //White_Mage Character3 = new White_Mage("Erik", 3);
            PlayerTeam.Add(LoadedTeam[2]);
            this.Close();
        }

        private void No_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadingScene_Load(object sender, EventArgs e)
        {
            BackgroundImage = Properties.Resources.fire_49;
        }
    }
}
