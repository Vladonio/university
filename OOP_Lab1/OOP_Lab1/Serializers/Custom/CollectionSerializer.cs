using OOP_Lab1.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace OOP_Lab1.Serializers.Custom
{
    public class CollectionSerializer : EntitySerializer
    {
        private List<EntitySerializer> serializers;

        public CollectionSerializer()
        {
            serializers = new List<EntitySerializer>();
        }

        public void AddSerializers(IEnumerable<EntitySerializer> serializers)
        {
            this.serializers.AddRange(serializers);
        }

        public override bool CanDeserialize(List<string> value, int row, int column)
        {
            return (value[row][column] == '[');
        }

        public override bool CanSerialize(object obj)
        {
            return obj is ICollection;
        }

        public override object Deserialize(List<string> value, ref int row, ref int column, Dictionary<int, object> moduleDictionary)
        {
            string type = (value[row].Substring(2, value[row].IndexOf('s') - 2));
            if (type == "Module")
            {
                row++;
                column = 0;


                var instance = new ObservableCollection<Module>();

                while (value[row][column] != ']')
                {

                    int tempRow = row;
                    int tempColumn = column;
                    EntitySerializer correctDesializer = serializers.Single(s => s.CanDeserialize(value, tempRow, tempColumn));

                    object propertyValue = correctDesializer.Deserialize(value, ref row, ref column, moduleDictionary);

                    instance.Add(propertyValue as Module);

                    row++;
                    column = 0;
                }

                column = 0;

                return instance;
            }
            else
            {
                row++;
                column = 0;


                var instance = new ObservableCollection<Vehicle>();

                while (value[row][column] != ']')
                {

                    int tempRow = row;
                    int tempColumn = column;
                    EntitySerializer correctDesializer = serializers.Single(s => s.CanDeserialize(value, tempRow, tempColumn));

                    object propertyValue = correctDesializer.Deserialize(value, ref row, ref column, moduleDictionary);

                    instance.Add(propertyValue as Vehicle);
                    //properties.FirstOrDefault(p => p.Name == propertyName)?.SetValue(instance, propertyValue);

                    row++;
                    column = 0;
                }

                column = 0;

                return instance;
            }
        }

        public override string Serialize(object obj, Dictionary<int, object> moduleDictionary)
        {
            string output = "[\n";


            ICollection collection = obj as ICollection;

            int i = 0;

            foreach (var item in collection)
            {
                EntitySerializer serializer = serializers.Single(s => s.CanSerialize(item));

                output += serializer.Serialize(item, moduleDictionary);

                if (i < collection.Count - 1)
                {
                    output += "\n";
                }

                i++;
            }

            return output + "\n]";
        }
    }
}
