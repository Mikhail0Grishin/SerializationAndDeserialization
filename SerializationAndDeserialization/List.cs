using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationAndDeserialization
{
    class List
    {
        private int count = 0;
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
            ListNode node = new ListNode { Data = data };

            if (Head == null)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
            }
            Tail = node;
        }
        public void Random()
        {
            ListNode node = Head;
            while (node != null)
            {
                node.Random = NodeRandom();
                node = node.Next;
            }
        }

        public ListNode NodeRandom() 
        {
            Random random = new Random();
            ListNode randomNode = Head;

            int randomDigital = random.Next(1, count);
            int randomDigitalSecond = random.Next(1, count);

            if (randomDigital > randomDigitalSecond)
            {
                while (randomDigital >= randomDigitalSecond && randomNode.Next != null)
                {
                    randomNode = randomNode.Next;
                    randomDigitalSecond++;
                }

            }
            else
            {
                while (randomDigital <= randomDigitalSecond && randomNode.Next != null)
                {
                    randomNode = randomNode.Next;
                    randomDigital++;
                }
            }    
            return randomNode;
        }

    }
}
