using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class AVL<T> : BST<T> where T : IComparable<T>
    {
        public int BalanceFactor { get; protected set; } = 0;
        public AVL(T value) : base(value) {
            
        }
        public AVL() { }
        private int _GetBalanceFactor(BinarySearchTreeNode<T> node)
        {
            if (node == null) return 0;
            return Depth(node?.Left) - Depth(node?.Right);
        }
        
        private void _RR(ref BinarySearchTreeNode<T> current)
        {
            if (current == null || current.Left == null) return;
            var newRoot = current.Left;
            current.Left = newRoot.Right;
            newRoot.Right = current;
            current = newRoot;

        }
        private void _LL(ref BinarySearchTreeNode<T>? current)
        {
            if (current == null || current.Right == null) return;
            var newRoot = current.Right;
            current.Right = newRoot.Left;
            newRoot.Left = current;
            current = newRoot;

        }
        private void _RL(ref BinarySearchTreeNode<T> current)
        {
            if (current == null) return;
            _LL(ref current.Left);
            _RR(ref current);

        }
        private void _LR(ref BinarySearchTreeNode<T> current)
        {
            if (current == null) return;
            _RR(ref current.Right);
            _LL(ref current);

        }
        void _BalanceTree(ref BinarySearchTreeNode<T> node, int PrevBF)
        {
            if (node == null) return;


            int BF = _GetBalanceFactor(node);
            _BalanceTree(ref node.Left, BF);
            _BalanceTree(ref node.Right, BF);
            if(PrevBF > 1 || PrevBF < -1)
            {
                if (PrevBF > 1) _LR(ref node);
                else _RL(ref node);
            }
            else
            {
                if (BF > 1) _RR(ref node);
                else if (BF < -1) _LL(ref node);
            }

        }
        public override void Insert(T value)
        {
            base.Insert(value);
            _BalanceTree(ref Root, 0);
            BalanceFactor = _GetBalanceFactor(Root);
        }
        public override void Delete(T value)
        {
            base.Delete(value);
            _BalanceTree(ref Root, 0);
            BalanceFactor = _GetBalanceFactor(Root);
        }
    }
}
