using System;
using DataStructure;
using TestDS;
namespace C23
{
    class Program
    {
        static void Main(string[] args)
        {
            AVL<int> root = new AVL<int>(30);
            root.Insert(10);
            root.Insert(50);
            root.Insert(60);
            root.Insert(70);
            root.Insert(80);

            //root.PrintBST();
            //Console.WriteLine(root.BalanceFactor);
            root.Delete(50);
            Console.ReadKey();
        }
    }
}