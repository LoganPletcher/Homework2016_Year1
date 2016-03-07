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

namespace WindowsFormsTutorial1._2
{
    public partial class Form1 : Form
    {

        public List<string> PosList = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(e.GetType() == typeof(MouseEventArgs))
            {
                MouseEventArgs me = e as MouseEventArgs;
                textOutput.Text += me.Location.ToString() + ", ";
                PosList.Add(me.Location.ToString());
            }
        }

        private void buttonExport_Click()
        {
            //Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //if ((myStream = saveFileDialog1.OpenFile()) != null)
                //{
                //    // Code to write the stream goes here.
                //    myStream.Close();
                //}
                File.WriteAllText(saveFileDialog1.FileName, textOutput.Text);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            if (e.GetType() == typeof(MouseEventArgs))
            {
                MouseEventArgs me = e as MouseEventArgs;
                textOutput.Clear ();
                //textOutput.Text = "";
            }
        }
    }
}
