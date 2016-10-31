using System;
using System.Threading.Tasks;

namespace Raupjc_dz2_zad7
{
    class Class1
    {
        private static void Main(string[] args)
        {
            // Main method is the only method that
            // can ’t be marked with async .
            // What we are doing here is just a way for us to simulate
            // async - friendly environment you usually have with
            // other .NET application types ( like web apps , win apps etc .)
            // Ignore main method , you can just focus on LetsSayUserClickedAButtonOnGuiMethod() as a
            // first method in call hierarchy .
            var t = Task.Run(() => LetsSayUserClickedAButtonOnGuiMethod());
            Console.Read();
        }

        private static void LetsSayUserClickedAButtonOnGuiMethod()
        {
            var result = GetTheMagicNumber();
            Console.WriteLine(result);
        }

        private static int GetTheMagicNumber()
        {
            return IKnowIGuyWhoKnowsAGuy().Result;
        }

        private static async Task<int> IKnowIGuyWhoKnowsAGuy()
        {
            var t1 = IKnowWhoKnowsThis(10);
            var t2 = IKnowWhoKnowsThis(5);
            await Task.WhenAll(t1, t2);
            return t1.Result + t2.Result;
        }

        private static async Task<int> IKnowWhoKnowsThis(int n)
        {
            return await Program.FactorialDigitSum(n);
        }
    }
}
