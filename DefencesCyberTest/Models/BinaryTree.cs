using DefencesCyberTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefencesCyberTest
{
    internal class NodeValue
    {
        public int MinSeverity { get; set; }
        public int MaxSeverity { get; set; }
        public List<string> Defences { get; set; }
        public int Hight { get; set; } = 0;

        public override string ToString()
        {
            string result = string.Concat(Enumerable.Repeat("_", Hight));

            return $"{result} MinSeverity: {MinSeverity}, \n" +
                   $"      MaxSeverity: {MaxSeverity}, \n" +
                   $"      Defences: {string.Join(",", Defences)} \n" +
                   $"\n";
        }
    }


    internal class TreeNode
    {
        public NodeValue NodeValue { get; set; }
        public TreeNode? Left { get; set; }
        public TreeNode? Right { get; set; }

    }


    internal class BinaryTree
    {

        public TreeNode? root;

        public void Insert(NodeValue nodeValue)
        {
            root = InsertRecursive(root, nodeValue);
        }

        private TreeNode? InsertRecursive(TreeNode? node, NodeValue nodeValue)
        {

            nodeValue.Hight++;

            if (node == null)
            {
                return new TreeNode() { NodeValue = nodeValue };
            }

            else if (nodeValue.MaxSeverity < node.NodeValue.MinSeverity)
            {
                node.Left = InsertRecursive(node.Left, nodeValue);
            }

            else if (nodeValue.MinSeverity > node.NodeValue.MaxSeverity)
            {
                node.Right = InsertRecursive(node.Right, nodeValue);
            }
            return node;
        }

        public List<string> SearchByPreOrderTraversal(int severity) =>
            SearchByPreOrderTraversalRecursive(root, severity);

        private List<string> SearchByPreOrderTraversalRecursive(TreeNode? node, int severity)
        {
            if (node == null)
                return null; ;

            if (severity <= node?.NodeValue.MaxSeverity && severity >= node?.NodeValue.MinSeverity)
            {
                return node.NodeValue.Defences;
            }

            var checkInLeft = SearchByPreOrderTraversalRecursive(node?.Left, severity);
            if(checkInLeft != null)
            {
                return checkInLeft;
            }

            var checkInRight = SearchByPreOrderTraversalRecursive(node?.Right, severity);
            if(checkInRight != null)
            {
                return checkInRight;
            }
            return null;
        }


        public bool Search(NodeValue nodeValue)
        {
            return SearchRecursive(root, nodeValue);
        }

        public bool SearchRecursive(TreeNode? node, NodeValue nodeValue)
        {
            if (node == null)
            {
                return false;
            }

            if (node.NodeValue.MinSeverity == nodeValue.MinSeverity && node.NodeValue.MaxSeverity == nodeValue.MaxSeverity)
            {
                return true;
            }

            if (nodeValue.MinSeverity > node.NodeValue.MaxSeverity)
            {
                return SearchRecursive(node.Right, nodeValue);
            }

            else
            {
                return SearchRecursive(node.Left, nodeValue);
            }
        }

        private NodeValue FindMinOfNode(TreeNode node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }
            return node.NodeValue;
        }

        public void Delete(NodeValue nodeValue)
        {
            root = DeleteRecursive(root, nodeValue);
        }

        private TreeNode? DeleteRecursive(TreeNode? node, NodeValue nodeValue)
        {
            if (node == null)
            {
                return null;
            }

            if (nodeValue.MaxSeverity < node.NodeValue.MinSeverity)
            {
                node.Left = DeleteRecursive(node.Left, nodeValue);
            }

            if (nodeValue.MinSeverity > node.NodeValue.MaxSeverity)
            {
                node.Right = DeleteRecursive(node.Right, nodeValue);
            }

            else
            {
                if (node.Left == null && node.Right == null)
                {
                    return null;
                }

                else if (node.Left == null)
                {
                    return node.Right;
                }

                else if (node.Right == null)
                {
                    return node.Left;
                }

                else
                {
                    NodeValue min = FindMinOfNode(node);
                    node.NodeValue = min;
                    node.Right = DeleteRecursive(node.Right, min);
                }
            }
            return node;
        }

        public List<NodeValue> PreOrderTraversal() => PreOrderTraversalRecursive(root);

        private List<NodeValue> PreOrderTraversalRecursive(TreeNode? node)
        {
            if (node == null) { return []; }

            var currentNodeList = new List<NodeValue> { node.NodeValue };

            var leftSubtreeList = PreOrderTraversalRecursive(node.Left);

            var rightSubtreeList = PreOrderTraversalRecursive(node.Right);

            return [.. currentNodeList, .. leftSubtreeList, .. rightSubtreeList];
        }


        /*public void Delete(int minVeserity, int maxVeserity)
        {
            root = DeleteRecursive(root, minVeserity, maxVeserity);
        }

        private TreeNode? DeleteRecursive(TreeNode? node, int minVeserity, int maxVeserity)
        {
            if (node == null)
            {
                return null;
            }

            if (maxVeserity < node.NodeValue.MinSeverity)
            {
                node.Left = DeleteRecursive(node.Left, minVeserity, maxVeserity);
            }

            if (minVeserity > node.NodeValue.MaxSeverity)
            {
                node.Right = DeleteRecursive(node.Right, minVeserity, maxVeserity);
            }

            else
            {
                if (node.Left == null && node.Right == null)
                {
                    return null;
                }

                else if (node.Left == null)
                {
                    return node.Right;
                }

                else if (node.Right == null)
                {
                    return node.Left;
                }

                else
                {
                    int min = FindMinOfNode(node.Right);
                    node.Value = min;
                    node.Right = DeleteRecursive(node.Right, min);
                }
            }
            return node;
        }*/


    }
}
