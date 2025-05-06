using System;
using DataStructure;
namespace C23
{
    class Program
    {
        static void Main(string[] args)
        {
            var avl = new AVL<int>();
            foreach (var x in new[] {0, 1, 2, 3, 4, 5 })
                avl.Insert(x);

            Console.ReadKey();
        }
    }
}