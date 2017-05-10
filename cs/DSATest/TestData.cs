namespace DSATest
{
    using DataStructure;
    public class TestData
    {
        public static LinkedList GetLinkedList(int[] data)
        {
            DataStructure.LinkedList list = new DataStructure.LinkedList();
            for (int i = 0; i < data.Length; i++)
            {
                list.Add(data[i]);
            }
            return list;
        }
        public static LinkedList GetLinkedList(int count)
        {
            DataStructure.LinkedList list = new DataStructure.LinkedList();
            for (int i = 0; i < count; i++)
            {
                list.Add(i);
            }
            return list;
        }
        public static LinkedList GetEmptyLinkedList()
        {
            return GetLinkedList(0);
        }
    }
}
