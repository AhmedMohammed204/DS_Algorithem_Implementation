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

        BinarySearchTreeNode<T>? Root = null;

        public BST()
        {
            Root = null;
        }
        public BST(T value)
        {
            Root = new BinarySearchTreeNode<T>(value);
        }


        public void Insert(T value)
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
        private void _Insert(ref BinarySearchTreeNode<T>? node, T value)
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

        
    }
}
