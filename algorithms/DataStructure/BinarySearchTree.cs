using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms.DataStructure
{
    public class BinarySearchTree
    {
        public TreeNode Root { get; private set; }

        public void Insert(int value)
        {
            var node = new TreeNode(value);
            if(Root == null)
            {
                Root = node;
            }
            else
            {
                RecursiveInsert(Root, value);
            }
        }

        private void RecursiveInsert(TreeNode seed, int value)
        {
            if (seed == null)
            {
                return;
            }

            if (seed.Value > value)
            {
                if (seed.LeftNode == null)
                {
                    seed.LeftNode = new TreeNode(value);
                }
                else
                {
                    RecursiveInsert(seed.LeftNode, value);
                }
            }


            if (seed.Value <= value)
            {
                if (seed.RightNode == null)
                {
                    seed.RightNode = new TreeNode(value);
                }
                else
                {
                    RecursiveInsert(seed.RightNode, value);
                }
            }
        }

        public bool Contains(int value)
        {
            return Search(Root, value);
        }

        private bool Search(TreeNode seed, int value)
        {
            if(seed == null)
            {
                return false;
            }

            if (seed.Value > value)
            {
                return Search(seed.LeftNode, value);
            }
            else if (seed.Value < value)
            {
                return Search(seed.RightNode, value);
            }
            else
            {
                return true;
            }
        }

        public bool Delete(int value)
        {
            if (Root != null && Root.Value == value)
            {
                if (Root.RightNode != null)
                {
                    Root.RightNode.LeftNode = Root.LeftNode;
                    Root = Root.RightNode;
                }
                else
                {
                    Root = Root.LeftNode;
                }
                return true;
            }

            return DeleteLeaf(Root, value);
        }
        private bool DeleteLeaf(TreeNode parent, int value)
        {
            if (parent == null)
            {
                return false;
            }
            if(parent.LeftNode.Value == value)
            {
                RemoveNode(parent.LeftNode, parent);
                return true;
            }
            else if(parent.RightNode.Value == value)
            {
                RemoveNode(parent.RightNode, parent);
                return true;
            }

            if (parent.Value > value)
            {
                return DeleteLeaf(parent.LeftNode, value);
            }
            else if (parent.Value < value)
            {
                return DeleteLeaf(parent.RightNode, value);
            }

            return false;

        }

        private void RemoveNode(TreeNode child, TreeNode parent)
        {
            if (child.LeftNode == null && child.RightNode == null)
            {
                ReplaceNode(child, parent, null);
                return;
            }

            if (child.RightNode != null)
            {
                child.RightNode.LeftNode = child.LeftNode;
                ReplaceNode(child, parent, child.RightNode);
            }
            else
            {
                ReplaceNode(child, parent, child.LeftNode);
            }
        }

        private void ReplaceNode(TreeNode child, TreeNode parent, TreeNode newChild)
        {
            if (child.Value == parent.LeftNode.Value)
            {
                parent.LeftNode = newChild;
            }
            else if (child.Value == parent.RightNode.Value)
            {
                parent.RightNode = newChild;
            }
        }

        public int? FindMinValue(TreeNode root)
        {
            if(root == null)
            {
                return null;
            }
            if(root.LeftNode == null)
            {
                return root.Value;
            }
            else
            {
                return FindMinValue(root.LeftNode);
            }
        }

        public int? FindMaxValue(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }
            if (root.RightNode == null)
            {
                return root.Value;
            }
            else
            {
                return FindMaxValue(root.RightNode);
            }
        }

        public IEnumerable<TreeNode> Preorder()
        {
            var result = new List<TreeNode>();
            PreorderTravel(Root, result);
            return result;
        }

        private void PreorderTravel(TreeNode seed, IList<TreeNode> travelledNodes)
        {
            if (seed != null)
            {
                travelledNodes.Add(seed);
            }

            if (seed.LeftNode != null)
            {
                PreorderTravel(seed.LeftNode, travelledNodes);
            }

            if (seed.RightNode != null)
            {
                PreorderTravel(seed.RightNode, travelledNodes);
            }
        }

        public IEnumerable<TreeNode> Postorder()
        {
            var result = new List<TreeNode>();
            PostorderTravel(Root, result);
            return result;
        }


        private void PostorderTravel(TreeNode seed, IList<TreeNode> travelledNodes)
        {

            if (seed.LeftNode != null)
            {
                PostorderTravel(seed.LeftNode, travelledNodes);
            }

            if (seed.RightNode != null)
            {
                PostorderTravel(seed.RightNode, travelledNodes);
            }

            if (seed != null)
            {
                travelledNodes.Add(seed);
            }
        }

        public IEnumerable<TreeNode> Inorder()
        {
            var result = new List<TreeNode>();
            InorderTravel(Root, result);
            return result;
        }


        private void InorderTravel(TreeNode seed, IList<TreeNode> travelledNodes)
        {
            if (seed.LeftNode != null)
            {
                PostorderTravel(seed.LeftNode, travelledNodes);
            }

            if (seed != null)
            {
                travelledNodes.Add(seed);
            }

            if (seed.RightNode != null)
            {
                PostorderTravel(seed.RightNode, travelledNodes);
            }
        }
    }

    public class TreeNode
    {
        public TreeNode()
        {
        }

        public TreeNode(int value)
        {
            Value = value;
        }

        public TreeNode LeftNode { get; set; }

        public TreeNode RightNode { get; set; }

        public int Value { get; set; }
    }
}
