using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationAndDeserialization
{
    class List
    {
        private static int count = 0;
        private ListNode Head { get; set; }
        private ListNode Tail { get; set; }

        public ListNode GetHead()
        {
            return Head;
        }

        public void SetHead(ListNode head)
        {
            count++;
            Head = head;
            ListNode node = head;

            while (node.Next != null)
            {
                node = node.Next;
                count++;
            }

            Tail = node;
        }

        public void Insert(string data) 
        {
            count++;

            if (Head == null)
            {
                Head = new ListNode { Data = data };
                Tail = Head;
            }
            else
            {
                Tail.Next = new ListNode { Previous = null, Next = null, Random = null, Data = data };
                Tail = Tail.Next;
            }
        }
    }
}
