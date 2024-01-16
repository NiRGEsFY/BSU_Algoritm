using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TreeNode<T>
    {
        public T Value { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }

        public TreeNode(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }
    public class BinaryTree<T>
    {
        public TreeNode<T> Root { get; private set; }

        public BinaryTree(T rootValue)
        {
            Root = new TreeNode<T>(rootValue);
        }

        public void Insert(T value)
        {
            Root = InsertRec(Root, value);
        }

        private TreeNode<T> InsertRec(TreeNode<T> node, T value)
        {
            if (node == null)
            {
                node = new TreeNode<T>(value);
                return node;
            }

            int comparison = Comparer<T>.Default.Compare(value, node.Value);
            if (comparison < 0)
            {
                node.Left = InsertRec(node.Left, value);
            }
            else if (comparison > 0)
            {
                node.Right = InsertRec(node.Right, value);
            }
            return node;
        }

        public bool Contains(T value)
        {
            return ContainsRec(Root, value);
        }

        private bool ContainsRec(TreeNode<T> node, T value)
        {
            if (node == null) return false;

            int comparison = Comparer<T>.Default.Compare(value, node.Value);
            if (comparison == 0) return true;

            return comparison < 0 ? ContainsRec(node.Left, value) : ContainsRec(node.Right, value);
        }

        public void Remove(T value)
        {
            Root = RemoveRec(Root, value);
        }

        private TreeNode<T> RemoveRec(TreeNode<T> node, T value)
        {
            if (node == null) return node;

            int comparison = Comparer<T>.Default.Compare(value, node.Value);
            if (comparison < 0)
            {
                node.Left = RemoveRec(node.Left, value);
            }
            else if (comparison > 0)
            {
                node.Right = RemoveRec(node.Right, value);
            }
            else
            {
                if (node.Left == null) return node.Right;
                else if (node.Right == null) return node.Left;

                node.Value = MinValue(node.Right);

                node.Right = RemoveRec(node.Right, node.Value);
            }
            return node;
        }

        private T MinValue(TreeNode<T> node)
        {
            T minValue = node.Value;
            while (node.Left != null)
            {
                minValue = node.Left.Value;
                node = node.Left;
            }
            return minValue;
        }

        public void PreOrderTraversal(Action<T> visit)
        {
            PreOrderTraversalRec(Root, visit);
        }

        private void PreOrderTraversalRec(TreeNode<T> node, Action<T> visit)
        {
            if (node != null)
            {
                visit(node.Value);
                PreOrderTraversalRec(node.Left, visit);
                PreOrderTraversalRec(node.Right, visit);
            }
        }
        public void InOrderTraversal(Action<T> visit)
        {
            InOrderTraversalRec(Root, visit);
        }

        private void InOrderTraversalRec(TreeNode<T> node, Action<T> visit)
        {
            if (node != null)
            {
                InOrderTraversalRec(node.Left, visit);
                visit(node.Value);
                InOrderTraversalRec(node.Right, visit);
            }
        }
        public void PostOrderTraversal(Action<T> visit)
        {
            PostOrderTraversalRec(Root, visit);
        }

        private void PostOrderTraversalRec(TreeNode<T> node, Action<T> visit)
        {
            if (node != null)
            {
                PostOrderTraversalRec(node.Left, visit);
                PostOrderTraversalRec(node.Right, visit);
                visit(node.Value);
            }
        }

    }


}
