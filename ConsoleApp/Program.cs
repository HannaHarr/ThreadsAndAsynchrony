using System;
using System.Threading;
using ThreadsLibrary;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var threads = new Thread[10];

            for (var i = 0; i < 10; i++)
            {
                threads[i] = new Thread(Worker.DoWork);
                var msg = threads[i].ManagedThreadId;
                threads[i].Start(msg);
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            Console.ReadKey(true);
        }
    }
}
