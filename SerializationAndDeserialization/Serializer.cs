using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;


namespace SerializationAndDeserialization
{
    class Serializer : IListSerializer
    {
        public void Add(ListNode head, ListNode tail, string data)
        {
            ListNode node = new ListNode() { Data = data };

            if (head == null)
            {
                head = node;
            }
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
        }
        public ListNode Deserialaze(Stream s)
        {
            ListNode head = null;
            ListNode tail = null;
            ListNode node = new ListNode();

            var reader = XmlReader.Create(s);
            reader.ReadToFollowing("string");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(String)); 

            while (reader.Read())
            {
            }

            return head;
        }

        public void Serialize(ListNode head, Stream s)
        {
            string probel = "===";

            ListNode node = head;
            string ToString(ListNode node)
            {
                return node.Data;
            }

            var settings = new XmlWriterSettings {};
            var writer = XmlWriter.Create(s, settings);

            writer.WriteStartElement("root");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(String));
            XmlSerializer xmlSerializerNode = new XmlSerializer(typeof(ListNode));

            while (node != null)
            {
                xmlSerializer.Serialize(writer, node.Data);
                if (node.Previous != null)
                {
                    xmlSerializer.Serialize(writer, ToString(node.Previous));
                }
                else
                {
                    xmlSerializer.Serialize(writer, "null");
                }         
                if (node.Next != null)
                {
                    xmlSerializer.Serialize(writer, ToString(node.Next));
                }
                else
                {
                    xmlSerializer.Serialize(writer, "null");
                }
                xmlSerializer.Serialize(writer, ToString(node.Random));
                xmlSerializer.Serialize(writer, probel);

                node = node.Next;
            }

            writer.Close();
        }
    }
}
