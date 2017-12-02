namespace DataStructure
{
    public class LinkedListNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LinkedListNode"/> class with a specified value.
        /// </summary>
        /// <param name="value">Value of node.</param>
        public LinkedListNode(int value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets the value of <see cref="LinkedListNode"/>.
        /// </summary>
        public int Value { get;  set; }

        /// <summary>
        /// Gets or sets the pointer to the next <see cref="LinkedListNode"/>.
        /// </summary>
        public LinkedListNode Next { get; set; }
    }
}
