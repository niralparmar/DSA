namespace DSATest.DataStructureTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using DataStructure;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class DoublyLinkedListTest
    {
        // <summary>
        /// Check to see that AddLast adds a node onto the tail of the list.
        /// </summary>
        [TestMethod]
        public void AddLastTest()
        {
            DoublyLinkedList list = TestData.GetDoublyLinkedList(new int[] { 10, 20, 30 });

            Assert.AreEqual(10, list.Head.Value);
            Assert.AreEqual(20, list.Head.Next.Value);
            Assert.AreEqual(10, list.Head.Next.Previous.Value);
            Assert.AreEqual(30, list.Tail.Value);
            Assert.AreEqual(20, list.Tail.Previous.Value);
        }
        /// <summary>
        /// Check to see that AddFirst adds a node to the head of the linked list.
        /// </summary>
        [TestMethod]
        public void AddFirstTest()
        {
            DoublyLinkedList list = TestData.GetEmptyDoublyLinkedList();
            list.AddFirst(10);
            list.AddFirst(20);

            Assert.AreEqual(20, list.Head.Value);
        }
        /// <summary>
        /// Check to see that a call to AddAfter raises the correct exception when there are no nodes to add after.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddAfterNoNodesTest()
        {
            DoublyLinkedList list = TestData.GetEmptyDoublyLinkedList();

            list.AddAfter(list.Head, 10);
        }
        /// <summary>
        /// Check to see that the correct exception is raised when adding after a null node.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddAfterNullNodeTest()
        {
            DoublyLinkedList list = TestData.GetDoublyLinkedList(new int[] { 10 });

            list.AddAfter(null, 10);
        }
        /// <summary>
        /// Check to see that calling AddAfter passing in the tail node updates the internal tail node pointer.
        /// </summary>
        [TestMethod]
        public void AddAfterTailTest()
        {
            DoublyLinkedList list = TestData.GetDoublyLinkedList(new int[] { 10 });

            list.AddAfter(list.Head, 20);

            Assert.AreEqual(20, list.Tail.Value);
            Assert.AreEqual(10, list.Tail.Previous.Value);
        }

        /// <summary>
        /// Check to see that calling AddAfter passing in a node that isn't the tail results in the expected state.
        /// </summary>
        [TestMethod]
        public void AddAfterTest()
        {
            DoublyLinkedList list = TestData.GetDoublyLinkedList(new int[] { 10, 20, 30 });

            list.AddAfter(list.Head.Next, 25);

            Assert.AreEqual(25, list.Head.Next.Next.Value);
            Assert.AreEqual(20, list.Head.Next.Next.Previous.Value);
            Assert.AreEqual(30, list.Head.Next.Next.Next.Value);
            Assert.AreEqual(25, list.Tail.Previous.Value);
        }
        /// <summary>
        /// Check to see that calling AddBefore results in the node being placed in the correct position in the DoublyLinkedList when
        /// adding before the head node.
        /// </summary>
        [TestMethod]
        public void AddBeforeHeadTest()
        {
            DoublyLinkedList list = TestData.GetDoublyLinkedList(new int[] { 10 });

            list.AddBefore(list.Head, 5);

            Assert.AreEqual(5, list.Head.Value);
            Assert.AreEqual(10, list.Head.Next.Value);
            Assert.AreEqual(5, list.Head.Next.Previous.Value);
        }

        /// <summary>
        /// Check to see that when calling AddBefore the node is placed in the correct position within the linked list.
        /// </summary>
        [TestMethod]
        public void AddBeforeTest()
        {
            DoublyLinkedList list = TestData.GetDoublyLinkedList(new int[] { 10, 30 });

            list.AddBefore(list.Head.Next, 20);

            Assert.AreEqual(20, list.Head.Next.Value);
            Assert.AreEqual(10, list.Head.Next.Previous.Value);
            Assert.AreEqual(30, list.Head.Next.Next.Value);
            Assert.AreEqual(20, list.Tail.Previous.Value);
        }

        /// <summary>
        /// Check to see that calling AddBefore when the list is empty results in the correct exception being raised.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddBeforeEmptyListTest()
        {
            DoublyLinkedList list = TestData.GetEmptyDoublyLinkedList();

            list.AddBefore(list.Head, 10);
        }

        /// <summary>
        /// Check to see that a call to AddBefore when passing in a null node raises the correct exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddBeforeNullNode()
        {
            DoublyLinkedList list = TestData.GetDoublyLinkedList(new int[] { 10 });

            list.AddBefore(list.Head.Next, 20);
        }
        // Check to see that the IsEmpty method returns the correct value.
        /// </summary>
        [TestMethod]
        public void IsEmptyTest()
        {
            DoublyLinkedList list = TestData.GetEmptyDoublyLinkedList();

            Assert.IsTrue(list.IsEmpty());
        }

        /// <summary>
        /// Check to see that a call to RemoveLast on a non empty list results in the expected behaviour.
        /// </summary>
        [TestMethod]
        public void RemoveLastTest()
        {
            DoublyLinkedList list = TestData.GetDoublyLinkedList(new int[] { 10 });

            list.RemoveLast();

            Assert.IsTrue(list.IsEmpty());
            Assert.IsFalse(list.RemoveLast());
            Assert.IsNull(list.Tail);
        }

        /// <summary>
        /// Check to see that a call to RemoveLast when there are two nodes in the linked list reassigns the tail node.
        /// </summary>
        [TestMethod]
        public void RemoveLastTwoNodesTest()
        {
            DoublyLinkedList list = TestData.GetDoublyLinkedList(new int[] { 10, 20 });

            Assert.IsTrue(list.RemoveLast());
            Assert.AreEqual(10, list.Head.Value);
            Assert.AreEqual(10, list.Tail.Value);
            Assert.IsNull(list.Tail.Next);
            Assert.IsNull(list.Head.Next);
        }

        /// <summary>
        /// Check to see that calling RemoveLast when there are more than two nodes results in the expected behaviour.
        /// </summary>
        [TestMethod]
        public void RemoveLastTestMultipleNodesTest()
        {
            DoublyLinkedList list = TestData.GetDoublyLinkedList(new int[] { 10, 20 ,30});

            list.RemoveLast();

            Assert.AreEqual(20, list.Tail.Value);
            Assert.IsNull(list.Tail.Next);
        }

        /// <summary>
        /// Check to see that calling RemoveLast on an empty list throws the correct exception.
        /// </summary>
        [TestMethod]
        public void RemoveLastEmptyListTest()
        {
            DoublyLinkedList list = TestData.GetEmptyDoublyLinkedList();

            list.RemoveLast();
        }

        /// <summary>
        /// Check to see that a call to RemoveFirst when there is only a single node in the linked list
        /// results in the expected behaviour.
        /// </summary>
        [TestMethod]
        public void RemoveFirstSingleNodeTest()
        {
            DoublyLinkedList list = TestData.GetDoublyLinkedList(new int[] { 10 });

            list.RemoveFirst();

            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
        }

        /// <summary>
        /// Check to see that a call to RemoveFirst when there are two node in the linked list
        /// results in the expected behaviour.
        /// </summary>
        [TestMethod]
        public void RemoveFirstTwoNodesTest()
        {
            DoublyLinkedList list = TestData.GetDoublyLinkedList(new int[] { 10, 20 });

            list.RemoveFirst();

            Assert.AreEqual(20, list.Head.Value);
            Assert.IsNull(list.Head.Previous);
        }

        /// <summary>
        /// Check to see that calling RemoveFirst when there are more than two nodes in the linked list
        /// results in the expected behaviour.
        /// </summary>
        [TestMethod]
        public void RemoveFirstMoreThanTwoNodesTest()
        {
            DoublyLinkedList list = TestData.GetDoublyLinkedList(new int[] { 10, 20, 30 });

            Assert.IsTrue(list.RemoveFirst());
            Assert.AreEqual(20, list.Head.Value);
            Assert.IsNull(list.Head.Previous);
        }

        /// <summary>
        /// Check to see that calling RemoveFirst on a linked list with no nodes returns false.
        /// </summary>
        [TestMethod]
        public void RemoveFirstEmptyListTest()
        {
            DoublyLinkedList list = TestData.GetEmptyDoublyLinkedList();

            Assert.IsFalse(list.RemoveFirst());
        }
        /// <summary>
        /// Check to see that the Count property returns the expected value.
        /// </summary>
        [TestMethod]
        public void CountTest()
        {
            DoublyLinkedList list = TestData.GetDoublyLinkedList(new int[] { 10,5 });

            list.RemoveFirst();
            list.RemoveLast();
            list.Add(10);
            list.AddAfter(list.Head, 30);
            list.AddBefore(list.Head.Next, 20);

            Assert.AreEqual(3, list.Count);
        }

        /// <summary>
        /// Check to see that Contains returns the correct value.
        /// </summary>
        [TestMethod]
        public void ContainsTest()
        {
            DoublyLinkedList list = TestData.GetDoublyLinkedList(new int[] { 10, 20, 30 });

            Assert.IsTrue(list.Contains(20));
            Assert.IsFalse(list.Contains(40));
        }
        /// <summary>
        /// Check to see that calling Remove on a DoublyLinkedListCollection(Of T) that contains no nodes results in the
        /// correct raised exception.
        /// </summary>
        [TestMethod]
        public void RemoveEmptyListTest()
        {
            DoublyLinkedList list = TestData.GetEmptyDoublyLinkedList();

            Assert.IsFalse(list.Remove(10));
        }

        /// <summary>
        /// Check to see that removing a single node from the DoublyLinkedListCollection(Of T) results in the list being
        /// declared as empty.
        /// </summary>
        [TestMethod]
        public void RemoveSingleNodeTest()
        {
            DoublyLinkedList list = TestData.GetDoublyLinkedList(new int[] { 10});

            list.Remove(10);

            Assert.IsTrue(list.IsEmpty());
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
            Assert.AreEqual(0, list.Count);
        }

        /// <summary>
        /// Check to see that the DoublyLinkedListCollection(Of T) is left in the correct state after removing head value from 
        /// a list with two nodes.
        /// </summary>
        [TestMethod]
        public void RemoveHeadTwoNodes()
        {
            DoublyLinkedList list = TestData.GetDoublyLinkedList(new int[] { 10, 20 });

            list.Remove(10);

            Assert.AreEqual(20, list.Head.Value);
            Assert.AreEqual(20, list.Tail.Value);
            Assert.AreEqual(1, list.Count);
        }

        /// <summary>
        /// Check to see that the DoublyLinkedListCollection(Of T) is left in the correct state after removing tail value from 
        /// a list with two nodes.
        /// </summary>
        [TestMethod]
        public void RemoveTailTwoNodes()
        {
            DoublyLinkedList list = TestData.GetDoublyLinkedList(new int[] { 10, 20 });

            list.Remove(20);

            Assert.AreEqual(10, list.Head.Value);
            Assert.AreEqual(10, list.Tail.Value);
            Assert.AreEqual(1, list.Count);
        }

        /// <summary>
        /// Check to see that the DoublyLinkedListCollection(Of T) is left in the correct state when removing
        /// middle node value from a list of 3 or more nodes.
        /// </summary>
        [TestMethod]
        public void RemoveMiddleMultipleNodesTest()
        {
            DoublyLinkedList list = TestData.GetDoublyLinkedList(new int[] { 10, 20, 30 });

            list.Remove(20);

            Assert.AreEqual(30, list.Head.Next.Value);
            Assert.AreEqual(10, list.Tail.Previous.Value);
            Assert.AreEqual(2, list.Count);
        }

        /// <summary>
        /// Check to see that the DoublyLinkedListCollection(Of T) is left in the correct state when removing
        /// head node value from a list of 3 or more nodes.
        /// </summary>
        [TestMethod]
        public void RemoveHeadMultipleNodesTest()
        {
            DoublyLinkedList list = TestData.GetDoublyLinkedList(new int[] { 10, 20, 30 });

            list.Remove(10);

            Assert.AreEqual(20, list.Head.Value);
            Assert.IsNull(list.Head.Previous);
            Assert.AreEqual(2, list.Count);
        }

        /// <summary>
        /// Check to see that the DoublyLinkedListCollection(Of T) is left in the correct state when removing
        /// middle node value from a list of 3 or more nodes.
        /// </summary>
        [TestMethod]
        public void RemoveTailMultipleNodesTest()
        {
            DoublyLinkedList list = TestData.GetDoublyLinkedList(new int[] { 10, 20, 30 });

            list.Remove(30);

            Assert.AreEqual(20, list.Tail.Value);
            Assert.IsNull(list.Tail.Next);
            Assert.AreEqual(2, list.Count);
        }

        /// <summary>
        /// Check to see that the correct value is returned when the value to be removed is not in the
        /// DoublyLinkedListCollection(Of T).
        /// </summary>
        [TestMethod]
        public void RemoveNoMatchTest()
        {
            DoublyLinkedList list = TestData.GetDoublyLinkedList(new int[] { 10 });

            Assert.IsFalse(list.Remove(20));
        }
    }
}
