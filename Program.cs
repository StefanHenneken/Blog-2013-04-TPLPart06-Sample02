using System;
using System.Threading.Tasks;

namespace Sample02
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Run();
        }
        public void Run()
        {
            Console.WriteLine("Start Run");

            double result01 = 0;
            for (int i = 1; i < 10000; i++)
            {
                result01 = result01 + DoSomeWork(i);
            }
            Console.WriteLine("Result: {0}", result01);

            double result02 = 0;
            object locker = new Object();
            Parallel.For(1, 10000, (i) =>
            {
                lock (locker)
                {
                    result02 = result02 + DoSomeWork(i);
                }
            });
            Console.WriteLine("Result: {0}", result02);

            Console.WriteLine("End Run");
            Console.ReadLine();
        }
        private double DoSomeWork(int index)
        {
            return Math.Sin(index) + Math.Sqrt(index) * Math.Pow(index, 0.14);
        }
    }
}
