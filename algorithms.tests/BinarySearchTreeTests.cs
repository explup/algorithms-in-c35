using algorithms.DataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace algorithms.tests
{
    [TestClass]
    public class BinarySearchTreeTests
    {

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void BinarySearchTree_Insert_To_Empty_Tree()
        {
            BinarySearchTree tree = new BinarySearchTree();
            tree.Insert(1);

            Assert.AreEqual(1, tree.Root.Value);
            Assert.IsNull(tree.Root.LeftNode);
            Assert.IsNull(tree.Root.RightNode);
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void BinarySearchTree_Insert()
        {
            BinarySearchTree tree = new BinarySearchTree();
            tree.Insert(8);
            tree.Insert(5);
            tree.Insert(9);

            Assert.AreEqual(8, tree.Root.Value);
            Assert.AreEqual(5, tree.Root.LeftNode.Value);
            Assert.AreEqual(9, tree.Root.RightNode.Value);

            tree.Insert(2);
            tree.Insert(6);
            Assert.AreEqual(2, tree.Root.LeftNode.LeftNode.Value);
            Assert.AreEqual(6, tree.Root.LeftNode.RightNode.Value);

            tree.Insert(11);
            Assert.AreEqual(11, tree.Root.RightNode.RightNode.Value);
            Assert.AreEqual(null, tree.Root.RightNode.LeftNode);

        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void BinarySearchTree_Contains()
        {
            BinarySearchTree tree = new BinarySearchTree();
            tree.Insert(8);
            tree.Insert(5);
            tree.Insert(9);

            tree.Insert(2);
            tree.Insert(6);

            tree.Insert(11);

            Assert.AreEqual(true, tree.Contains(11));
            Assert.AreEqual(false, tree.Contains(12));
            Assert.AreEqual(true, tree.Contains(8));
            Assert.AreEqual(true, tree.Contains(2));
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void BinarySearchTree_Given_Single_Node_Tree_When_Delete_Root_()
        {
            BinarySearchTree tree = new BinarySearchTree();
            tree.Insert(8);

            Assert.AreEqual(true, tree.Delete(8));
            Assert.AreEqual(false, tree.Contains(8));

            Assert.IsNull(tree.Root);
        }


        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void BinarySearchTree_Delete_Root_When_Existing_Right_Node()
        {
            BinarySearchTree tree = new BinarySearchTree();
            tree.Insert(5);
            tree.Insert(2);
            tree.Insert(9);

            Assert.AreEqual(true, tree.Delete(5));
            Assert.AreEqual(false, tree.Contains(8));
            Assert.AreEqual(9, tree.Root.Value);
            Assert.AreEqual(2, tree.Root.LeftNode.Value);
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void BinarySearchTree_Delete_Root_When_Not_Existing_Right_Node()
        {
            BinarySearchTree tree = new BinarySearchTree();
            tree.Insert(5);
            tree.Insert(2);

            Assert.AreEqual(true, tree.Delete(5));
            Assert.AreEqual(false, tree.Contains(8));
            Assert.AreEqual(2, tree.Root.Value);
        }


        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void BinarySearchTree_Delete_Leaf()
        {
            BinarySearchTree tree = new BinarySearchTree();
            tree.Insert(8);
            tree.Insert(5);
            tree.Insert(9);
            tree.Insert(2);

            Assert.AreEqual(true, tree.Delete(2));
            Assert.AreEqual(false, tree.Contains(2));
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void BinarySearchTree_Delete_Node_With_Left_Child()
        {
            BinarySearchTree tree = new BinarySearchTree();
            tree.Insert(5);
            tree.Insert(2);
            tree.Insert(9);
            tree.Insert(1);

            Assert.AreEqual(true, tree.Delete(2));
            Assert.AreEqual(false, tree.Contains(2));
            Assert.AreEqual(1, tree.Root.LeftNode.Value);
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void BinarySearchTree_Delete_Node_With_Right_Child()
        {
            BinarySearchTree tree = new BinarySearchTree();
            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(9);
            tree.Insert(1);
            tree.Insert(4);

            Assert.AreEqual(true, tree.Delete(3));
            Assert.AreEqual(false, tree.Contains(3));
            Assert.AreEqual(4, tree.Root.LeftNode.Value);
            Assert.AreEqual(1, tree.Root.LeftNode.LeftNode.Value);
        }


        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void BinarySearchTree_FindMinValue()
        {
            BinarySearchTree tree = new BinarySearchTree();
            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(9);
            tree.Insert(1);
            tree.Insert(4);

            Assert.AreEqual(1, tree.FindMinValue(tree.Root));
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void BinarySearchTree_FindMinValue_With_Empty_Tree()
        {
            BinarySearchTree tree = new BinarySearchTree();

            Assert.AreEqual(null, tree.FindMinValue(tree.Root));
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void BinarySearchTree_FindMaxValue()
        {
            BinarySearchTree tree = new BinarySearchTree();
            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(9);
            tree.Insert(1);
            tree.Insert(4);

            Assert.AreEqual(9, tree.FindMaxValue(tree.Root));
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void BinarySearchTree_FindMaxValue_With_Empty_Tree()
        {
            BinarySearchTree tree = new BinarySearchTree();

            Assert.AreEqual(null, tree.FindMaxValue(tree.Root));
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void BinarySearchTree_Preorder()
        {
            BinarySearchTree tree = new BinarySearchTree();
            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(9);
            tree.Insert(1);
            tree.Insert(4);

            var result = tree.Preorder().ToList();
            Assert.AreEqual(5, result.Count);

            Assert.AreEqual(5, result[0].Value);
            Assert.AreEqual(3, result[1].Value);
            Assert.AreEqual(1, result[2].Value);
            Assert.AreEqual(4, result[3].Value);
            Assert.AreEqual(9, result[4].Value);

        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void BinarySearchTree_Postorder()
        {
            BinarySearchTree tree = new BinarySearchTree();
            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(9);
            tree.Insert(1);
            tree.Insert(4);

            var result = tree.Postorder().ToList();
            Assert.AreEqual(5, result.Count);

            Assert.AreEqual(1, result[0].Value);
            Assert.AreEqual(4, result[1].Value);
            Assert.AreEqual(3, result[2].Value);
            Assert.AreEqual(9, result[3].Value);
            Assert.AreEqual(5, result[4].Value);
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void BinarySearchTree_Inorder()
        {
            BinarySearchTree tree = new BinarySearchTree();
            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(9);
            tree.Insert(1);
            tree.Insert(4);

            var result = tree.Inorder().ToList();
            Assert.AreEqual(5, result.Count);

            Assert.AreEqual(1, result[0].Value);
            Assert.AreEqual(4, result[1].Value);
            Assert.AreEqual(3, result[2].Value);
            Assert.AreEqual(5, result[3].Value);
            Assert.AreEqual(9, result[4].Value);

        }
    }
}