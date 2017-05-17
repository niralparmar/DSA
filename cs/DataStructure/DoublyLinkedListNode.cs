namespace DataStructure
{
    public class DoublyLinkedListNode
    {
        public DoublyLinkedListNode(int item)
        {
            Value = item;
        }
        public int Value { get; set; }

        public DoublyLinkedListNode Next { get; set; }

        public DoublyLinkedListNode Previous { get; set; }
    }
}
