namespace Tournament_tree
{
    class Node
    {
        public int Value { get; set; }
        public Node Winner { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(Node left, Node right)
        {
            Value = left.Value > right.Value ? left.Value : right.Value;
            Left = left;
            Right = right;
        }

        public Node(int value)
        {
            Value = value;
        }

        public void Replay()
        {
            Value = Left.Value > Right.Value ? Left.Value : Right.Value;
            if(Winner != null)
            Winner.Replay();
        }
    }
}
