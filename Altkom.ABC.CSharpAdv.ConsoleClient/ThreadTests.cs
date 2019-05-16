using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Altkom.ABC.CSharpAdv.ConsoleClient
{
    class ThreadTests
    {

        public static void Test()
        {
            Console.Clear();

            //int length = Download();
            //decimal amount = Calculate(length);
            //Console.WriteLine(amount);

            //SyncTest();

            //ThreadStartTest();

            //DonwloadTest();

            ThreadPoolTest();
        }

        private static void ThreadPoolTest()
        {
            ThreadPool.QueueUserWorkItem(Download, "http://www.altkom.pl");
            ThreadPool.QueueUserWorkItem(Download, "http://www.google.com");
            ThreadPool.QueueUserWorkItem(Download, "http://www.microsoft.com");

            for (int i = 0; i < 100; i++)
            {
                ThreadPool.QueueUserWorkItem(Download, "http://www.microsoft.com");
            }

            
        }

        private static void DonwloadTest()
        {
            Thread t1 = new Thread(() => Download("http://www.altkom.pl"));
            Thread t2 = new Thread(() => Download("http://www.google.com"));
            Thread t3 = new Thread(() => Download("http://www.microsoft.com"));

            t1.Start();
            t2.Start();
            t3.Start();

            for (int i = 0; i < 10; i++)
            {
                Thread t = new Thread(() => Download("http://www.microsoft.com"));
                t.Start();
            }
        }

        private static void SyncTest()
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Starting...");

            Send("Hello .NET");

            Send("Hello World");

            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Finished.");
        }

        private static void ThreadStartTest()
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Starting...");

            Thread thread = new Thread(() => Send("Hello .NET"));
            Thread thread2 = new Thread(() => Send("Hello World"));

            Console.WriteLine("Press any key to send");
            Console.ReadKey();

            thread.Start();
            thread2.Start();

            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Finished.");
        }

        private static void Send(string message)
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} {message} Sending...");

            Thread.Sleep(TimeSpan.FromSeconds(1));

            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} {message} Sent.");
        }

        private static void Download(object url)
        {
            Download((string) url);
        }

        private static void Download(string url)
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} {url} Downloading...");

            using (WebClient client = new WebClient())
            {
                string content = client.DownloadString(url);

                Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} {url} Downloaded {content.Length} ");
            }
        }
    }
}
