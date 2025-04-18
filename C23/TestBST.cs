using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructure;

namespace TestDS
{
    internal static class TestBST
    {
        public static void Inserion()
        {
            BST<int> bst = new BST<int>();
            bst.Insert(45);
            bst.Insert(15);
            bst.Insert(79);
            bst.Insert(90);
            bst.Insert(10);
            bst.Insert(55);
            bst.Insert(12);
            bst.Insert(20);
            bst.Insert(50);

            bst.PrintBST();
        }

        public static void Search()
        {
            BST<int> bst = new BST<int>();
            bst.Insert(45);
            bst.Insert(15);
            bst.Insert(79);
            bst.Insert(90);
            bst.Insert(10);
            bst.Insert(55);
            bst.Insert(12);
            bst.Insert(20);
            bst.Insert(50);

            bst.PrintBST();
            BinarySearchTreeNode<int> ? n = bst.Find(15);
            if(n != null)
                Console.WriteLine("\n\n" + n.Value);
        }
    }
}
