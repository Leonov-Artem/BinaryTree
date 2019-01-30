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
            Node<T> current = Root;
            while(current.data.CompareTo(key) != 0)
            {
                if (key.CompareTo(current.data) < 0)
                    current = current.LeftChild;
                else
                    current = current.RightChild;

                if (current == null) return null;
            }
            return null;
        }
        public void Insert(T value)
        {

        }
        public void Delete(T key)
        {

        }
    }
}
