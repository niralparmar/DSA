namespace DataStructure
{
    using System;
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
        /// Gets the node at the head of the <see cref="LinkedList"/>.
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

        /// <summary>
        /// Gets the number of nodes<see cref="LinkedList"/>.
        /// </summary>
        public int Count
        {
            get { return mCount; }
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
        /// Adds a node to the tail of the <see cref="LinkedList"/>.
        /// </summary>
        /// <param name="item">Item to add to the <see cref="LinkedList"/>.</param>
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
        /// Adds a node to the head of the <see cref="LinkedList"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(1) operation, the <see cref="Head"/> node is always known.
        /// </remarks>
        /// <param name="item">Item to add to the <see cref="LinkedList"/>.</param>
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
        /// <summary>
        /// Adds a node after the specified <see cref="LinkedList"/> with the value of item.
        /// </summary>
        /// <remarks>
        /// This method is an O(1) operation, the node to add after and new nodes links are updated without having to perform any
        /// traversal of the linked list.
        /// </remarks>
        /// <param name="node">Node in <see cref="LinkedList"/> to add node after.</param>
        /// <param name="item">Item to add to <see cref="LinkedList"/>.</param>
        /// <exception cref="ArgumentNullException"><strong>node</strong> is <strong>null</strong>.</exception>
        public void AddAfter(LinkedListNode node, int item)
        {


            LinkedListNode n = new LinkedListNode(item);

            // check to see if node is the only node in the linked list
            if (node == mHead && node == mTail)
            {
                mHead.Next = n;
                mTail = n;
            }
            else if (node == mTail)
            {
                mTail.Next = n;
                mTail = n;
            }
            else
            {
                n.Next = node.Next;
                node.Next = n;
            }

            mCount++;
        }
        /// <summary>
        /// Adds a <see cref="LinkedListNode"/> before the specified <see cref="LinkedListNode"/> with the specified value.
        /// </summary>
        /// <remarks>
        /// This method's best case is an O(1) operation where the node to be added before is the <see cref="Head"/> node, otherwise the
        /// method is an O(n) operation where n is the number of nodes to be traversed in order to find the node before the node to add before.
        /// </remarks>
        /// <param name="node">Node in the <see cref="LinkedListNode"/> to add node before.</param>
        /// <param name="item">Item to add to the <see cref="LinkedListNode"/>.</param>
        /// <exception cref="ArgumentNullException"><strong>node</strong> is <strong>null</strong>.</exception>
        public void AddBefore(LinkedListNode node, int item)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }

            LinkedListNode n = new LinkedListNode(item);
            if (node == mHead)
            {
                n.Next = mHead;
                mHead = n;
            }
            else
            {
                LinkedListNode curr = mHead;
                while (curr != null)
                {
                    if (curr.Next == node)
                    {
                        n.Next = node;
                        curr.Next = n;
                        break;
                    }

                    curr = curr.Next;
                }
            }

            mCount++;
        }
        /// <summary>
        /// Removes the last node from the <see cref="LinkedListNode"/>.
        /// </summary>
        /// <remarks>
        /// This method's best case is an O(1) operation when the last node to remove is both the head and tail, i.e. there is only one node
        /// in the linked list, otherwise the method is an O(n) operation where n nodes have to be traversed in order to locate the node that
        /// precedes the last node.
        /// </remarks>
        /// <returns>True the last node was removed; otherwise false.</returns>
        public bool RemoveLast()
        {
            if (IsEmpty())
            {
                return false;
            }

            if (mCount == 1)
            {
                mHead = null;
                mTail = null;
            }
            else
            {
                LinkedListNode n = mHead;
                while (n != null)
                {
                    if (n.Next == mTail)
                    {
                        mTail = n;
                        mTail.Next = null;
                        break;
                    }

                    n = n.Next;
                }
            }

            mCount--;
            return true;
        }
        /// <summary>
        /// Removes the first node from the <see cref="LinkedListNode"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(1) operation, the <see cref="Head"/> is always known.
        /// </remarks>
        /// <returns>True if the first node was removed; otherwise false.</returns>
        /// <exception cref="InvalidOperationException"><see cref="LinkedListNode"/> contains <strong>0</strong> items.</exception>
        public bool RemoveFirst()
        {
            if (IsEmpty())
            {
                return false;
            }

            if (mCount == 1)
            {
                mHead = null;
                mTail = null;
            }
            else
            {
                mHead = mHead.Next;
            }

            mCount--;
            return true;
        }
        public bool Remove(int item)
        {
            if (IsEmpty())
            {
                return false;
            }

            LinkedListNode n = mHead;
            if (n.Value == item)
            {
                // we have one of two cases, either the linked list contains only one node (case 1); or we are removing the head node (case 2)
                // case 1
                if (n == mHead && n == mTail)
                {
                    mHead = null;
                    mTail = null;
                }
                else
                {
                    // case 2
                    mHead = mHead.Next;
                }

                mCount--;
                return true;
            }

            // case 3: the node to remove is anything but the head node
            while (n.Next != null && n.Next.Value != item)
            {
                n = n.Next;
            }

            if (n.Next != null && n.Next.Value == item)
            {
                // case 3.1: the node to remove is the tail
                if (n.Next == mTail)
                {
                    mTail = n;
                }

                // case 3.2: the node to remove is somewhere in the linked list, just not the tail node
                n.Next = n.Next.Next;
                mCount--;
                return true;
            }

            return false; // case 4: item to remove was not in the linked list
        }
        /// <summary>
        /// Determines whether a value is in the <see cref="LinkedList"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(n) operation where n is the number of nodes in the linked list.
        /// </remarks>
        /// <param name="item">Value to search for.</param>
        /// <returns>True if the value is in the <see cref="LinkedList"/>; false otherwise.</returns>
        public bool Contains(int item)
        {
            LinkedListNode current = mHead;
            while (current != null)
            {
                if (current.Value == item)
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }


    }
}
