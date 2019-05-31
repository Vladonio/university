using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OOP_Lab1.ViewModels;
using OOP_Lab1.Models;

namespace OOP_Lab1.Serializers.Custom
{
    class CustomSerializer : ISerializers
    {
        Dictionary<int, object> moduleDictionary = new Dictionary<int, object>();

        public int Row { get; set; }

        public int Column { get; set; }

        private readonly List<EntitySerializer> serializers;

        public string Format { get; } = "Text (*.txt)|*.txt";

        public CustomSerializer()
        {
            serializers = new List<EntitySerializer>();

            SimpleTypeSerializer simpleTypeSerializer = new SimpleTypeSerializer();
            serializers.Add(simpleTypeSerializer);

            ClassSerializer classSerializer = new ClassSerializer();
            serializers.Add(classSerializer);

            CollectionSerializer collectionSerializer = new CollectionSerializer();
            serializers.Add(collectionSerializer);

            classSerializer.AddSerializer(serializers);
            collectionSerializer.AddSerializers(serializers);
        }

        public object DeSeriazlixeObject(FileStream file)
        {
            file.Position = 0;
            int row = 0;
            int column = 0;

            List<string> lines = new List<string>();
            using (var sr = new StreamReader(file))
            {
                while (!sr.EndOfStream)
                {
                    lines.Add(sr.ReadLine());
                }

            }
            EntitySerializer correctDeserializer = serializers.Single(s => s.CanDeserialize(lines, row, column));
            var result = correctDeserializer.Deserialize(lines, ref row, ref column, moduleDictionary);

            return result;
        }


        public void SerializeObject(object obj, string fileName)
        {
            var serializer = new ClassSerializer();

            EntitySerializer correctSerializer = serializers.Single(s => s.CanSerialize(obj));


            var result = correctSerializer.Serialize(obj, moduleDictionary);
            File.WriteAllText(fileName, result);
        }
    }
}
