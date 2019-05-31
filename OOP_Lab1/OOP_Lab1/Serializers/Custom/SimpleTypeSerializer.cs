using System.Collections.Generic;
using System.Linq;

namespace OOP_Lab1.Serializers.Custom
{
    public class SimpleTypeSerializer : EntitySerializer
    {
        public override bool CanDeserialize(List<string> value, int row, int column)
        {
            string propertyValue = value[row].Substring(column);

            return (propertyValue.StartsWith("\"") && propertyValue.EndsWith("\"")) ||
                (propertyValue.All(c => char.IsDigit(c)));
        }

        public override bool CanSerialize(object obj)
        {
            return obj != null && obj.GetType() == typeof(int) || obj.GetType() == typeof(string);
        }

        public override object Deserialize(List<string> value, ref int row, ref int column, Dictionary<int, object> moduleDictionary)
        {
            string propertyValue = value[row].Substring(column);

            if (propertyValue.All(c => char.IsDigit(c)))
            {
                return int.Parse(propertyValue);
            }

            return propertyValue.Substring(1, propertyValue.Length - 2);
        }

        public override string Serialize(object obj, Dictionary<int, object> moduleDictionary)
        {
            if (obj.GetType() == typeof(string))
            {
                return '"' + $"{obj as string}" + '"';
            }

            return obj.ToString();
        }
    }
}
