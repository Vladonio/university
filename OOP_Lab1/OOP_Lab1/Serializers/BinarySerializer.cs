using OOP_Lab1.ViewModels;
using Polenter.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab1.Serializers
{
    class BinarySerializer : ISerializers
    {
        public string Format { get; } = "Binary (*.bin)|*.bin";

        public object DeSeriazlixeObject(FileStream file)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            file.Position = 0;
            var newObjects = (AllModels)formatter.Deserialize(file);
            return newObjects;
        }

        public void SerializeObject(object objects, string fileName)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fileStream, objects);
            fileStream.Close();
        }
    }
}
