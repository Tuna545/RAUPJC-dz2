using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Raupjc_dz2_zad6
{
    class Program
    {
        private static object _lock = new object();

        public static void LongOperation(string taskName)
        {
            Thread.Sleep(1000);
            Console.WriteLine("{0} Finished . Executing Thread : {1}", taskName,
            Thread.CurrentThread.ManagedThreadId);
        }

        public static void Main()
        {
        
            List<int> results = new List<int>();
            Parallel.For(0, 100, (i) =>
            {
                Thread.Sleep(1);
                lock (_lock)
                {
                    results.Add(i*i);
                }
            });
            Console.WriteLine("Bag length should be 100. Length is {0}", results.Count);
        }
    }
}
