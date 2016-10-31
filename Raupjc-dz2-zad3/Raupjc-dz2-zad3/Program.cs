using System;
using System.Linq;

namespace Raupjc_dz2_zad3
{
    class Program
    {
        public static string Print(int a, int b)
        {
            return "Broj "+a+" ponavlja se "+b+" puta";
        }

        public static void Main(string[] args)
        {
            int[] integers = new[] { 1, 2, 2, 2, 3, 3, 4, 5 };

            var temp = integers.GroupBy(i => i)
                               .Distinct()
                               .ToArray();

            string[] strings= new string[temp.Length];

            foreach (var n in temp)
            {
                strings[n.Key-1]= Print(n.Key, n.Count());
                Console.WriteLine(strings[n.Key - 1]);
            }

        }
    }
}
