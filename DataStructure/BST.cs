using System.Xml.Linq;

namespace DataStructure
{
    public class BinarySearchTreeNode<T>
    {
        public T Value;
        public BinarySearchTreeNode<T>? Left;
        public BinarySearchTreeNode<T>? Right;
        public BinarySearchTreeNode(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }
    public class BST<T> where T : IComparable<T>
    {

        protected BinarySearchTreeNode<T>? Root = null;

        public BST()
        {
            Root = null;
        }
        public BST(T value)
        {
            Root = new BinarySearchTreeNode<T>(value);
        }


        public virtual void Insert(T value)
        {
            if (Root == null)
            {
                Root = new BinarySearchTreeNode<T>(value);
            }
            else
            {
                _Insert(ref Root, value);
            }
        }
        protected void _Insert(ref BinarySearchTreeNode<T>? node, T value)
        {
            if (node == null)
            {
                node = new BinarySearchTreeNode<T>(value);
                return;
            }

            if (value.CompareTo(node.Value) < 0)
                _Insert(ref node.Left, value);
            else if (value.CompareTo(node.Value) > 0)
                _Insert(ref node.Right, value);

        }


        private void _PrintBST(BinarySearchTreeNode<T>? node)
        {
            if (node == null)
                return;


            _PrintBST(node.Left);
            Console.Write(node.Value + " ");
            _PrintBST(node.Right);

        }

        public void PrintBST()
        {
            _PrintBST(Root);
        }

        public BinarySearchTreeNode<T>? Find(T value)
        {
            return _Find(Root, value);
        }
        private BinarySearchTreeNode<T>? _Find(BinarySearchTreeNode<T>? node, T value)
        {
            if (node == null || value.Equals(node.Value)) return node;

            else if(value.CompareTo(node.Value) < 0)
                return _Find(node.Left, value);
            
            else
                return _Find(node.Right, value);

        }

        protected int Depth(BinarySearchTreeNode<T>? node)
        {
            if (node == null) return 0;

            int leftDepth = Depth(node.Left);
            int rightDepth = Depth(node.Right);

            return Math.Max(leftDepth, rightDepth) + 1;
        }
        public int Depth()
        {
            return Depth(Root);
        }
        public virtual void Delete(T value)
        {
            if(Root == null) return;
            else
            {
                _Delete(ref Root, value);
            }
        }
        private void _Delete(ref BinarySearchTreeNode<T> node, T value)
        {
            if(node == null) return;
            var cm = value.CompareTo(node.Value);
            if (cm > 0)
                _Delete(ref node.Right, value);
            else if(cm < 0)
                _Delete(ref node.Left, value);
            else
            {
                if (node.Left == null && node.Right == null)
                {
                    node = null;
                    return;
                }
                if (node.Left == null) node = node.Right;
                else if (node.Right == null) node = node.Left;
                else
                {
                    var temp = node.Left;
                    node = node.Right;
                    if (temp == null) return;
                    else if (node.Left == null) node.Left = temp;
                    node.Left.Left = temp;

                }

            }
        }
    
    
    }
}
