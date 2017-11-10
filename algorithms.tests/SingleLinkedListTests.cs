using algorithms.DataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace algorithms.tests
{
    [TestClass]
    public class SingleLinkedListTests
    {
        [TestInitialize]
        public void Setup()
        {
        }

        [TestMethod]
        [TestCategory("SingleLinkedList")]
        public void Insert_Test()
        {
            SingleLinkedList list = new SingleLinkedList();
            list.Insert(2);

            Assert.AreEqual(2, list.Tailer.Value);

            list.Insert(3);
            Assert.AreEqual(3, list.Tailer.Value);
        }

        [TestMethod]
        [TestCategory("SingleLinkedList")]
        public void Contains_Test()
        {
            SingleLinkedList list = new SingleLinkedList();

            Assert.AreEqual(false, list.Contains(2));

            list.Insert(2);
            Assert.AreEqual(true, list.Contains(2));
            Assert.AreEqual(false, list.Contains(3));

            list.Insert(3);
            Assert.AreEqual(true, list.Contains(3));
        }

        [TestMethod]
        [TestCategory("SingleLinkedList")]
        public void Delete_Given_Empty_List_Test()
        {
            SingleLinkedList list = new SingleLinkedList();

            Assert.AreEqual(false, list.Delete(2));
        }

        [TestMethod]
        [TestCategory("SingleLinkedList")]
        public void Delete_Given_One_Node_List_Test()
        {
            SingleLinkedList list = new SingleLinkedList();
            list.Insert(2);

            Assert.AreEqual(true, list.Delete(2));
            Assert.AreEqual(false, list.Delete(2));
            Assert.AreEqual(null, list.Header);
            Assert.AreEqual(null, list.Tailer);
        }

        [TestMethod]
        [TestCategory("SingleLinkedList")]
        public void Delete_Node_Test()
        {
            SingleLinkedList list = new SingleLinkedList();

            list.Insert(2);
            list.Insert(3);
            list.Insert(4);
            Assert.AreEqual(true, list.Delete(3));
            Assert.AreEqual(false, list.Delete(3));
            Assert.AreEqual(false, list.Contains(3));
            Assert.AreEqual(2, list.Header.Value);
            Assert.AreEqual(4, list.Tailer.Value);
            Assert.AreEqual(4, list.Header.NextNode.Value);
        }

        [TestMethod]
        [TestCategory("SingleLinkedList")]
        public void Delete_Header_Test()
        {
            SingleLinkedList list = new SingleLinkedList();

            list.Insert(2);
            list.Insert(3);
            list.Insert(4);
            Assert.AreEqual(true, list.Delete(2));
            Assert.AreEqual(false, list.Delete(2));
            Assert.AreEqual(false, list.Contains(2));
            Assert.AreEqual(3, list.Header.Value);
            Assert.AreEqual(4, list.Tailer.Value);
            Assert.AreEqual(4, list.Header.NextNode.Value);
        }

        [TestMethod]
        [TestCategory("SingleLinkedList")]
        public void Delete_Tailer_Test()
        {
            SingleLinkedList list = new SingleLinkedList();

            list.Insert(2);
            list.Insert(3);
            list.Insert(4);
            Assert.AreEqual(true, list.Delete(4));
            Assert.AreEqual(false, list.Delete(4));
            Assert.AreEqual(false, list.Contains(4));
            Assert.AreEqual(2, list.Header.Value);
            Assert.AreEqual(3, list.Tailer.Value);
            Assert.AreEqual(3, list.Header.NextNode.Value);
        }

        [TestMethod]
        [TestCategory("SingleLinkedList")]
        public void Travel_Test()
        {
            SingleLinkedList list = new SingleLinkedList();

            list.Insert(2);
            list.Insert(3);
            list.Insert(4);

            Assert.AreEqual(3, list.Travel().Count());
            Assert.AreEqual(2, list.Travel().ToList()[0].Value);
            Assert.AreEqual(3, list.Travel().ToList()[1].Value);
            Assert.AreEqual(4, list.Travel().ToList()[2].Value);
        }

        [TestMethod]
        [TestCategory("SingleLinkedList")]
        public void Travel_Given_Empty_List_Test()
        {
            SingleLinkedList list = new SingleLinkedList();

            Assert.AreEqual(0, list.Travel().Count());
        }

        [TestMethod]
        [TestCategory("SingleLinkedList")]
        public void ReverseTravel_Given_Empty_List_Test()
        {
            SingleLinkedList list = new SingleLinkedList();

            Assert.AreEqual(0, list.ReverseTravel().Count());
        }

        [TestMethod]
        [TestCategory("SingleLinkedList")]
        public void ReverseTravel_Test()
        {
            SingleLinkedList list = new SingleLinkedList();

            list.Insert(2);
            list.Insert(3);
            list.Insert(4);

            Assert.AreEqual(3, list.ReverseTravel().Count());
            Assert.AreEqual(4, list.ReverseTravel().ToList()[0].Value);
            Assert.AreEqual(3, list.ReverseTravel().ToList()[1].Value);
            Assert.AreEqual(2, list.ReverseTravel().ToList()[2].Value);
        }

    }
}
