namespace DataStructure
{
    public class BST<T> where T : IComparable<T>
    {
        public class Node
        {
            public T Value;
            public Node? Left;
            public Node? Right;
            public Node(T value)
            {
                Value = value;
                Left = null;
                Right = null;
            }
        }
        Node? Root = null;

        public BST()
        {
            Root = null;
        }
        public BST(T value)
        {
            Root = new Node(value);
        }


        public void Insert(T value)
        {
            if (Root == null)
            {
                Root = new Node(value);
            }
            else
            {
                _Insert(ref Root, value);
            }
        }
        private void _Insert(ref Node? node, T value)
        {
            if (node == null)
            {
                node = new Node(value);
                return;
            }

            if (value.CompareTo(node.Value) < 0)
                _Insert(ref node.Left, value);
            else if (value.CompareTo(node.Value) > 0)
                _Insert(ref node.Right, value);

        }


        private void _PrintBST(Node? node)
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
    }
}
