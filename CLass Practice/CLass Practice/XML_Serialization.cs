using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace CLass_Practice
{
    public class XML_Serialization<T>
    {
        public XML_Serialization() { }

        public void Serialize(string s, T t)
        {
            File.Create(@"..\..\SavedTeamFiles" + s + ".bin");
        }

        public void /*T*/ Deserialization(string s)
        {

        }
    }
}
