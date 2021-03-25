using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncLibrary
{
    public static class Fibonacci
    {
        public static int Fib(int i)
        {
            Thread.Sleep(10);

            if (i == 1)
                return 0;

            if (i == 2)
                return 1;

            return Fib(i - 2) + Fib(i - 1);
        }

        public static async Task FibAsync()
        {
            var fib_5 = Task.Run(() => Fib(5));
            var fib_7 = Task.Run(() => Fib(7));
            var fib_11 = Task.Run(() => Fib(11));

            Console.WriteLine($"Fibonacci number 5 - { await fib_5 }");
            Console.WriteLine($"Fibonacci number 7 - { await fib_7 }");
            Console.WriteLine($"Fibonacci number 11 - { await fib_11 }");
        }
    }
}