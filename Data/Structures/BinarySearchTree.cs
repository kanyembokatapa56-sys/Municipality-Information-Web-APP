using System;
using System.Collections.Generic;

namespace ST10265272_PROG7312_PortfolioOfEvidence.Data.Structures
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        public class Node
        {
            public T Data;
            public Node Left, Right;

            public Node(T data)
            {
                Data = data;
            }
        }

        public Node Root;

        public void Insert(T data)
        {
            Root = Insert(Root, data);
        }

        private Node Insert(Node node, T data)
        {
            if (node == null) return new Node(data);

            int comparison = data.CompareTo(node.Data);
            if (comparison < 0)
                node.Left = Insert(node.Left, data);
            else if (comparison > 0)
                node.Right = Insert(node.Right, data);

            return node;
        }

        public List<T> InOrderTraversal()
        {
            var result = new List<T>();
            InOrderTraversal(Root, result);
            return result;
        }

        private void InOrderTraversal(Node node, List<T> result)
        {
            if (node == null) return;

            InOrderTraversal(node.Left, result);
            result.Add(node.Data);
            InOrderTraversal(node.Right, result);
        }
    }
}
