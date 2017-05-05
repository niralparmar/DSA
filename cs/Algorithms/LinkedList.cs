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
        /// <summary>
        /// https://www.interviewbit.com/problems/intersection-of-linked-lists/
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Reverse a linked list. Do it in-place and in one-pass.
        ///For example:
        ///Given 1->2->3->4->5->NULL,
        ///return 5->4->3->2->1->NULL.
        ///refer : https://www.interviewbit.com/problems/reverse-linked-list/
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
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
        /// <summary>
        /// https://www.interviewbit.com/problems/palindrome-list/
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool IsPalindrom(LinkedListNode a)
        {
            if (a == null || a.Next == null)
                return true;

            //find list center
            LinkedListNode fast = a;
            LinkedListNode slow = a;

            while (fast.Next != null && fast.Next.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;
            }

            LinkedListNode secondHead = slow.Next;
            slow.Next = null;

            //reverse second part of the list
            LinkedListNode p1 = secondHead;
            LinkedListNode p2 = p1.Next;

            while (p1 != null && p2 != null)
            {
                LinkedListNode temp = p2.Next;
                p2.Next = p1;
                p1 = p2;
                p2 = temp;
            }

            secondHead.Next = null;

            //compare two sublists now
            LinkedListNode p = (p2 == null ? p1 : p2);
            LinkedListNode q = a;
            while (p != null)
            {
                if (p.Value != q.Value)
                    return false;

                p = p.Next;
                q = q.Next;

            }

            return true;
        }
        public static LinkedListNode RemoveDuplicate(LinkedListNode a)
        {

            return new LinkedListNode(3);
        }
    }
}
