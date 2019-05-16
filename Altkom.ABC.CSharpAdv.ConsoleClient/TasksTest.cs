using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Altkom.ABC.CSharpAdv.ConsoleClient
{
    class TasksTest
    {

        public static void Test()
        {
            Console.Clear();

            // SyncTest();

            TaskTest();

            // StartTaskTest();

          //  StartNewTaskTest();
        }

        private static void SyncTest()
        {
            string content = Download("http://www.altkom.pl");

            Send(content);

            string content2 = Download("http://www.microsoft.com");

            Send(content2);

            Console.WriteLine("next job");
        }

        private static void TaskTest()
        {
            DownloadAsync("http://www.altkom.pl")
                .ContinueWith(t => SendAsync(t.Result))
                    .ContinueWith(t => "http://www.microsoft.com")
                        .ContinueWith(t => SendAsync(t.Result));

            Console.WriteLine("next job");

        }


        private static void StartNewTaskTest()
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Starting...");

            Task.Run(() => Send("Hello .NET"));
            Task task = Task.Run(() => Send("Hello World"));

            for (int i = 0; i < 100; i++)
            {
                Task.Run(() => Download("http://www.google.com"));
            }

            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Finished.");
        }

        private static void StartTaskTest()
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Starting...");

            Task task = new Task(() => Send("Hello .NET"));
            Task task2 = new Task(() => Send("Hello World"));

            Console.WriteLine("Press any key to start task");

            Console.ReadKey();

            task.Start();
            task2.Start();

            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Finished.");
        }

        

        private static Task SendAsync(string message)
        {
            return Task.Run(() => Send(message));
        }

        private static void Send(string message)
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} {message} Sending...");

            Thread.Sleep(TimeSpan.FromSeconds(5));

            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId}  Sent.");
        }

        private static Task<string> DownloadAsync(string url)
        {
            return Task.Run(() => Download(url));
        }

        private static string Download(string url)
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} {url} Downloading...");

            using (WebClient client = new WebClient())
            {
                Thread.Sleep(TimeSpan.FromSeconds(5));

                string content = client.DownloadString(url);

                Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} {url} Downloaded {content.Length} ");

                return content;
            }
        }
    }
}
