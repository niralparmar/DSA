namespace DataStructure
{
    using System;
    using System.Collections.Generic;

    public class Stack<T>
    {
        private LinkedList<T> stack = new LinkedList<T>();
        public void Push(T value)
        {
            stack.AddLast(value);
        }

        public bool IsEmpty()
        {
            return stack.Count == 0;
        }

        public int Size()
        {
            return stack.Count;
        }
        public T Peek()
        {
            if (stack.Count == 0)
            {
                throw new InvalidOperationException("The Stack is empty");
            }
            return stack.Last.Value;
        }

        public T Pop()
        {
            if (stack.Count == 0)
            {
                throw new InvalidOperationException("The Stack is empty");
            }
            var value = stack.Last.Value;
            stack.RemoveLast();
            return value;
        }
        public void Clear()
        {
            stack.Clear();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return stack.GetEnumerator();
        }
        public void Print()
        {
            IEnumerator<T> e = GetEnumerator();
            while(e.MoveNext())
            {
                Console.Write(e.Current + " ");
            }
            Console.WriteLine();
        }
    }
}
