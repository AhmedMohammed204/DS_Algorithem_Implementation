using System;
using DataStructure;
namespace C23
{
    class Program
    {
        static void Main(string[] args)
        {
            AVL<int> root = new AVL<int>();
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