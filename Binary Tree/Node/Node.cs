using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Tree
{
    class Node<T> : INode<T>
    {
        public T data;
        public Node<T> LeftChild;
        public Node<T> RightChild;
    }
}
