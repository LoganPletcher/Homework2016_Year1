using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace CLass_Practice
{
    public class Save_and_Load<T>
    {
        public Save_and_Load() { }

        public void Save(T info)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();
            FileStream SaveFile = sfd.OpenFile() as FileStream;
            XmlSerializer bf = new XmlSerializer(typeof (T));
            bf.Serialize(SaveFile, info);
            SaveFile.Close();
        }

        public T Load()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            T MalleableVar;
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                FileStream LoadFile = ofd.OpenFile() as FileStream;
                XmlSerializer bf = new XmlSerializer(typeof (T));
                MalleableVar = (T)bf.Deserialize(LoadFile);
                LoadFile.Close();
            }
            else
            {
                FileStream LoadFile = File.OpenRead(@"..\..\SavedTeamFiles\Empty");
                XmlSerializer bf = new XmlSerializer(typeof (T));
                MalleableVar = (T)bf.Deserialize(LoadFile);
                LoadFile.Close();
            }
            return MalleableVar;
        }
    }
}
