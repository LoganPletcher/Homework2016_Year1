using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace CLass_Practice
{
    public class Save_and_Load<T>
    {
        public Save_and_Load() { }

        public void Save(string s, T t)
        {
            FileStream SaveFile = File.Create(@"..\..\SavedTeamFiles" + s + ".bin");
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(SaveFile, t);
        }

        public void /*T*/ Load(string s)
        {

        }
    }
}
