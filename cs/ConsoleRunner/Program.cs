namespace ConsoleRunner
{
    using System;
    using DataStructure;

    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            PrintList(list.Head);
            Console.ReadLine();
        }
        static void PrintList(LinkedListNode head)
        {
            LinkedListNode temp = head;
            while (temp != null)
            {
                Console.Write(temp.Value);
                if(temp.Next != null){
                    Console.Write("->");
                }
                temp = temp.Next;
            }
        }
    }
}
