using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace algorithms.tests
{
    [TestClass]
    public class SortTests
    {
        private static readonly int length = 1000;
        private int[] testData;
        private int[] expected;
        [TestInitialize]
        public void Setup()
        {
            testData = new int[length];

            Random randNum = new Random();
            for (int i = 0; i < length; i++)
            {
                testData[i] = randNum.Next(0, length);
            }

            var testDataList = testData.ToList();
            testDataList.Sort();
            expected = testDataList.ToArray();
        }

        [TestMethod]
        [TestCategory("sort")]
        public void BubbleSortTest()
        {
            var actual = BubbleSort.Execute(testData);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("sort")]
        public void SelectSortTest()
        {
            var actual = SelectSort.Execute(testData);
            CollectionAssert.AreEqual(expected, actual);


        }

        [TestMethod]
        [TestCategory("sort")]
        public void InsertSortTest()
        {
            var actual = InsertSort.Execute(testData);
            CollectionAssert.AreEqual(expected, actual);
        }

    }
}
