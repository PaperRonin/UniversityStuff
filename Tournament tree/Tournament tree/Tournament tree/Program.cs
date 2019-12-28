using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace Tournament_tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            List<int> MainArray = new List<int>();
            MainArray.Add(30);
            for (int i = 1; i <= 10000000; i++)
            {
                MainArray.Add(r.Next());
            }
            Stopwatch t = new Stopwatch();
            TournamentTree tT;
            TournamentTree treeToMerge = new TournamentTree(new List<int>() { -20,-65,-123,-1,-1233});

            t.Start();
            for (int i = 1000; i <= 10000000; i *= 10)
            {
                t.Restart();
                tT = new TournamentTree(MainArray.GetRange(0, i));
                t.Stop();
                Console.WriteLine($"Create:             " + t.Elapsed);

                t.Restart();
                tT.Max();
                t.Stop();
                Console.WriteLine($"Max:             " + t.Elapsed);

                t.Restart();
                tT.SecondMax();
                t.Stop();
                Console.WriteLine($"SecondMax:             " + t.Elapsed);

                t.Restart();
                tT.LazyExtractMax();
                t.Stop();
                Console.WriteLine($"ExtractMax:             " + t.Elapsed);

                t.Restart();
                tT.ChangeKey(30, 0);
                t.Stop();
                Console.WriteLine($"ChangeKey:             " + t.Elapsed);

                t.Restart();
                TournamentTree.MergeTrees(tT, treeToMerge);
                t.Stop();
                Console.WriteLine($"MergeTrees:             " + t.Elapsed);
                Console.WriteLine(new string('-',40));
            }
            Console.ReadKey();
        }
    }
}
