//#define TREE
//#define SORTING
//#define BIT
#define LINKEDLIST
namespace ConsoleRunner
{
    using System;
    using DS = DataStructure;
    using Algo = Algorithms;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            #region PreviousExecution
            //Console.WriteLine(Stack.SimplifyPath("/a/./b/../../c/"));
            //Console.WriteLine(Stack.SimplifyPath("/a/././../b/../../c/"));
            //Console.WriteLine(Stack.IsDupBraces("((a+(a + b)))"));
            //int[,] arr = new int[6, 6] {
            //{ 1, 1, 1 ,0, 0, 0 },
            //{ 0, 1, 0, 0, 0, 0 },
            //{ 1, 1, 1, 0, 0, 0 },
            //{ 0, 0, 2, 4, 4, 0 },
            //{ 0, 0, 0, 2, 0, 0 },
            //{ 0, 0, 1, 2, 4, 0 },
            //};

            //Console.WriteLine(Arrays.HourGlassSum(arr));
            //Console.WriteLine(Stack.RainWaterTrapped(new List<int>() { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }));
            //MyQueue<int> queue = new MyQueue<int>();
            //queue.Enqueue(1);
            //queue.Enqueue(2);
            //queue.Enqueue(3);
            //Console.WriteLine(queue.Peek());
            //queue.Dequeue();
            //Stack<int> s = new Stack<int>();
            //s.Push(3);
            //s.Push(12);
            //s.Push(5);
            //s.Push(1);
            //s.Push(10);
            //s = Algo.Stack.Sort(s);
            //while(s.Count != 0)
            //{
            //    Console.Write(s.Pop() + " ");
            //}
            //int n = int.Parse(Console.ReadLine());
            //Stack<int> maxValues = new Stack<int>();
            //while (n > 0)
            //{
            //    int choice = int.Parse(Console.ReadLine());
            //    switch (choice)
            //    {
            //        case 1:
            //            int val = int.Parse(Console.ReadLine());
            //            if (maxValues.Count != 0)
            //            {
            //                val = val > maxValues.Peek() ? val : maxValues.Peek();
            //            }
            //            maxValues.Push(val);
            //            break;
            //        case 2:
            //            maxValues.Pop();
            //            break;
            //        case 3:
            //            Console.Write(maxValues.Peek());
            //            break;
            //        default:
            //            break;
            //    }
            //    n--;
            //}
            //string s = Console.ReadLine();
            //Algo.Stack.isBalancedBracket(s);
            //Algo.Arrays.coverPoints(new List<int>() { 0,1,1},new List<int>() {0,1,2 }); 
            #endregion

#if (LINKEDLIST)
            #region LinkedListTest
            DS.LinkedList linkedList = GetLinkedList(new int[] { 1, 2, 3, 4, 5 });
            DS.LinkedList a = new DS.LinkedList();
            DS.LinkedList b = new DS.LinkedList();
            Algo.LinkedList.FrontBackSplit(linkedList, a, b);
            Console.WriteLine(linkedList.ToString());
            Console.WriteLine(a.ToString());
            Console.WriteLine(b.ToString());
            DS.LinkedList removeDups = GetLinkedList(new int[] { 1, 2, 2,2,4,4,5,6,7,7,7});
            Algo.LinkedList.RemoveDuplicateV1(removeDups.Head);
            Console.WriteLine(removeDups.ToString());

            DS.LinkedList shuffleMerged = Algo.LinkedList.ShuffleMerge(GetLinkedList(new int[] { 1, 3, 5, 7 }), GetLinkedList(new int[] { 2, 4, 6 }));
            Console.WriteLine(shuffleMerged.ToString());
            DS.LinkedList sortedMerge = Algo.LinkedList.SortedMerge(GetLinkedList(new int[] {  3, 5, 7 }), GetLinkedList(new int[] {1, 2, 4, 6 }));
            Console.WriteLine(sortedMerge.ToString());
            DS.LinkedList sortedIntersect = Algo.LinkedList.SortedIntersect(GetLinkedList(new int[] { 1,4,7,10}), GetLinkedList(new int[] { 2,4,6,8,10 }));
            Console.WriteLine(sortedIntersect.ToString());
            DS.LinkedList reversList = GetLinkedList(new int[] { 1, 4, 7, 10 });
            reversList.Head = Algo.LinkedList.ReverseLinkedList(reversList.Head);
            Console.WriteLine(reversList.ToString());

            DS.LinkedList swapList = GetLinkedList(new int[] { 1, 4, 7, 10 });
            Algo.LinkedList.SwapAdjecentNodes(swapList.Head);
            Console.WriteLine(swapList.ToString());

