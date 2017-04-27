namespace DSATest.DataStructureTest
{
    using DataStructure;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
