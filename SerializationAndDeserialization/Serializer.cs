using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace SerializationAndDeserialization
{
    public class Serializer
    {
        ListNode Head = new ListNode();
        ListNode Tail = new ListNode();

        int id = 0;
        public ListNode GetNode(int id)
        {
            for (ListNode curr = Head; curr.Next != null; curr = curr.Next)
            {
                if (this.id == id)
                    return curr;
                this.id++;
            }

            return Tail;
        }
        public void Serialize(ListNode head, Stream s)
        { 
            int index = 0;
            Dictionary<ListNode, int> dict = new Dictionary<ListNode, int>();
            for (ListNode currNode = Head; currNode != null; currNode = currNode.Next)
            {
                dict.Add(currNode, index);
                index++;
            }

            var settings = new XmlWriterSettings { Indent = true };
            var writer = XmlWriter.Create(s, settings);

            writer.WriteStartElement("root");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(string));
            XmlSerializer xmlSerializerInt = new XmlSerializer(typeof(int));

            for (ListNode currNode = Head; currNode != null; currNode = currNode.Next)
            {
                xmlSerializer.Serialize(writer, currNode.Data);
                xmlSerializer.Serialize(writer, dict[currNode.Random]);
            }

            writer.Close();
        }

        public ListNode Deserialize(Stream s)
        {
            int randomId;
            int count = 0;
            int index = 0;

            Dictionary<int, Tuple<string, int>> dict = new Dictionary<int, Tuple<string, int>>();       

            var reader = XmlReader.Create(s);
            reader.ReadToFollowing("string");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(string));

            String data = (String)xmlSerializer.Deserialize(reader);
            String randomid = (String)xmlSerializer.Deserialize(reader);

            randomId = Convert.ToInt32(randomid) - 1;

            while (data != null || randomid != null)
            {
                dict.Add(count, new Tuple<string, int>(data, randomId));
                data = (String)xmlSerializer.Deserialize(reader);
                randomid = (String)xmlSerializer.Deserialize(reader);
                randomId = Convert.ToInt32(randomid) - 1;
                count++;
            }

            ListNode currNode = Head;

            for (int i = 0; i < count; i++)
            {
                currNode.Data = dict.ElementAt(i).Value.Item1;
                currNode.Next = new ListNode();
                if (i != count - 1)
                {
                    currNode.Next.Previous = currNode;
                    currNode = currNode.Next;
                }
                else
                {
                    Tail = currNode;
                }
            }

            for (ListNode curr = Head; curr.Next != null; curr = curr.Next)
            {
                curr.Random = GetNode(dict.ElementAt(index).Value.Item2);
                index++;
            }

            return Head;
        }
    }
}
