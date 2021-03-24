using System;
using System.Threading;

namespace ThreadsLibrary
{
    public class Worker
    {
        private static readonly Random random = new Random();

        private static readonly object locker = new object();

        private static SpinLock spinLock = new SpinLock();

        private static int counter = 0;

        public static void DoWork(object msg)
        {
            Thread.Sleep(random.Next(1, 4) * 300);

            for (var i = 0; i < 3; i++)
            {
                // LockWriteMessage(msg, i);
                SpinLockWriteMessage(msg, i);
            }

            Interlocked.Increment(ref counter);
        }

        private static void LockWriteMessage(object msg, int iteration)
        {
            lock (locker)
            {
                Console.WriteLine($"Message: {msg}; Counter: {counter}; Inner iteration number: {iteration}");
            }
        }

        private static void SpinLockWriteMessage(object msg, int iteration)
        {
            bool lockTaken = false;

            try
            {
                spinLock.Enter(ref lockTaken);
                Console.WriteLine($"Message: {msg}; Counter: {counter}; Inner iteration number: {iteration}");
            }
            finally
            {
                if (lockTaken) spinLock.Exit(false);
            }
        }
    }
}
