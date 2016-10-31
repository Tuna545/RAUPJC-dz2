using System.Linq;
using System.Threading.Tasks;

namespace Raupjc_dz2_zad7
{
    class Program
    {

        private static int Racunaj(int n)
        {
            int pom = 1;
            for (int i = 1; i <= n; i++)
                pom *= i;

            return pom;
        }

        //private static async void AsyncTemp()
        //{
        //    int n = Convert.ToInt32(Console.ReadLine());
        //    await FactorialDigitSum(5);
        //    await FactorialDigitSum(30);
        //    await FactorialDigitSum(25);
        //    await FactorialDigitSum(3);
        //    await FactorialDigitSum(n);
        //}

        public async static Task<int> FactorialDigitSum(int n)
        {
            
            Task<int> task = Task.Run(()=> (Racunaj(n).ToString().Sum(s=>s-'0')));
            await task;
            return task.Result;
        }

        //private static void Main()
        //{
        //    var task = Task.Run(() => AsyncTemp());
        //    Task.WaitAll(task);
        //}
    }
}
