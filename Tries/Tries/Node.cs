using System.Collections.Generic;

namespace Tries
{
    class Node<TValue>
    {
        public char Value { get; set; }
        public List<Node<TValue>> Children { get; set; }
        public Node<TValue> Parent { get; set; }
        public int Depth { get; set; }
        public TValue Container { get; set; }

        public Node(char value, int depth, Node<TValue> parent, TValue container = default(TValue))
        {
            Value = value;
            Children = new List<Node<TValue>>();
            Depth = depth;
            Parent = parent;
            Container = container;
        }

        public bool IsLeaf()
        {
            return Children.Count == 0;
        }

        public Node<TValue> FindChildNode(char c)
        {
            Node<TValue> child = Children.Find(x => x.Value == c);
                if (child != null)
                    return child;

            return null;
        }

        public void DeleteChildNode(char c)
        {
            for (var i = 0; i < Children.Count; i++)
                if (Children[i].Value == c)
                    Children.RemoveAt(i);
        }
    }
}
