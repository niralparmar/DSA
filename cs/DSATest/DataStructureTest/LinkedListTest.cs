namespace DSATest.DataStructureTest
{
    using DataStructure;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class LinkedListTest
    {
        /// <summary>
        /// Check to see that the LinkedList reports as empty when it is.
        /// </summary>
        [TestMethod]
        public void IsEmptyTest()
        {
            LinkedList list = new LinkedList();

            Assert.IsTrue(list.IsEmpty());
        }

        /// <summary>
        /// Check to see that nodes are added correctly to the tail of the LinkedList.
        /// </summary>
        [TestMethod]
        public void AddLastTest()
        {
            LinkedList list = new LinkedList();
            list.Add(5);
            list.Add(10);
            list.Add(15);
            Assert.IsFalse(list.IsEmpty());
            Assert.AreEqual(5, list.Head.Value);
            Assert.AreEqual(10, list.Head.Next.Value);
            Assert.AreEqual(15, list.Tail.Value);
        }

        /// <summary>
        /// Check to see that the value of the Head node of the LinkedList is as expected.
        /// </summary>
        [TestMethod]
        public void HeadTest()
        {
            LinkedList list = new LinkedList();
            list.Add(10);

            Assert.AreEqual(10, list.Head.Value);
        }

        /// <summary>
        /// Check to see that the value of the Tail node of the LinkedList is as expected.
        /// </summary>
        [TestMethod]
        public void TailTest()
        {
            LinkedList list = new LinkedList();
            list.Add(10);

            Assert.AreEqual(10, list.Tail.Value);
        }
        /// <summary>
        /// Check to see that the Count property of the LinkedList returns the correct number.
        /// </summary>
        [TestMethod]
        public void CountTest()
        {
            LinkedList list = new LinkedList();
            list.Add(10);
            list.Add(20);
            Assert.AreEqual(2, list.Count);
        }
        /// <summary>
        /// Check to see that calling RemoveFirst on LinkedList with only 1 node results in the expected behaviour.
        /// </summary>
        [TestMethod]
        public void RemoveFirstOneItemInListTest()
        {
            LinkedList sll = new LinkedList();

            sll.RemoveFirst();

            Assert.AreEqual(0, sll.Count);
            Assert.IsNull(sll.Head);
            Assert.IsNull(sll.Tail);
        }
        /// <summary>
        /// Check to see that when removing the only node in the list that the head and tail pointers are update correctly.
        /// </summary>
        [TestMethod]
        public void RemoveOnlyNodeInListTest()
        {
            LinkedList list = new LinkedList();

            list.Remove(12);

            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
        }

        /// <summary>
        /// Check to see that when calling the RemoveFirst method on a LinkedListCollection with more than one node
        /// results in the expected object state.
        /// </summary>
        [TestMethod]
        public void RemoveFirstTest()
        {
            LinkedList list = new LinkedList();

            list.AddFirst(40);
            list.AddFirst(30);
            list.AddFirst(20);
            list.AddFirst(10);
            list.Add(50);
            list.RemoveFirst();
            list.RemoveFirst();

            Assert.AreEqual(30, list.Head.Value);
            Assert.AreEqual(50, list.Tail.Value);
            Assert.AreEqual(3, list.Count);
        }

        /// <summary>
        /// Check to see that the correct value is returned when there is nothing to remove.
        /// </summary>
        [TestMethod]
        public void RemoveFirstEmptyListTest()
        {
            LinkedList list = new LinkedList();

            Assert.IsFalse(list.RemoveFirst());
        }
        /// <summary>
        /// Check to see that the contains method returns the correct bool depending on whether the item is in the 
        /// LinkedListCollection or not.
        /// </summary>
        [TestMethod]
        public void ContainsTest()
        {
            LinkedList list = new LinkedList();
            list.AddFirst(40);
            list.AddFirst(30);
            list.AddFirst(20);

            Assert.IsTrue(list.Contains(20));
            Assert.IsFalse(list.Contains(10));
        }

        /// <summary>
        /// Check to see that the correct exception is raised when attempting to remove an item from an empty
        /// LinkedListCollection.
        /// </summary>
        [TestMethod]
        public void RemoveItemFromEmptyLinkedListCollection()
        {
            LinkedList list = new LinkedList();
            
            Assert.IsFalse(list.Remove(10));
        }

        /// <summary>
        /// Check to see that Remove leaves the LinkedList in the correct state where the value of Remove
        /// is equal to that of the head node.
        /// </summary>
        [TestMethod]
        public void RemoveHeadItemTest()
        {
            LinkedList list = new LinkedList();
            list.Add(10);
            list.Add(20);
            list.Add(30);

            bool actual = list.Remove(10);

            Assert.AreEqual(20, list.Head.Value);
            Assert.AreEqual(30, list.Tail.Value);
            Assert.AreEqual(30, list.Head.Next.Value);
            Assert.AreEqual(2, list.Count);
            Assert.IsTrue(actual);
        }

        /// <summary>
        /// Check to see that Remove leaves the LinkedList in the correct state, when remove is any node but head or tail.
        /// </summary>
        [TestMethod]
        public void RemoveMiddleItemTest()
        {
            LinkedList list = new LinkedList();
            list.Add(10);
            list.Add(20);
            list.Add(30);

            bool actual = list.Remove(20);

            Assert.AreEqual(30, list.Head.Next.Value);
            Assert.AreEqual(10, list.Head.Value);
            Assert.AreEqual(30, list.Tail.Value);
            Assert.AreEqual(2, list.Count);
            Assert.IsTrue(actual);
        }

        /// <summary>
        /// Check to see that Remove leaves the LinkedList in the correct state where the value of Remove
        /// is equal to that of the tail node.
        /// </summary>
        [TestMethod]
        public void RemoveTailItemTest()
        {
            LinkedList list = new LinkedList();
            list.Add(10);
            list.Add(20);
            list.Add(30);
            bool actual = list.Remove(30);

            Assert.AreEqual(10, list.Head.Value);
            Assert.AreEqual(20, list.Head.Next.Value);
            Assert.AreEqual(20, list.Tail.Value);
            Assert.AreEqual(2, list.Count);
            Assert.IsNull(list.Tail.Next);
            Assert.IsTrue(actual);
        }
        /// <summary>
        /// Check to see that AddBefore a middle node results in the expected state of the LinkedList.
        /// </summary>
        [TestMethod]
        public void AddBeforeMiddleNodeTest()
        {
            LinkedList list = new LinkedList();
            list.Add(10);
            list.Add(20);
            list.Add(30);

            list.AddBefore(list.Head.Next, 15);

            Assert.AreEqual(15, list.Head.Next.Value);
            Assert.AreEqual(20, list.Head.Next.Next.Value);
            Assert.AreEqual(4, list.Count);
        }

        /// <summary>
        /// Check to see that the correct exception is raised when calling AddBefore on a LinkedList with no nodes.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddBeforeEmptyListTest()
        {
            LinkedList list = new LinkedList();

            list.AddBefore(list.Head, 10);
        }

    }
}
