namespace DataStructure
{
    /// <summary>
    /// Doubly linked list.
    /// </summary>
    public class DoublyLinkedList
    {
        private DoublyLinkedListNode mHead;
        private DoublyLinkedListNode mTail;
        private int mCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="DoublyLinkedList"/> class.
        /// </summary>
        public DoublyLinkedList()
        {
            mTail = null;
            mHead = null;
            mCount = 0;
        }
        /// <summary>
        /// Gets the node at the head of the <see cref="DoublyLinkedList"/>.
        /// </summary>
        public DoublyLinkedListNode Head
        {
            get { return mHead; }
        }
        /// <summary>
        /// Gets the node at the end of the <see cref="DoublyLinkedList"/>.
        /// </summary>
        public DoublyLinkedListNode Tail
        {
            get { return mTail; }
        }

        public int Count
        {
            get { return mCount; }
        }
        /// <summary>
        /// Indicates whether the <see cref="DoublyLinkedList"/> is empty or not.
        /// </summary>
        /// <remarks>
        /// This method is an O(1) operation.
        /// </remarks>
        /// <returns>Returns true if the <see cref="DoublyLinkedList"/> is empty, or false otherwise.</returns>
        public bool IsEmpty()
        {
            return mHead == null;
        }
        /// <summary>
        /// Adds a node to the Tail of the <see cref="DoublyLinkedList"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(1) operation. The head node is always known.
        /// </remarks>
        /// <param name="item">Value to add to the <see cref="DoublyLinkedList"/>.</param>
        public void Add(int item)
        {
            DoublyLinkedListNode node = new DoublyLinkedListNode(item);
            if (IsEmpty())
            {
                mHead = node;
                mTail = node;
            }
            else
            {
                mTail.Next = node;
                node.Previous = mTail;
                mTail = node;
            }
            mCount++;
        }
        /// <summary>
        /// Adds a node to the Tail of the <see cref="DoublyLinkedList"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(1) operation. The head node is always known.
        /// </remarks>
        /// <param name="node">Value to add to the <see cref="DoublyLinkedList"/>.</param>
        public void Add(DoublyLinkedListNode node)
        {
            if (IsEmpty())
            {
                mHead = node;
                mTail = node;
            }
            else
            {
                mTail.Next = node;
                node.Previous = mTail;
                mTail = node;
            }
            mCount++;
        }
        /// <summary>
        /// Adds a node to the head of the <see cref="DoublyLinkedList"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(1) operation. The head node is always known.
        /// </remarks>
        /// <param name="item">Value to add to the <see cref="DoublyLinkedList"/>.</param>
        public void AddFirst(int item)
        {
            DoublyLinkedListNode node = new DoublyLinkedListNode(item);
            if (IsEmpty())
            {
                mHead = node;
                mTail = node;
            }
            else
            {
                mHead.Previous = node;
                node.Next = mHead;
                mHead = node;
            }
            mCount++;
        }
        /// <summary>
        /// Adds a node after a specified node in the <see cref="DoublyLinkedList"/>.
        /// </summary>
        /// <remarks>
        /// This is an O(1) operation.
        /// </remarks>
        /// <param name="node">The <see cref="DoublyLinkedListNode{T}"/> to add after.</param>
        /// <param name="item">The value of the node to add after the specified node.</param>

        public void AddAfter(DoublyLinkedListNode node, int item)
        {
            ArgHelper.InvalidOperation(IsEmpty(), "Head");
            ArgHelper.ArgumentNull(node, "node");
            DoublyLinkedListNode n = new DoublyLinkedListNode(item);

            // check if adding after _tail node
            if (node == mTail)
            {
                n.Previous = mTail;
                mTail.Next = n;
                mTail = n;
            }
            else
            {
                n.Next = node.Next;
                n.Next.Previous = n;
                node.Next = n;
                n.Previous = node;
            }

            mCount++;

        }
        /// <summary>
        /// Adds a node before a specified node in the <see cref="DoublyLinkedList"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(1) operation.
        /// </remarks>
        /// <param name="node">The <see cref="DoublyLinkedListNode}"/> to add before.</param>
        /// <param name="item">The value of the node to add after the specified node.</param>

        public void AddBefore(DoublyLinkedListNode node, int item)
        {
            ArgHelper.InvalidOperation(IsEmpty(), "Head");
            ArgHelper.ArgumentNull(node,"node");

            DoublyLinkedListNode n = new DoublyLinkedListNode(item);

            // check if adding before _head node
            if (node == mHead)
            {
                n.Next = mHead;
                mHead.Previous = n;
                mHead = n;
            }
            else
            {
                n.Next = node;
                node.Previous.Next = n;
                n.Previous = node.Previous;
                node.Previous = n;
            }

            mCount++;
        }
        /// <summary>
        /// Removes a node from the tail of the <see cref="DoublyLinkedList"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(1) operation.
        /// </remarks>
        /// <returns>True if the tail node was removed; otherwise false.</returns>
        public bool RemoveLast()
        {
            if (IsEmpty())
            {
                return false;
            }
            // check to see if there is only 1 item in the linked list
            if (mTail == mHead)
            {
                mHead = null;
                mTail = null;
            }
            else if (mHead.Next == mTail)
            {
                // only two nodes in the dll
                mTail = mHead;
                mHead.Next = null;
            }
            else
            {
                mTail = mTail.Previous;
                mTail.Next = null;
            }

            mCount--;
            return true;
        }
        /// <summary>
        /// Removes the node at the head of the <see cref="DoublyLinkedList"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(1) operation.
        /// </remarks>
        /// <returns>True if the head node was removed; otherwise false.</returns>
        public bool RemoveFirst()
        {
            // check first that the list has some items 
            if (IsEmpty())
            {
                return false;
            }

            if (mHead.Next == null)
            {
                // only one node in the dll
                mHead = null;
                mTail = null;
            }
            else if (mHead.Next == mTail)
            {
                // only two nodes in the dll
                mHead = mTail;
                mHead.Previous = null;
            }
            else
            {
                mHead = mHead.Next; // the new head is the old head nodes next node
                mHead.Previous = null;
            }

            mCount--;
            return true;
        }
        public  bool Remove(int item)
        {
            // case 1: empty list
            if (IsEmpty())
            {
                return false;
            }

            if ( mHead.Value == item)
            {
                if (mHead == mTail)
                {
                    // case 2: only one node in the list
                    mHead = null;
                    mTail = null;
                }
                else
                {
                    // case 3: head is to be removed in a list that contains > 1 node
                    mHead = mHead.Next;
                    mHead.Previous = null;
                }

                mCount--;
                return true;
            }

            DoublyLinkedListNode n = mHead.Next;
            while (n != null && !(item == n.Value))
            {
                n = n.Next;
            }

            if (n == mTail)
            {
                // case 4: tail is to be removed
                mTail = mTail.Previous;
                mTail.Next = null;
                mCount--;
                return true;
            }
            else if (n != null)
            {
                // case 5: node to be removed is somewhere inbetween the head and tail
                n.Previous.Next = n.Next;
                n.Next.Previous = n.Previous;
                mCount--;
                return true;
            }

            return false; // case 6: value not in list
        }
        /// <summary>
        /// Determines whether a value is in the <see cref="DoublyLinkedList"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(n) operation.
        /// </remarks>
        /// <param name="item">Value to search the <see cref="DoublyLinkedList"/> for.</param>
        /// <returns>True if the value was found; otherwise false.</returns>
        public bool Contains(int item)
        {
            DoublyLinkedListNode current = mHead;
            while(current != null)
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
