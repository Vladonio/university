using System.IO;

namespace OOP_Lab1.Serializers
{
    interface ISerializers
    {
        string Format { get; }

        void SerializeObject(object obj, string fileName);

        object DeSeriazlixeObject(FileStream file);
    }
}
