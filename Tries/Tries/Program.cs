using System;

namespace Tries
{
    class Program
    {
        static void Main(string[] args)
        {
            Trie<string> T = new Trie<string>();
            T.Insert("waka", "boo");
            T.Insert("wakawaka", "ha-ha");
            Console.WriteLine(T.Lookup("waka"));
            T.Delete("waka");
            Console.WriteLine(T.Lookup("waka"));
            Console.WriteLine(T.Lookup("wakawaka"));
            T.Delete("waka");
            Console.ReadKey();
        }
    }
}
