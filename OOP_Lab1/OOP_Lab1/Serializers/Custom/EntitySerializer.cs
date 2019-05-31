using System;
using System.Collections.Generic;

namespace OOP_Lab1.Serializers
{
    public abstract class EntitySerializer
    {
        public abstract bool CanSerialize(object obj);

        public abstract string Serialize(object obj, Dictionary<int, object> moduleDictionary);

        public abstract bool CanDeserialize(List<string> value, int pos, int column);

        public abstract object Deserialize(List<string> value, ref int row, ref int column, Dictionary<int, object> moduleDictionary);
    }
}
