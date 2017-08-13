namespace ConsoleRunner
{
    using System;
    using DataStructure;
    using Algorithms;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
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
            MyQueue<int> queue = new MyQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            Console.WriteLine(queue.Peek());
            queue.Dequeue();
            Console.ReadLine();
        }

    }
}
