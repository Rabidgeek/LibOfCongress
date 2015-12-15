using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace LibOfCongress
{
    class Serializer
    {
        public Serializer() { }

        public void CreateNewFile(string fileName)
        {
            Stream stream = File.Create(fileName);
            stream.Close();
        }

        public void SerializeObject(string fileName, Library lib)
        {
            Stream stream = File.Open(fileName, FileMode.OpenOrCreate);
            BinaryFormatter bformatter = new BinaryFormatter();
            bformatter.Serialize(stream, lib);
            stream.Close();
        }

        public Library DeSerializeObject(string fileName)
        {
            Library lib;
            Stream stream = File.Open(fileName, FileMode.Open);
            BinaryFormatter bformatter = new BinaryFormatter();
            lib = (Library)bformatter.Deserialize(stream);
            stream.Close();
            return lib;
        }
    }
}
