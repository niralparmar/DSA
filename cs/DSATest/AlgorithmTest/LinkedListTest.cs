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
            DataStructure.LinkedList list = TestData.GetLinkedList(new int[] { 1, 2, 3, 4 });
            DataStructure.LinkedListNode node =  Algorithms.LinkedList.ReverseLinkedList(list.Head);
            Assert.AreEqual(node.Value, 4);

        }
        [TestMethod]
        public void PalindromTest()
        {
            DataStructure.LinkedList list = TestData.GetLinkedList(new int[] { 1, 2, 3, 1 });
            Assert.AreEqual(Algorithms.LinkedList.IsPalindrom(list.Head), false);

        }
        [TestMethod]
        public void IntersectionTest()
        {
            DataStructure.LinkedList list1 = TestData.GetEmptyLinkedList();
            DataStructure.LinkedList list2 = TestData.GetEmptyLinkedList();

            LinkedListNode node1 = new LinkedListNode(1);
            LinkedListNode node2 = new LinkedListNode(2);
            LinkedListNode node3 = new LinkedListNode(3);
            LinkedListNode node4 = new LinkedListNode(4);
            LinkedListNode node5 = new LinkedListNode(5);
            LinkedListNode node11 = new LinkedListNode(11);
            LinkedListNode node22 = new LinkedListNode(22);
            LinkedListNode node33 = new LinkedListNode(33);
            node22.Next = node33;
            node11.Next = node22;
            node3.Next = node11;
            node2.Next = node3;
            node1.Next = node2;
            node5.Next = node11;
            node4.Next = node5;

            list1.Add(node1);
            list2.Add(node4);
            Assert.AreEqual(Algorithms.LinkedList.GetIntersectionNode(list1.Head,list2.Head).Value, node11.Value);

        }
        [TestMethod]
        public void RemoveDupplicateTest()
        {
            DataStructure.LinkedList list = TestData.GetLinkedList(new int[] { 1, 2, 3, 1 });
            Algorithms.LinkedList.RemoveDuplicate(list.Head);
            Assert.AreEqual(list.Head.Value, 1);
            Assert.AreEqual(list.Head.Next.Value, 2);
            Assert.AreEqual(list.Head.Next.Next.Value, 3);
            Assert.AreEqual(list.Head.Next.Next.Next, null);
        }
    }
}
