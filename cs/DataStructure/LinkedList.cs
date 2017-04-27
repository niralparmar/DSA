using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class LinkedList
    {
        private LinkedListNode mHead;
        private LinkedListNode mTail;
        private int mCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="LinkedList"/> class.
        /// </summary>
        public LinkedList()
        {
            mHead = null;
            mTail = null;
            mCount = 0;
        }

        /// <summary>
        /// Gets the node at the head of the <see cref="LinkedList{T}"/>.
        /// </summary>
        public LinkedListNode Head
        {
            get { return mHead; }
        }

        /// <summary>
        /// Gets the node at the tail of the <see cref="LinkedList"/>.
        /// </summary>
        public LinkedListNode Tail
        {
            get { return mTail; }
        }

        /// Determines whether the <see cref="LinkedListNode"/> is empty.
        /// </summary>
        /// <remarks>
        /// This method is an O(1) operation.
        /// </remarks>
        /// <returns>True if the <see cref="LinkedListNode"/> is empty; false otherwise.</returns>
        public bool IsEmpty()
        {
            return mHead == null;
        }
        /// <summary>
        /// Adds a node to the tail of the <see cref="LinkedListNode"/>.
        /// </summary>
        /// <param name="item">Item to add to the <see cref="LinkedListNode"/>.</param>
        /// <remarks>
        /// This method is an O(1) operation, the <see cref="Tail"/> node is always known.
        /// </remarks>
        public void Add(int item)
        {
            LinkedListNode n = new LinkedListNode(item);
            if (IsEmpty())
            {
                mHead = n;
                mTail = n;
            }
            else
            {
                mTail.Next = n;
                mTail = n;
            }

            mCount++;
        }

        /// <summary>
        /// Adds a node to the head of the <see cref="LinkedListNode"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(1) operation, the <see cref="Head"/> node is always known.
        /// </remarks>
        /// <param name="item">Item to add to the <see cref="LinkedListNode"/>.</param>
        public void AddFirst(int item)
        {
            LinkedListNode n = new LinkedListNode(item);
            if (IsEmpty())
            {
                mHead = n;
                mTail = n;
            }
            else
            {
                n.Next = mHead;
                mHead = n;
            }

            mCount++;
        }
    }
}
