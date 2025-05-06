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
        private int _GetBalanceFactor(BinarySearchTreeNode<T>? node)
        {
            if (node == null) return 0;
            return Depth(node?.Left) - Depth(node?.Right);
        }
        
        private void _RightRotation(ref BinarySearchTreeNode<T> current)
        {
            if (current == null || current.Left == null) return;
            var newRoot = current.Left;
            current.Left = newRoot.Right;
            newRoot.Right = current;
            current = newRoot;

        }
        private void _LeftRotation(ref BinarySearchTreeNode<T>? current)
        {
            if (current == null || current.Right == null) return;
            var newRoot = current.Right;
            current.Right = newRoot.Left;
            newRoot.Left = current;
            current = newRoot;

        }
        void _BalanceTree(ref BinarySearchTreeNode<T>? node)
        {
            if (node == null) return;

            _BalanceTree(ref node.Left);
            _BalanceTree(ref node.Right);

            int bf = _GetBalanceFactor(node);

            if (bf > 1)
            {
                if (_GetBalanceFactor(node.Left) < 0)
                    _LeftRotation(ref node.Left);
                _RightRotation(ref node);
            }
            else if (bf < -1)
            {
                if (_GetBalanceFactor(node.Right) > 0)
                    _RightRotation(ref node.Right);
                _LeftRotation(ref node);
            }

        }

        public override void Insert(T value)
        {
            base.Insert(value);
            _BalanceTree(ref Root);
            BalanceFactor = _GetBalanceFactor(Root);
        }
        public override void Delete(T value)
        {
            base.Delete(value);
            _BalanceTree(ref Root);
            BalanceFactor = _GetBalanceFactor(Root);
        }
    }
}
