namespace Algorithms
{
    using DataStructure;
    using System.Collections.Generic;

    public class LinkedList
    {
        private static int GetLinkedListLength(LinkedListNode a)
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
        public static LinkedListNode GetIntersectionNode(LinkedListNode a, LinkedListNode b)
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
        public static void RemoveDuplicate(LinkedListNode a)
        {
            HashSet<int> set = new HashSet<int>();
            LinkedListNode preious = null;

            while (a != null)
            {
                if (set.Contains(a.Value))
                {
                    preious.Next = a.Next;
                }
                else
                {
                    set.Add(a.Value);
                    preious = a;
                }
                a = a.Next;
            }
        }
        public static void RemoveDuplicateV1(LinkedListNode a)
        {
            LinkedListNode current = a;

            while (current.Next != null)
            {
                if (current.Value == current.Next.Value)
                {
                    current.Next = current.Next.Next;
                }
                else
                {
                    current = current.Next;
                }
            }
        }
        public static LinkedListNode SwapAdjecentNodes(LinkedListNode a)
        {
            LinkedListNode current = a;
            while (current != null && current.Next != null)
            {
                int tmp = current.Next.Value;
                current.Next.Value = current.Value;
                current.Value = tmp;

                current = current.Next.Next;
            }
            return a;
        }
        public static void FrontBackSplit(DataStructure.LinkedList source, DataStructure.LinkedList front, DataStructure.LinkedList back)
        {
            int length = GetLinkedListLength(source.Head);
            DataStructure.LinkedListNode node = source.Head;

            for (int i = 0; i < length; i++)
            {
                if (i < length / 2)
                {
                    front.Add(node.Value);
                }
                else
                {
                    back.Add(node.Value);
                }

                node = node.Next;
            }
        }
        public static DataStructure.LinkedList ShuffleMerge(DataStructure.LinkedList a, DataStructure.LinkedList b)
        {
            DataStructure.LinkedList result = new DataStructure.LinkedList();
            LinkedListNode aNode = a.Head;
            LinkedListNode bNode = b.Head;
            while (aNode != null && bNode != null)
            {
                if (aNode != null)
                {
                    result.Add(aNode.Value);
                    aNode = aNode.Next;
                }
                if (bNode != null)
                {
                    result.Add(bNode.Value);
                    bNode = bNode.Next;
                }
            }

            while (aNode != null)
            {
                result.Add(aNode.Value);
                aNode = aNode.Next;
            }
            while (bNode != null)
            {
                result.Add(bNode.Value);
                bNode = bNode.Next;
            }
            return result;
        }

        public static DataStructure.LinkedList SortedMerge(DataStructure.LinkedList a, DataStructure.LinkedList b)
        {
            DataStructure.LinkedList result = new DataStructure.LinkedList();
            LinkedListNode aNode = a.Head;
            LinkedListNode bNode = b.Head;
            while (aNode != null && bNode != null)
            {
                if (aNode != null & bNode != null)
                {
                    if (aNode.Value < bNode.Value)
                    {
                        result.Add(aNode.Value);
                        aNode = aNode.Next;
                    }
                    else
                    {
                        result.Add(bNode.Value);
                        bNode = bNode.Next;
                    }
                }
            }

            while (aNode != null)
            {
                result.Add(aNode.Value);
                aNode = aNode.Next;
            }
            while (bNode != null)
            {
                result.Add(bNode.Value);
                bNode = bNode.Next;
            }
            return result;
        }

        public static DataStructure.LinkedList SortedIntersect(DataStructure.LinkedList a, DataStructure.LinkedList b)
        {
            DataStructure.LinkedList result = new DataStructure.LinkedList();
            LinkedListNode aNode = a.Head;
            LinkedListNode bNode = b.Head;
            while (aNode != null && bNode != null)
            {
                if (aNode.Value == bNode.Value)
                {
                    result.Add(aNode.Value);
                    aNode = aNode.Next;
                    bNode = bNode.Next;
                }
                else if (aNode.Value < bNode.Value) aNode = aNode.Next;
                else bNode = bNode.Next;
            }
            return result;

        }

        public static LinkedListNode ReverseKNode(LinkedListNode a, int k)
        {
            LinkedListNode current = a;
            LinkedListNode previous = null;
            LinkedListNode next = null;
            int count = 0;
            while (current != null && count < k)
            {
                next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
                count++;
            }
            if (next != null)
                a.Next = ReverseKNode(next, k);

            // prev is now head of input list
            return previous;

        }
    }
}
