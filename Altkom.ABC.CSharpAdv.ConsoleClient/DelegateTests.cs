using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Altkom.ABC.CSharpAdv.ConsoleClient
{
    class DelegateTests
    {

        public static void Test()
        {
            DelegegateTest();

            PrinterTest();
        }

        private static void PrinterTest()
        {
            Console.Clear();

            Printer printer = new Printer();

            Sender sender = new Sender();

            printer.Log += SendConsole;
            printer.Log += SendEmail;
            printer.Log += sender.SendPost;
           // printer.Log += SendInstragram;

            // Metoda anonimowa
            printer.Log += delegate (string content)
            {
                Console.WriteLine($"Sent tweet {content}");
            };

            // Wyrażenie lambda
            // printer.Log += (string content) => Console.WriteLine($"Sent tweet {content}");

            printer.Log += content => Console.WriteLine($"Sent tweet {content}");

            printer.CalculateCost += copies => copies * 5.99m;




            Delegate[] delegates = printer.Log.GetInvocationList();

            Calculator calculator = new Calculator();

            printer.CalculateCost += calculator.Calculate;

            bool result = printer.Print("Hello .NET", 5);

        }

        
    
        private static void SendInstragram(byte[] photo)
        {
            Console.WriteLine($"Send photo {photo.Length}");
        }

        private static void SendConsole(string message)
        {
            Console.WriteLine($"Send console {message}");
        }

        private static void SendEmail(string message)
        {
            Console.WriteLine($"Send email {message} ");
        }


        private static void DelegegateTest()
        {
            Console.Clear();

            Sender sender = new Sender();
            //sender.SendConsole("Hello World!");
            //sender.SendSms("Hello World!");

            // strojenie
            sender.Send += sender.SendConsole;
            sender.Send += sender.SendSms;

            // wywołanie
            if (sender.Send != null)
                sender.Send("Hello World!");

            sender.Send -= sender.SendConsole;
            sender.Send += sender.SendPost;

            if (sender.Send != null)
                sender.Send.Invoke("Hello .NET");

            sender.Send = null;

            sender.Send?.Invoke("Hello everybody!");
        }
    }


    class Calculator
    {        
        public decimal Calculate(byte copies)
        {
            Console.WriteLine("Calculating...");
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Console.WriteLine("Calculated.");
            return copies * 1.5m;
        }
    }

    class Printer
    {
        public delegate void LogDelegate(string message);
        public LogDelegate Log { get; set; }

        public delegate decimal CalculateCostDelegate(byte copies);
        public CalculateCostDelegate CalculateCost { get; set; }

        public bool Print(string content, byte copies = 1)
        {
            for (int copy = 0; copy < copies; copy++)
            {
                // Console.WriteLine($"Printing {content} copy #{copy}");
                Log?.Invoke($"Printing {content} copy #{copy}");
            }

            // Console.WriteLine($"Printed {copies} copies");
            Log?.Invoke($"Printed {copies} copies");

            decimal? cost = CalculateCost?.Invoke(copies);

            Console.WriteLine($"LCD: cost {cost}");

            return true;
            
        }
    }

    class Sender
    {
        public delegate void SendDelegate(string message);

        public SendDelegate Send { get; set; }

        public void SendConsole(string message)
        {
            Console.WriteLine($"Send console {message}");
        }

        public void SendSms(string message)
        {
            Console.WriteLine($"Send {message} via sms");
        }

        public void SendPost(string content)
        {
            Console.WriteLine($"Published {content} on blog");
        }
    }
}
