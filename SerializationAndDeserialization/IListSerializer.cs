using System.IO;
using System.Threading.Tasks;

namespace SerializationAndDeserialization
{
    interface IListSerializer
    {
        void Add(ListNode head, ListNode tail, string data);
        void Serialize(ListNode head, Stream s);

        ListNode Deserialaze(Stream s);
    }
}
