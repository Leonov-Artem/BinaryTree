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
        private bool Find(T key, out Node<T> Current, out Node<T> Parent, out bool IsLeftChild)
        {
            Current = Parent = Root;
            IsLeftChild = true;

            while(key.CompareTo(Current.data) != 0)
            {
                if (key.CompareTo(Current.data) < 0)
                {
                    Current = Current.LeftChild;
                    IsLeftChild = true;
                }
                else
                {
                    Current = Current.RightChild;
                    IsLeftChild = false;
                }

                if (Current == null) return false;
            }
            return true;
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

        private Node<T> GetSuccessor(Node<T> RemoveNode)
        {
            Node<T> SuccessorParent, Successor, Current;

            SuccessorParent = Successor = RemoveNode;
            Current = RemoveNode.RightChild;            // Переход к правому потомку

            while (Current != null)                     // Пока остаются левые потомки
            {
                SuccessorParent = Successor;
                Successor = Current;
                Current = Current.LeftChild;            // Переход к левому потомку
            }
            // Если преемник не является
            // правым потомком,
            if (Successor != RemoveNode.RightChild)     
            { 
                // создать связи между узлами
                SuccessorParent.LeftChild = Successor.RightChild;
                Successor.RightChild = RemoveNode.RightChild;
            }
            return Successor;
        }
        /////////////////////////////////////////////////
        private Node<T> Minimun()
        {
            Node<T> Current = Root;
            Node<T> Min = null;

            while(Current != null)
            {
                Min = Current;
                Current = Current.LeftChild;
            }
            return Min;
        }
        private Node<T> Maximum()
        {
            Node<T> Current = Root;
            Node<T> Max = null;

            while (Current != null)
            {
                Max = Current;
                Current = Current.RightChild;
            }
            return Max;
        }
        /////////////////////////////////////////////////
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
        private void PostOrder(Node<T> node)
        {
            PostOrder(node.LeftChild);
            PostOrder(node.RightChild);
            Console.WriteLine(node.data);
        }
    }
}
