using System.IO;
using System.Threading.Tasks;

namespace SerializationAndDeserialization
{
    interface IListSerializer
    {
        Task Serialize(ListNode head, Stream s);

        Task<ListNode> Deserialaze(Stream s);

        Task<ListNode> DeepCopy(ListNode head);

    }
}
