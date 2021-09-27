using System;
using System.IO;
using System.Threading.Tasks;

namespace SerializationAndDeserialization
{
    class Program
    {
        static void Main(string[] args)
        {
            List list = new List();
            list.Insert("First");
            list.Insert("Second");
            list.Insert("Third");
            list.Insert("Fourth");
            list.Insert("Fifth");
            list.Random();

            Serializer listSerializer = new Serializer();

            //Stream fStream = new FileStream("MyTest.xml",
            //    FileMode.Create, FileAccess.Write, FileShare.None);
            //listSerializer.Serialize(ref head, fStream);

            List newList = new List();
            Stream fStream = File.OpenRead("MyTest.xml");
            newList.SetHead(listSerializer.Deserialize(fStream));
            Console.WriteLine("Complete");
            Console.Read();
        }
    }
}
