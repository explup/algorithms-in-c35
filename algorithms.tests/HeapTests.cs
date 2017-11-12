using algorithms.DataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace algorithms.tests
{
    [TestClass]
    public class HeapTest
    {
        [TestInitialize]
        public void Setup()
        {
        }

        [TestMethod]
        [TestCategory("HeapTest")]
        public void Insert_Test()
        {
            Heap heap = new Heap(10);
            heap.Add(3);
            heap.Add(9);
            heap.Add(12);
            heap.Add(7);
            heap.Add(1);

            Assert.AreEqual(1, heap.ValueAtIndex(0));
            Assert.AreEqual(3, heap.ValueAtIndex(1));
            Assert.AreEqual(12, heap.ValueAtIndex(2));
            Assert.AreEqual(9, heap.ValueAtIndex(3));
            Assert.AreEqual(7, heap.ValueAtIndex(4));

        }

        [TestMethod]
        [TestCategory("HeapTest")]
        public void Delete_Test()
        {
            Heap heap = new Heap(10);
            heap.Add(1);
            heap.Add(5);
            heap.Add(6);
            heap.Add(9);
            heap.Add(11);
            heap.Add(8);
            heap.Add(15);
            heap.Add(17);
            heap.Add(21);

            Assert.AreEqual(1, heap.ValueAtIndex(0));
            Assert.AreEqual(5, heap.ValueAtIndex(1));
            Assert.AreEqual(6, heap.ValueAtIndex(2));
            Assert.AreEqual(9, heap.ValueAtIndex(3));
            Assert.AreEqual(11, heap.ValueAtIndex(4));
            Assert.AreEqual(8, heap.ValueAtIndex(5));
            Assert.AreEqual(15, heap.ValueAtIndex(6));
            Assert.AreEqual(17, heap.ValueAtIndex(7));
            Assert.AreEqual(21, heap.ValueAtIndex(8));

            heap.Delete(5);

            Assert.AreEqual(1, heap.ValueAtIndex(0));
            Assert.AreEqual(9, heap.ValueAtIndex(1));
            Assert.AreEqual(6, heap.ValueAtIndex(2));
            Assert.AreEqual(17, heap.ValueAtIndex(3));
            Assert.AreEqual(11, heap.ValueAtIndex(4));
            Assert.AreEqual(8, heap.ValueAtIndex(5));
            Assert.AreEqual(15, heap.ValueAtIndex(6));
            Assert.AreEqual(21, heap.ValueAtIndex(7));

        }


        [TestMethod]
        [TestCategory("HeapTest")]
        public void Contains_Test()
        {
            Heap heap = new Heap(10);
            heap.Add(3);
            heap.Add(9);
            heap.Add(12);
            heap.Add(7);
            heap.Add(1);

            Assert.IsFalse(heap.Contains(8));
            Assert.IsFalse(heap.Contains(12));
        }


    }
}
