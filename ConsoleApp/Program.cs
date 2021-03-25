using System;
using System.Threading;
using System.Threading.Tasks;
using ThreadsLibrary;
using AsyncLibrary;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = Fibonacci.FibAsync();

            var actions = new Action[10];
            
            for (var i = 0; i < 10; i++)
            {
                actions[i] = () =>
                {
                    var msg = Thread.CurrentThread.ManagedThreadId;
                    Worker.DoWork(msg);
                };
            }

            Parallel.Invoke(actions);

            Console.ReadKey(true);
        }
    }
}
