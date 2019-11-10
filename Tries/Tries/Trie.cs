using System;

namespace Tries
{
    class Trie<TValue> where TValue : IComparable
    {
        private readonly Node<TValue> _root;

        public Trie()
        {
            _root = new Node<TValue>('R', 0, null);
        }

        public Node<TValue> Prefix(string s)
        {
            var currentNode = _root;
            var result = currentNode;

            foreach (var c in s)
            {
                currentNode = currentNode.FindChildNode(c);
                if (currentNode == null)
                    break;
                result = currentNode;
            }

            return result;
        }

        public TValue Lookup(string s)
        {
            var prefix = Prefix(s);
            return prefix.Depth == s.Length && prefix.FindChildNode('$') != null ?
                prefix.FindChildNode('$').Container : default(TValue);
        }

        public void Insert(string s, TValue value)
        {
            var commonPrefix = Prefix(s);
            var current = commonPrefix;

            for (var i = current.Depth; i < s.Length; i++)
            {
                var newNode = new Node<TValue>(s[i], current.Depth + 1, current);
                current.Children.Add(newNode);
                current = newNode;
            }

            current.Children.Add(new Node<TValue>('$', current.Depth + 1, current, value));
        }

        public void Delete(string s)
        {
            if (Lookup(s) != null)
            {
                var node = Prefix(s).FindChildNode('$');

                while (node.IsLeaf() && node.Depth != 0)
                {
                    var parent = node.Parent;
                    parent.DeleteChildNode(node.Value);
                    node = parent;
                }
            }
        }

    }

}
