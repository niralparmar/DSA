namespace Algorithms
{
    using DS= DataStructure;
    using System;
    using System.Collections.Generic;

    public class Stack
    {
        public static string SimplifyPath(string a)
        {
            char[] delimiterChars = { '/' };
            var tokens = a.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            Stack<string> stack = new Stack<string>();

            foreach (var token in tokens)
            {
                if (token == ".." && stack.Count != 0)
                {
                    stack.Pop();
                }
                else if (token != "." && token != "..")
                {
                    stack.Push(token);
                }
            }

            var array = stack.ToArray();
            for (int i = 0; i < array.Length / 2; i++)
            {
                string temp = array[i];
                array[i] = array[array.Length - 1 - i];
                array[array.Length - 1 - i] = temp;
            }

            return "/" + string.Join("/", array);

        }
        public static int IsDupBraces(string a)
        {
            Stack<char> stack = new Stack<char>();
            int count = 0;
            foreach (var item in a)
            {
                if (item != ')')
                {
                    stack.Push(item);
                }
                else
                {
                    count = 0;
                    while (stack.Count > 0 && stack.Peek() != '(')
                    {
                        stack.Pop();
                        count++;
                    }
                    stack.Pop();
                    if (count < 2)
                    {
                        return 1;
                    }
                }
            }
            return 0;
        }
        //Rain Water Trapped
        public static int RainWaterTrapped(List<int> A)
        {
            int result = 0;
            int[] left = new int[A.Count];
            int[] right = new int[A.Count];

            int max = A[0];//first element as max
            //scan from left
            for (int i = 0; i < A.Count; i++)
            {
                if(A[i] < max)
                {
                    left[i] = max;
                }
                else{
                    left[i] = A[i];
                    max = A[i];
                }
            }
            max = A[A.Count - 1];//last element as max
            right[A.Count - 1] = max;
            for (int i = A.Count -2; i > 0; i--)
            {
                if (A[i] < max)
                {
                    right[i] = max;
                }
                else
                {
                    right[i] = A[i];
                    max = A[i];
                }
            }
            for (int i = 0; i < A.Count; i++)
            {
                result += Math.Min(left[i], right[i]) - A[i];
            }
            return result;
        }

        //Use only One stack as buffer
        //if multiply stacks are allowed we could use merge sort/ quick sort 
        public static Stack<int> Sort(Stack<int> s)
        {
            Stack<int> r = new Stack<int>();
            while (s.Count != 0)
            {
                int temp = s.Pop();
                while(r.Count != 0 && r.Peek() > temp)
                {
                    s.Push(r.Pop());
                }
                r.Push(temp);
            }
            return r;
        }

        public static bool isBalancedBracket(string s)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char c in s)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c);
                }
                else
                {
                    char lastBrace = stack.Peek();
                    switch (c)
                    {
                        case ')':
                            if (lastBrace == '(')
                            {
                                stack.Pop();
                                break;
                            }
                            else return false;
                        case '}':
                            if (lastBrace == '{')
                            {
                                stack.Pop();
                                break;
                            }
                            else return false;
                        case ']':
                            if (lastBrace == '[')
                            {
                                stack.Pop();
                                break;
                            }
                            else return false;

                        default:
                            break;
                    }
                    
                }
            }
            if (stack.Count == 0) return true;
            return false;
        }
    }
}