            DS.LinkedList reversKList = GetLinkedList(new int[] { 1, 4, 7, 10 ,5,17,9});
            reversKList.Head =  Algo.LinkedList.ReverseKNode(reversKList.Head,3);
            Console.WriteLine(reversKList.ToString());
            #endregion
#endif

#if (TREE)
            #region Tree Test
            //List<int> treeData = new List<int>() { 2,1,3};
            List<int> treeData = new List<int>() { 12,8,5,9,10,14,13,16,3,6 };
            //List<int> treeData = new List<int>() { 5, 1, 2, 8, 2, 7, 5, 2, 1, 6, 4, 9, 3 };
            //List<int> treeData = new List<int>() { 1000,200 };
            //List<int> levelOrderTreeData = new List<int>() { 1, 2, 3, -1, -1, 4, -1, 1, 5 };
            DS.NTree tree = new DS.NTree();
            //tree.Root = tree.CreateTreeFromLevelOrder(levelOrderTreeData);
            foreach (var data in treeData)
            {
                tree.Root = tree.Insert(tree.Root, data);
            }
            //DS.NTree tree = new DS.NTree();
            //foreach (var data in treeData)
            //{
            //    tree.Root = tree.Insert_Iterative(tree.Root, data);
            //}
            //tree1.InOrder(tree1.Root);
            DS.TreeNode r = tree.Root;
            Console.WriteLine("InOrder");
            tree.InOrder(r);

            Console.WriteLine("\nInOrder(Iterative)");
            tree.InOrderIterative(r);

            Console.WriteLine("\nPreOrder");
            tree.PreOrder(r);

            Console.WriteLine("\nPreOrder(Iterative)");
            tree.PreOrderIterative(r);

            Console.WriteLine("\nPostOrder");
            tree.POSTOrder(r);

            Console.WriteLine("\nPostOrder(Iterative)");
            tree.POSTOrderIterative(r);

            Console.WriteLine("\nBreadthFirst");
            tree.BreadthFirst(r);

            Console.WriteLine("\nReversBreadthFirst");
            tree.ReversBreadthFirst(r);

            Console.WriteLine("\nReversBreadthFirstIterative");
            tree.ReversBreadthFirstIterative(r);

            Console.WriteLine("\nSize : " + tree.Size(r));

            Console.WriteLine("\nMaxDepth : " + tree.MaxDepth(r));

            Console.WriteLine("\nLevel : " + tree.FindLevel(r, 3));

            Console.WriteLine("\nMinValue : " + tree.MinValue(r));

            Console.WriteLine("\nMaxValue : " + tree.MaxValue(r));

            Console.WriteLine("\nHasPathSum : " + tree.HasPathSum(r, 28));
            //Console.WriteLine("\nHasPathSum : " + tree.HasPathSum(r, 1000));

            Console.WriteLine("\nPaths : \n");
            tree.PrintPaths(r);

            if (tree.Find(r, 8) != null) Console.WriteLine("\nFound node");
            else Console.WriteLine("\nNot Found node");

            if (tree.FindParent(r, 18) != null) Console.WriteLine("\nFound Parent node");
            else Console.WriteLine("\nNot Found parent");

            var n = tree.GetSuccessor(r, 22);
            if (n != null) Console.Write($"\nInOrder Successor:{n.Value}");
            else Console.Write("\nInOrder Successor Not Found");

            Console.WriteLine("\nDistance : " + tree.Distance(r,6,10));

            Console.WriteLine("\nSumNumbers : " + tree.SumNumbers(r));

            //Test delete all test , or it will messed up other test data
            Console.WriteLine("\nBefore delete");
            tree.InOrder(r);
            tree.Remove(r, 12);
            Console.WriteLine("\nAfter delete");
            tree.InOrder(r);
            #endregion
#endif
#if (SORTING)
            #region Sorting Test
            int[] array = new int[] { 5, 3, 1, 10, 9, 2, 8, 20, -1 };

            int[] a1 = (int[])array.Clone();
            int[] a2 = (int[])array.Clone();
            int[] a3 = (int[])array.Clone();
            Console.Write("Before Sort:");
            PrintArray(array);
            Algo.Sorting.Bubble(a1);
            Console.Write("\nAfter Bubble Sort: ");
            PrintArray(a1);
            Algo.Sorting.MergeSort(a2, 0, a2.Length);
            Console.Write("\nAfter Merge Sort: ");
            PrintArray(a2);
            Console.Write("\nAfter Quick Sort: ");
            Algo.Sorting.Quick_sort(a3, 0, a3.Length - 1);
            PrintArray(a3);
            #endregion
#endif
#if (BIT)
            updateBitMask(9, 2, 2);
            UpdateBit();
#endif

            Console.ReadLine();
        }
        public static DS.LinkedList GetLinkedList(int[] data)
        {
            DS.LinkedList list = new DS.LinkedList();
            for (int i = 0; i < data.Length; i++)
            {
                list.Add(data[i]);
            }
            return list;
        }
        static void updateBitMask(int num, int i, int v)
        {
            int mask = ~(1 << i);
            int n = num & mask;
            int n1 = v << i;
            int t = n | n1;

        }
        static void UpdateBit()
        {
            int n = Convert.ToInt16("10000000", 2);
            int m = Convert.ToInt16("10011", 2);
            int i = 2;
            int j = 4;

            int allOnes = ~0;

            int left = allOnes << (j + 1);

            int right = ((1 << i) - 1);

            int mask = left | right;

            int n_cleared = n & mask;

            int m_shifted = m << i;

            Console.Write(n_cleared | m_shifted);


        }
        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]},");
            }
        }
    }
}
