using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Tree
{
    class BinaryTree<T> : IBinaryTree<T> where T : IComparable
    {
        public Node<T> Root;

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
                Parent = Current;
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
            if (Find(key, out Node<T> Current, out Node<T> Parent, out bool IsLeftChild))
            {
                // 1-ый случай: удаление листового узла
                if (Current.LeftChild == null && Current.RightChild == null)
                {
                    if (Current == Root)
                        Root = null;
                    else if (IsLeftChild)
                        Parent.LeftChild = null;
                    else
                        Parent.RightChild = null;
                }

                // 2-ой случай: удаление узла с одним потомком
                else if (Current.RightChild == null)            // если нет правого потомка, то узел заменяется левым поддеревом
                {
                    if (Current == Root)                        // если корень
                        Root = Current.LeftChild;
                    else if (IsLeftChild)                       // если узел левый потомок родителя
                        Parent.LeftChild = Current.LeftChild;
                    else                                        // если узел правый потомок родителя
                        Parent.RightChild = Current.LeftChild;
                }
                else if (Current.LeftChild == null)             // если нет левого потомка, то узел заменяется правым поддеревом
                {
                    if (Current == Root)                        // если корень
                        Root = Current.RightChild;
                    else if (IsLeftChild)                       // если узел левый потомок родителя
                        Parent.LeftChild = Current.RightChild;
                    else                                        // если узел правый потомок родителя
                        Parent.RightChild = Current.RightChild;
                }

                // 3-й случай: удаление узла с двумя потомками
                // заменяем узел преемником
                else
                {
                    // Поиск преемника для удаляемого узла (current)
                    // Преемник не может иметь левого потомка (следует из определения)
                    Node<T> Successor = GetSuccessor(Current, out Node<T> SuccessorParent);
                    Current.data = Successor.data;

                    // если преемник левый потомок
                    // если преемник имеет потомка, то это может быть только правый потомок
                    if (Successor != Current.RightChild)
                        SuccessorParent.LeftChild = Successor.RightChild;
                    else
                        Current.RightChild = Successor.RightChild;
                }

            }
            else return;
        }

        private Node<T> GetSuccessor(Node<T> RemoveNode, out Node<T> SuccessorParent)
        {
            Node<T> Successor, Current;
            SuccessorParent = Successor = RemoveNode;
            Current = RemoveNode.RightChild;            // Переход к правому потомку

            while (Current != null)                     // Пока остаются левые потомки
            {
                SuccessorParent = Successor;
                Successor = Current;
                Current = Current.LeftChild;            // Переход к левому потомку
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
        public void InOrder(Node<T> node)
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
