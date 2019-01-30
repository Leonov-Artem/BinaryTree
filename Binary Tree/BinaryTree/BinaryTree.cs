using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Tree
{
    class BinaryTree<T> : IBinaryTree<T> where T : IComparable
    {
        private Node<T> Root;

        public Node<T> Find(T key)
        {
            Node<T> Current = Root;
            while(key.CompareTo(Current.data) != 0)
            {
                if (key.CompareTo(Current.data) < 0)
                    Current = Current.LeftChild;
                else
                    Current = Current.RightChild;

                if (Current == null) return null;
            }
            return null;
        }
        public void Insert(T value)
        {
            Node<T> NewNode = new Node<T>();
            NewNode.data = value;

            if (Root == null)
                Root = NewNode;
            else
            {
                Node<T> Current = Root;
                Node<T> Parent;

                while(true)
                {
                    Parent = Current;

                    if (value.CompareTo(Current.data) < 0)
                    {
                        Current = Current.LeftChild;
                        if (Current == null)
                        {
                            Parent.LeftChild = NewNode;
                            return;
                        }
                    }
                    else
                    {
                        Current = Current.RightChild;
                        if (Current == null)
                        {
                            Parent.RightChild = NewNode;
                            return;
                        }
                    }
                }
            }
        }
        public void Delete(T key)
        {
            
        }

        // симметричный обход дерева
        private void InOrder(Node<T> node)
        {
            if (node != null)
            {
                InOrder(node.LeftChild);
                Console.WriteLine(node.data);
                InOrder(node.RightChild);
            }
        }
        // обход дерева в прямом порядке
        private void PreOrder(Node<T> node)
        {
            Console.WriteLine(node.data);
            PreOrder(node.LeftChild);
            PreOrder(node.RightChild);
        }
        // обход дерева в обратном порядке
        private void PostOrder
    }
}
