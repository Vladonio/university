using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OOP_Lab1.Models;
using OOP_Lab1.ViewModels;

namespace OOP_Lab1.Serializers
{
    class JsonSerialize : ISerializers
    {
        public string Format { get; } = "Json (*.json)|*.json";

        public object DeSeriazlixeObject(FileStream file)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            };
            StreamReader reader = new StreamReader(file);
            file.Position = 0;
            string content = reader.ReadToEnd();
            AllModels newObjects = JsonConvert.DeserializeObject<AllModels>(content, settings);
            reader.Close();
            return newObjects;
        }

        public void SerializeObject(object objects, string fileName)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            };
            string output = JsonConvert.SerializeObject(objects, settings);
            File.WriteAllText(fileName, output);
        }
    }
}
