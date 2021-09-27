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
            list.Insert("Первый");
            list.Insert("Второй");
            list.Insert("Третий");
            list.Insert("Четвертый");
            list.Insert("Пятый");
            list.Insert("Шестой");
            list.Insert("Седьмой");
            list.Insert("Восьмой");
            list.Insert("Девятый");
            list.Insert("Десятый");
            list.Random();

            Serializer listSerializer = new Serializer();

            //Stream fStream = new FileStream("MyTest.xml",
            //    FileMode.Create, FileAccess.Write, FileShare.None);
            //listSerializer.Serialize(list.GetHead(), fStream);

            List newList = new List();
            Stream fStream = File.OpenRead("MyTest.xml");
            newList.SetHead(listSerializer.Deserialize(fStream));
            Console.WriteLine("Complete");
            Console.Read();
        }
    }
}
