using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiceChart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series["Damage Rolls"].Points.Clear();
            List<int> D6Rolls = new List<int> { 3, 5, 2, 5, 5, 5, 5, 6, 6, 4, 1, 5, 1, 3, 5, 1, 2, 2, 4, 4, 1, 3, 3, 5, 2, 6, 4, 5, 5, 1, 4, 2, 5, 4, 6, 2, 4, 3, 3, 4, 4, 1, 4, 1, 2, 2, 4, 5, 6, 2, 4, 5, 6, 2, 4, 5, 5, 4, 4, 2, 5, 3 };
            D6Rolls.Sort();
            foreach (int d in D6Rolls)
            {
                chart1.Series["Damage Rolls"].Points.AddY(d);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series["Damage Rolls"].Points.Clear();
            int one = 0;
            int two = 0;
            int three = 0;
            int four = 0;
            int five = 0;
            int six = 0;
            List<int> D6Rolls = new List<int> { 3, 5, 2, 5, 5, 5, 5, 6, 6, 4, 1, 5, 1, 3, 5, 1, 2, 2, 4, 4, 1, 3, 3, 5, 2, 6, 4, 5, 5, 1, 4, 2, 5, 4, 6, 2, 4, 3, 3, 4, 4, 1, 4, 1, 2, 2, 4, 5, 6, 2, 4, 5, 6, 2, 4, 5, 5, 4, 4, 2, 5, 3 };
            D6Rolls.Sort();
            for(int i = 0; i < 60; i++)
            {
                if (D6Rolls[i] == 1) { one++; } if (D6Rolls[i] == 2) { two++; } if (D6Rolls[i] == 3) { three++; }
                if (D6Rolls[i] == 4) { four++; } if (D6Rolls[i] == 5) { five++; } if (D6Rolls[i] == 6) { six++; }
            }
            chart1.Series["Damage Rolls"].Points.AddY(one); chart1.Series["Damage Rolls"].Points.AddY(two);
            chart1.Series["Damage Rolls"].Points.AddY(three); chart1.Series["Damage Rolls"].Points.AddY(four);
            chart1.Series["Damage Rolls"].Points.AddY(five); chart1.Series["Damage Rolls"].Points.AddY(six);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            chart1.Series["Damage Rolls"].Points.Clear();
            Random rng = new Random();
            int rngRoll;
            List<int> RandomRolls = new List<int>();
            for(int i = 0; i < 60; i++)
            {
                rngRoll = rng.Next(1, 6);
                RandomRolls.Add(rngRoll);
            }
            RandomRolls.Sort();
            foreach (int r in RandomRolls)
            {
                chart1.Series["Damage Rolls"].Points.AddY(r);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            chart1.Series["Damage Rolls"].Points.Clear();
            int one = 0; int two = 0; int three = 0; int four = 0; int five = 0; int six = 0;
            Random rng = new Random();
            int rngRoll;
            List<int> RandomRolls = new List<int>();
            for (int i = 0; i < 60; i++)
            {
                rngRoll = rng.Next(1, 7);
                RandomRolls.Add(rngRoll);
            }
            RandomRolls.Sort();
            for (int i = 0; i < 60; i++)
            {
                if (RandomRolls[i] == 1) { one++; } if (RandomRolls[i] == 2) { two++; } if (RandomRolls[i] == 3) { three++; }
                if (RandomRolls[i] == 4) { four++; } if (RandomRolls[i] == 5) { five++; } if (RandomRolls[i] == 6) { six++; }
            }
            chart1.Series["Damage Rolls"].Points.AddY(one); chart1.Series["Damage Rolls"].Points.AddY(two);
            chart1.Series["Damage Rolls"].Points.AddY(three); chart1.Series["Damage Rolls"].Points.AddY(four);
            chart1.Series["Damage Rolls"].Points.AddY(five); chart1.Series["Damage Rolls"].Points.AddY(six);
        }
    }
}
