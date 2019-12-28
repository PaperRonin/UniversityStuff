using System;
using System.Collections.Generic;

namespace Tournament_tree
{
    class TournamentTree
    {
        Node _root = null;
        List<Node> internalNodes = new List<Node>();
        #region Constructor
        public TournamentTree(List<int> array)
        {
            InsertArray(array);
        }
        #endregion
        public void Insert(int item)
        {
            internalNodes.Add(new Node(item));
            SetTT();
        }

        public void InsertArray(List<int> array)
        {
            foreach (var item in array)
            {
                internalNodes.Add(new Node(item));
            }
            SetTT();
        }

        private void SetTT()
        {
            Queue<Node> pastLevelNodes = new Queue<Node>();
            foreach (var item in internalNodes)
            {
                pastLevelNodes.Enqueue(item);
            }

            Node left, right, winner;
            for (int i = 0; i < Math.Ceiling(Math.Log(internalNodes.Count, 2)); i++)
            {
                Queue<Node> curLevelNodes = new Queue<Node>();
                while (pastLevelNodes.Count > 0)
                {
                    left = pastLevelNodes.Dequeue();
                    if (pastLevelNodes.Count > 0)
                    {
                        right = pastLevelNodes.Dequeue();
                    }
                    else right = new Node(int.MinValue);

                    winner = new Node(left, right);
                    left.Winner = winner;
                    right.Winner = winner;
                    curLevelNodes.Enqueue(winner);
                }
                pastLevelNodes = curLevelNodes;
            }
            _root = pastLevelNodes.Dequeue();
        }

        public int Max() => _root.Value;

        public int SecondMax()
        {
            int sM;
            if (_root.Value == _root.Left.Value)
            {
                sM = _root.Left.Left.Value != _root.Value ? _root.Left.Left.Value : _root.Left.Right.Value;
                sM = _root.Right.Value > sM ? _root.Right.Value : sM;
            }
            else
            {
                sM = _root.Right.Left.Value != _root.Value ? _root.Right.Left.Value : _root.Right.Right.Value;
                sM = _root.Left.Value > sM ? _root.Left.Value : sM;
            }

            return sM;
        }

        public void ChangeKey(int key, int changeTo)
        {
            Node nodeToDecrease = internalNodes.Find(x => x.Value == key);
            nodeToDecrease.Value = changeTo;
            nodeToDecrease.Winner.Replay();
        }

        public int LazyExtractMax()
        {
            int temp = _root.Value;
            ChangeKey(temp, int.MinValue);
            return temp;
        }

        public int ExtractMax()
        {
            Node temp = internalNodes.Find(x => x.Value == _root.Value);
            internalNodes.Remove(temp);
            SetTT();
            return temp.Value;
        }

        static public TournamentTree MergeTrees(TournamentTree first, TournamentTree second)
        {
            TournamentTree newTT = first._root.Value > second._root.Value ? first : second;
            TournamentTree oldTT = first._root.Value > second._root.Value ? second : first;

            foreach (var item in oldTT.internalNodes)
            {
                newTT.internalNodes.Add(item);
            }
            newTT.SetTT();
            return newTT;
        }
    }
}
