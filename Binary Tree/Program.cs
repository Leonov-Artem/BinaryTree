using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>();
            binaryTree.Insert(60);
            binaryTree.Insert(35);
            binaryTree.Insert(76);
            binaryTree.Insert(42);
            binaryTree.Insert(17);
            binaryTree.Insert(68);
            binaryTree.Insert(11);
            binaryTree.Insert(24);
            binaryTree.Insert(63);
            binaryTree.Insert(69);
            binaryTree.Insert(23);

            binaryTree.Delete(35);
            binaryTree.InOrder(binaryTree.Root);

            //binaryTree.Insert(50);
            //binaryTree.Insert(75);
            //binaryTree.Insert(93);
            //binaryTree.Insert(87);
            //binaryTree.Insert(62);

            //binaryTree.Delete(75);
            //binaryTree.InOrder(binaryTree.Root);

            Console.ReadKey();
        }
    }
}
