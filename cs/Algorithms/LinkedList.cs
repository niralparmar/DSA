namespace Algorithms
{
    using DataStructure;

    public class LinkedList
    {
        private int GetLinkedListLength(LinkedListNode a)
        {
            int i = 0;
            while (a != null)
            {
                i++;
                a = a.Next;
            }
            return i;
        }
        public LinkedListNode GetIntersectionNode(LinkedListNode a, LinkedListNode b)
        {
            int n = GetLinkedListLength(a);
            int m = GetLinkedListLength(b);
            int d = m - n;
            if (n > m)
            {

                LinkedListNode tmpNode = a;
                a = b;
                b = tmpNode;
                d = n - m;
            }

            for (int i = 0; i < d; i++)
            {
                b = b.Next;
            }
            while (a != null && b != null)
            {
                if (a == b)
                {
                    return a;
                }
                a = a.Next;
                b = b.Next;
            }
            return null;
        }
        public static LinkedListNode ReverseLinkedList(LinkedListNode a)
        {
            LinkedListNode current, prev, next;
            current = a;
            prev = null;
            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            return prev;
        }
    }
}
