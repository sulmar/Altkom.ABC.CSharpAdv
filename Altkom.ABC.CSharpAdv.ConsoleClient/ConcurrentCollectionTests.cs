﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Altkom.ABC.CSharpAdv.ConsoleClient
{
    class ConcurrentCollectionTests
    {

        public static void Test()
        {
            BlockingCollectionTest();
        }

        private static void BlockingCollectionTest()
        {
            BlockingCollection<int> measures = new BlockingCollection<int>();

            Task.Run(() => Produce(measures));
            Task.Run(() => Produce(measures));
            Task.Run(() => Consume(measures));

            Console.WriteLine("Press any key to complete");

            Console.ReadKey();

            measures.CompleteAdding();
            

        }

        private static void Produce(BlockingCollection<int> measures)
        {
            Random random = new Random();

            while(!measures.IsAddingCompleted)
            {
                int measure = random.Next(0, 100);
                measures.Add(measure);

                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} sent {measure}");
                Console.ResetColor();

                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }

        private static void Consume(BlockingCollection<int> measures)
        {
            foreach (int measure in measures.GetConsumingEnumerable())
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} received {measure}");
                Console.ResetColor();

                Thread.Sleep(TimeSpan.FromSeconds(2));
            }

            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Finished.");

        }
    }
}
