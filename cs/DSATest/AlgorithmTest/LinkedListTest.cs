namespace DSATest.AlgorithmTest
{
    using Algorithms ;
    using DataStructure;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    [TestClass]
    public class LinkedListTest
    {
        [TestMethod]
        public void ReverseLinkedList()
        {
            DataStructure.LinkedList list = new DataStructure.LinkedList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            DataStructure.LinkedListNode node =  Algorithms.LinkedList.ReverseLinkedList(list.Head);
            Assert.AreEqual(node.Value, 4);

        }
    }
}
