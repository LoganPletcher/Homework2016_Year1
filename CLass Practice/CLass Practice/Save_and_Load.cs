using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Forms;

namespace CLass_Practice
{
    public class Save_and_Load<T>
    {
        public Save_and_Load() { }

        public void Save(string s, T info)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();
            FileStream SaveFile = sfd.OpenFile() as FileStream;
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(SaveFile, info);
            SaveFile.Close();
        }

        public T Load(string s)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            T MalleableVar;
            ofd.ShowDialog();
            FileStream LoadFile = ofd.OpenFile() as FileStream;
            BinaryFormatter bf = new BinaryFormatter();
            MalleableVar = (T)bf.Deserialize(LoadFile);
            LoadFile.Close();
            return MalleableVar;
        }
    }
}
