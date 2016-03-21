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
        public LoadingScene()
        {
            InitializeComponent();
        }

        OpenFileDialog ofd = new OpenFileDialog();

        private void Yes_Click(object sender, EventArgs e)
        {
            ofd.ShowDialog();
        }

        private void No_Click(object sender, EventArgs e)
        {

        }

        private void LoadingScene_Load(object sender, EventArgs e)
        {
            BackgroundImage = Properties.Resources.fire_49;
        }
    }
}
