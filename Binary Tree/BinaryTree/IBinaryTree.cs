using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Tree
{
    interface IBinaryTree<T>
    {
        Node<T> Find(T key);
        void Insert(T value);
        void Delete(T key);
    }
}
