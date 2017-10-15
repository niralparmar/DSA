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

            //List<int> treeData = new List<int>() { 12, 8, 14, 5, 9, 13, 16, 3, 6, 10 };
            List<int> treeData = new List<int>() { 15,10,20,8,12,17,25,6,11,16,27 };
            DS.NTree tree = new DS.NTree();
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

            Console.WriteLine("\nSize : " + tree.Size(r));

            Console.WriteLine("\nMaxDepth : " + tree.MaxDepth(r));

            Console.WriteLine("\nMinValue : " + tree.MinValue(r));

            Console.WriteLine("\nMaxValue : " + tree.MaxValue(r));

            Console.WriteLine("\nHasPathSum : " + tree.HasPathSum(r, 28));

            Console.WriteLine("\nPaths : \n");
            tree.PrintPaths(r);

            if (tree.Find(r, 8) != null) Console.WriteLine("\nFound node");
            else Console.WriteLine("\nNot Found node");

            if (tree.FindParent(r, 18) != null) Console.WriteLine("\nFound Parent node");
            else Console.WriteLine("\nNot Found parent");

            var n = tree.GetSuccessort(r, 8);
            if (n != null) Console.Write($"\nInOrder Successor:{n.Value}");
            else Console.Write("\nInOrder Successor Not Found");

            //Test delete all test , or it will messed up other test data
            Console.WriteLine("\nBefore delete");
            tree.InOrder(r);
            tree.Remove(r, 12);
            Console.WriteLine("\nAfter delete");
            tree.InOrder(r);
            


            Console.ReadLine();
        }
    }
}
