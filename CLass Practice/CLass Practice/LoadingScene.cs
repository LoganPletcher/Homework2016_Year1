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
        
        Party PlayerTeam = new Party();

        public LoadingScene(Party PT)
        {
            PlayerTeam = PT;
            InitializeComponent();
        }

        OpenFileDialog ofd = new OpenFileDialog();

        private void Yes_Click(object sender, EventArgs e)
        {
            Save_and_Load<Party> sl = new Save_and_Load<Party>();
            Party LoadedTeam = sl.Load();
            //PlayerTeam = LoadedTeam;
            foreach (Unit u in LoadedTeam.Members)
            {
                PlayerTeam.Members.Add(u);
            }
            this.Close();
            /*
            if (LoadedTeam.Members.Count != 0)
            {
                for(int i = 0; i <3; i++)
                {
                    
                }
                PlayerTeam.Add(LoadedTeam[0]);
                PlayerTeam.Add(LoadedTeam[1]);
                PlayerTeam.Add(LoadedTeam[2]);
                this.Close();
            }
            else { }
            */
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
