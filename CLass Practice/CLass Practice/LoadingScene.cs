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
        
        List<Unit> PlayerTeam = new List<Unit>();

        public LoadingScene(List<Unit> PT)
        {
            PlayerTeam = PT;
            InitializeComponent();
        }

        OpenFileDialog ofd = new OpenFileDialog();

        private void Yes_Click(object sender, EventArgs e)
        {
            Save_and_Load<List<Unit>> sl = new Save_and_Load<List<Unit>>();
            List<Unit> LoadedTeam = sl.Load();
            if (LoadedTeam.Count != 0)
            {
                PlayerTeam.Add(LoadedTeam[0]);
                PlayerTeam.Add(LoadedTeam[1]);
                PlayerTeam.Add(LoadedTeam[2]);
                this.Close();
            }
            else { }
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
