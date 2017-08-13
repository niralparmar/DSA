using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class MyQueue<T>
    {
        Stack<T> stackOld;
        Stack<T> stackNew;
        public MyQueue()
        {
            stackNew = new Stack<T>();
            stackOld = new Stack<T>();
        }
        public int Size()
        {
            return stackOld.Size() + stackNew.Size();
        }
        public void Enqueue(T item)
        {
            stackNew.Push(item);
        }
        public T Peek()
        {
            ShiftStacks();
            return stackOld.Peek();
        }
        public T Dequeue()
        {
            ShiftStacks();
            return stackOld.Pop();
        }
        private void ShiftStacks()
        {
            if (!stackOld.IsEmpty())
            {
                return;
            }
            while (!stackNew.IsEmpty())
            {
                stackOld.Push(stackNew.Pop());
            }
        }
    }
}
