using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek1
{
    public class BSTree
    {
        public Node Root { get; set; }
        public BSTree()
        {
            Root = null;
        }

        public void Insert(Node newNode)
        {
            Root = Insert(Root, newNode);
        }
        private Node Insert(Node node, Node newNode)
        {
            if (node == null) node = newNode;
            else
            {
                if (node.MinSeverity > newNode.MinSeverity)
                {
                    node.Left = Insert(node.Left, newNode);
                }
                else 
                {
                    node.Right = Insert(node.Right, newNode);
                }
            }
            return node;

        }
        public void PrintTree()
        {
            PrintTree(Root, "", "Root");
        }
        private void PrintTree(Node node, string shift, string type)
        {
            if (node != null)
            {
                Console.WriteLine($"{shift}{type}{node}");
                PrintTree(node.Left,shift += "  ","Left Child: ");
                PrintTree(node.Right, shift += "  ", "Right Child: ");
            }

        }

        public List<string> Search(int severity)
        {
            return Search(Root, severity);
        }

        
        
        
        private List<string> Search(Node node, int severity)
        {
            if (node == null)
                return new List<string>();

            if (node.MinSeverity <= severity && node.MaxSeverity >= severity)
                return node.Defenses;

            var leftResult = Search(node.Left, severity);

            if (leftResult.Count > 0)
                return leftResult;

            return Search(node.Right, severity);
        }
        public int FindMinSeverity()
        {
            return FindMinSeverity(Root);
        }
        public int FindMinSeverity(Node node)
        {
            if (node == null)
                return int.MaxValue;
            return node.Left == null ? node.MinSeverity : FindMinSeverity(node.Left);
        }
        public List<Node> InOrder()
        {
            List<Node> nodes = new List<Node>();
            return InOrder(Root, nodes);
        }
        public List<Node> InOrder(Node node, List<Node> nodes)
        {
            if (node != null)
            {
                nodes = InOrder(node.Left, nodes);
                nodes = [.. nodes, node];
                nodes = InOrder(node.Right, nodes);
            }
            return nodes;
        }

        public List<Node> PreOrder()
        {
            List<Node> nodes = new List<Node>();
            return PreOrder(Root, nodes);
        }
        public List<Node> PreOrder(Node node, List<Node> nodes)
        {
            if (node != null)
            {
                nodes = [.. nodes, node];
                nodes = PreOrder(node.Left, nodes);
                nodes = PreOrder(node.Right, nodes);
            }
            return nodes;
        }
        public int GetHeight(Node node)
        {
            if (node == null) return -1;
            if (node.Right == null && node.Left == null) return 0;
            int rightHeight = GetHeight(node.Right) + 1;
            int leftHeight = GetHeight(node.Left) + 1;
            return leftHeight > rightHeight ? leftHeight : rightHeight;

        }
        public bool IsBalanced()
        {
            return IsBalanced(Root) != -1;
        }

        private int IsBalanced(Node node)
        {
            if (node == null) return 0;
            if (node.Right == null && node.Left == null) return 0;
            int rightHeight = GetHeight(node.Right) + 1;
            if (rightHeight == -1) return -1;
            int leftHeight = GetHeight(node.Left) + 1;
            if (leftHeight == -1) return -1;
            return Math.Abs(rightHeight - leftHeight) > 1 ? -1 : Math.Abs(rightHeight - leftHeight);
        }
        public void Balance()
        {
            if (IsBalanced()) return;
            List<Node> inOrderTree = InOrder();
            Root = Balance(inOrderTree);
        }
        public Node Balance(List<Node> inOrderTree)
        {
            if (inOrderTree.Count == 0) return null;
            int half = inOrderTree.Count / 2;
            Node node = inOrderTree[half];
            Node newNode = new Node(node.MinSeverity, node.MaxSeverity, node.Defenses);
            newNode.Left = Balance(inOrderTree.Take(half).ToList());
            newNode.Right = Balance(inOrderTree.Skip(half + 1).ToList());
            return newNode;

        }
        public void Remove(Node node) { Root = Remove(Root, node); }
        private Node Remove(Node node, Node deleteNode)
        {
            if (node == null) return node;
            if (node.MinSeverity > deleteNode.MinSeverity)
            {
                node.Left = Remove(node.Left, deleteNode);
            }
            else if (node.MinSeverity < deleteNode.MinSeverity)
            {
                node.Right = Remove(node.Right, deleteNode);
            }
            else 
            {
                if (node.Right == null && node.Left == null)
                {
                    node = null;
                }
                else if (node.Right == null)
                {
                    node = node.Left;
                }
                else if (node.Left == null)
                {
                    node = node.Right;
                }
                else
                {
                    Node minNode = FindMin(node.Right);
                    node.MinSeverity = minNode.MinSeverity;
                    node.MaxSeverity = minNode.MaxSeverity;
                    node.Defenses = minNode.Defenses;
                    node.Right = Remove(node.Right, minNode);
                }
            }
            return node;
        }
        private Node FindMin(Node node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }
            return node;
        }
        



    }
}
