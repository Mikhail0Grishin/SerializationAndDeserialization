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

            Serializer serializer = new Serializer();
            //Stream fStream = new FileStream("MyTest.xml",
            //    FileMode.Create, FileAccess.Write, FileShare.None);

            //serializer.Serialize(list.GetHead(), fStream);


            List deserializedList = new List();
            Stream fStream = File.OpenRead("MyTest.xml");
            deserializedList.SetHead(serializer.Deserialaze(fStream));
            Console.WriteLine("Complete");
            Console.Read();
        }
    }
}
