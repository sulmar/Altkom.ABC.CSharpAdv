using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Altkom.ABC.CSharpAdv.ConsoleClient
{
    class LockTests
    {
        private static Queue<int> queue = new Queue<int>();

        public static void Test()
        {
            Thread t1 = new Thread(Increment);

            Thread t2 = new Thread(Decrement);

            Thread t3 = new Thread(Decrement);

            t1.Start();
           Thread.Sleep(TimeSpan.FromSeconds(0.1));

            t2.Start();
            t3.Start();


            Console.ReadKey();
        }

        private static object syncLock = new object();

        private static void Increment()
        {
            for (int i = 0; i < 1000; i++)
            {
                lock (syncLock)
                {
                    Console.WriteLine($"Enqueue {i}");
                    queue.Enqueue(i);
                }
                
            }
        }

        private static void Decrement()
        {
            for (int i = 1000; i > 0; i--)
            {
                lock (syncLock)
                {
                    if (queue.Count > 0)
                    {
                        var x = queue.Dequeue();
                        Console.WriteLine($"Dequeue {x}");
                    }
                }
                
            }
        }
    }

    
}
