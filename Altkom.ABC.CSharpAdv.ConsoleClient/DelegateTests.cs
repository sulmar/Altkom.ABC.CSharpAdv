using Altkom.ABC.CSharpAdv.ConsoleClient.FakeServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Altkom.ABC.CSharpAdv.ConsoleClient
{
    class DelegateTests
    {

        public class Vehicle
        {
            public string Model { get; set; }
            public string Color { get; set; }
        }

        public static void Test()
        {
            DelegegateTest();

            PrinterTest();

            AnonymousTypeTest();
            
        }


        private static void AnonymousTypeTest()
        {
            CustomerFaker customerFaker = new CustomerFaker();

            Customer customer = customerFaker.Generate();

            CustomerInfo customerInfo = new CustomerInfo
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };

            var customerInfo2 = new
            {
                Imie = customer.FirstName,
                Plec = customer.Gender
            };

            var x = 10d;

            var location = new { lat = 52.06, lng = 19.8 };

            // location.lat = 51.4;  // błąd kompilacji - wartość tylko do odczytu

            Console.WriteLine($"({location.lat}, { location.lng})");

            IEnumerable<Customer> customers = customerFaker.Generate(10);

            var emails = customers.Select(c => new { c.Email, c.Gender });

            foreach (var email in emails)
            {
                Console.WriteLine($"{email.Email} {email.Gender}");
            }

        }

        //class anonymous_543753584w38957p839578d963
        //{
        //    public double lat { get; set; }
        //    public double lng { get; set; }
        //}

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

            printer.HasAuthorization += () => Thread.CurrentPrincipal.Identity.IsAuthenticated;

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
        //public delegate void LogDelegate(string message);
        //public LogDelegate Log { get; set; }

        public Action<string> Log { get; set; }

        //public delegate decimal CalculateCostDelegate(byte copies);
        //public CalculateCostDelegate CalculateCost { get; set; }

        public Func<byte, decimal> CalculateCost { get; set; }

        public Func<bool> HasAuthorization { get; set; }

        public bool Print(string content, byte copies = 1)
        {
            // TODO: czy uzytkownik posiada autoryzacje do wydruku?
            if (!HasAuthorization?.Invoke() ?? false )
            {
                Log?.Invoke($"Access denied.");

                return false;
            }

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
