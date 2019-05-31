using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab1.Serializers.Custom
{
    public class ClassSerializer : EntitySerializer
    {
        private List<EntitySerializer> serializers;

        public ClassSerializer()
        {
            this.serializers = new List<EntitySerializer>();

        }

        public override bool CanDeserialize(List<string> value, int row, int column)
        {
            return value[row][column] == '<';
        }

        public void AddSerializer(List<EntitySerializer> serializers)
        {
            this.serializers.AddRange(serializers);
        }

        public override bool CanSerialize(object obj)
        {
            return obj.GetType().IsClass && !(obj.GetType().GetInterfaces().Any(t => t == typeof(ICollection))) && obj.GetType() != typeof(string) && (obj != null);
        }


        public override object Deserialize(List<string> value, ref int row, ref int column, Dictionary<int, object> moduleDictionary)
        {
            row++;
            column = 0;

            var objectID = int.Parse(value[row].Substring(value[row].IndexOf("%ID=") + 4));
            row++;
            column = 0;

            var objectType = Type.GetType(value[row].Substring(value[row].IndexOf("%Type=") + 6));

            var instance = Activator.CreateInstance(objectType);
            row++;
            column = 0;

            var properties = objectType.GetProperties().Where(p => p.SetMethod != null).ToList();

            while (value[row][column] != '>')
            {
                string[] rowValues = value[row].Split('=');

                string propertyName = rowValues[0];
                int propertyValueIndex = value[row].IndexOf('=') + 1;

                column = propertyValueIndex;
                int tempRow = row;
                int tempColumn = column;
                EntitySerializer correctDesializer = serializers.Single(s => s.CanDeserialize(value, tempRow, tempColumn));

                object propertyValue = correctDesializer.Deserialize(value, ref row, ref column, moduleDictionary);

                //
                
                //

                properties.FirstOrDefault(p => p.Name == propertyName)?.SetValue(instance, propertyValue);

                row++;
                column = 0;
            }

            //row++;
            column = 0;

            if (!moduleDictionary.Keys.Contains(objectID))
            {
                moduleDictionary.Add(objectID, instance);
            }
            else
            {
                instance = moduleDictionary[objectID];
            }
            return instance;
        }



        public override string Serialize(object obj, Dictionary<int, object> moduleDictionary)
        {
            string output = "";
            PropertyInfo[] properties = obj.GetType().GetProperties();
            output += "<\n";


            if (moduleDictionary.Values.Contains(obj))
            {
                foreach (var item in moduleDictionary)
                {
                    if (item.Value == obj)
                    {
                        output += $"%ID={item.Key}\n";
                    }
                }
            }
            else {
                moduleDictionary.Add(moduleDictionary.Count, obj);
                output += $"%ID={moduleDictionary.Count - 1}\n";
            }

            output += $"%Type={obj.GetType().FullName}\n";

            for (int i = 0; i < properties.Count(); i++)
            {
                var prop = properties[i];

                object value = prop.GetValue(obj);

                EntitySerializer serializer = serializers.Single(s => s.CanSerialize(value));

                output += prop.Name + "=" + serializer.Serialize(value, moduleDictionary);
                
                if (i != properties.Count() - 1)
                {
                    output += "\n";
                }
            }

            output += "\n>";

            return output;
        }
    }
}
