using CSharpVerbalExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.ABC.CSharpAdv.ConsoleClient
{
    class FluentApiTest
    {

        public static void Test()
        {
            Console.Clear();

            StandardTest();

            FluentPhoneTest();

            FluentApiPhoneTest();

            BadPracticeTest();

            AdapterTest();

            FluentRegexTest();
        }

        private static void FluentRegexTest()
        {
            // Install-Package VerbalExpressions-official
            var verbEx = new VerbalExpressions()
                        .StartOfLine()
                        .Then("http")
                        .Maybe("s")
                        .Then("://")
                        .Maybe("www.")
                        .AnythingBut(" ")
                        .EndOfLine();

            Console.WriteLine($"regex: {verbEx}");

            // Create an example URL
            var testMe = "https://www.google.com";

            bool isCorrect = verbEx.Test(testMe);

            Console.WriteLine("We have a correct URL ");

        }

        private static void FluentApiPhoneTest()
        {

            FluentApiPhone
                .On
                .From("555-666-777")                
                .To("777-888-999")
                .To("888-888-888")
                .WithSubject(".NET")
                .Call();

            

            
        }

        private static void AdapterTest()
        {
            IPhone phone = PhoneFactory.Create("Panasonic");

            phone.Call("645654", "646464");



        }

        private static void BadPracticeTest()
        {
            string type = "Panasonic";

            if (type == "Panasonic")
            {
                PanasonicPhone phone = new PanasonicPhone();
                phone.Init();
                phone.Call("656546", "55465476464");
                phone.Release();
            }

            else if (type == "Motorola")
            {
                MotorolaPhone phone = new MotorolaPhone();
                phone.Ring("654654", "6565465", 10);
            }



        }

        private static void FluentPhoneTest()
        {
            FluentPhone phone = new FluentPhone();

            phone
                .From("555-444-999")
                .From("555-444-555")
                .WithSubject(".NET")
                .To("555-333-111")
                
                .Call();

            //Phone
            //    .From("555-444-555")
            //    .To("555-333-111")
            //    .To("555-222-111")
            //    .To("555-111-111")
            //    .WithSubject(".NET")
            //    .Call();

        }

        private static void StandardTest()
        {
            Phone phone = new Phone();
            
            phone.Call("555-444-555", "555-333-111", ".NET");

            phone.On();

        }
    }

    public class Phone
    {
        private bool on;

        public void On()
        {
            on = true;
        }

        public void Call(string from, string to, string subject)
        {
            if (on)
                Console.WriteLine($"Calling {from} -> {to} : {subject}" );
        }
    }

    //public interface IPhone
    //{
    //    FluentPhone From(string number);
    //    FluentPhone To(string number);
    //    FluentPhone WithSubject(string subject);
    //    void Call();
    //}


    public class MotorolaAdapterPhone : IPhone
    {
        // Adaptee
        private MotorolaPhone motorola;

        public MotorolaAdapterPhone()
        {
            motorola = new MotorolaPhone();
        }

        public void Call(string from, string to)
        {
            motorola.Ring(from, to, 10);
        }
    }

    public class PanasonicAdapterPhone : IPhone
    {
        // Adaptee
        private PanasonicPhone panasonic;

        public PanasonicAdapterPhone()
        {
            panasonic = new PanasonicPhone();
        }

        public void Call(string from, string to)
        {
            panasonic.Init();
            panasonic.Call(from, to);
            panasonic.Release();
        }
    }

    public class MotorolaPhone
    {
        public void Ring(string from, string to, int delay)
        {

        }
    }

    public class PanasonicPhone
    {
        public void Init()
        {

        }

        public void Call(string from, string to)
        {
            Console.WriteLine($"Calling {from} -> {to}");
        }

        public void Release()
        {

        }
    }

    public interface IPhone
    {
        void Call(string from, string to);
    }

    

    public class PhoneFactory 
    {
        public static IPhone Create(string type)
        {
            if (type == "Panasonic")
            {
                return new PanasonicAdapterPhone();                
            }

            else if (type == "Motorola")
            {
                return new MotorolaAdapterPhone();
            }

            throw new NotSupportedException(type);
        }
    }

    public class FluentPhone 
    {
        private string from;
        private string to;
        private string subject;

        public FluentPhone From(string number)
        {
            this.from = number;

            return this;
        }

        public FluentPhone To(string number)
        {
            this.to = number;

            return this;
        }

        public FluentPhone WithSubject(string subject)
        {
            this.subject = subject;

            return this;
        }

        public void Call()
        {
            Console.WriteLine($"Calling {from} -> {to} : {subject}");
        }
    }

    public interface IFrom
    {
        ITo From(string number);
    }

    public interface ITo
    {
        ISubject To(string number);
    }

    public interface ICall
    {
        void Call();
    }

    public interface ISubject : ITo, ICall
    {
        ICall WithSubject(string subject);
    }

    public class FluentApiPhone : IFrom, ITo, ISubject, ICall
    {
        private string from;
        // private string to;

        private IList<string> recipients;

        private string subject;

        protected FluentApiPhone()
        {
            recipients = new List<string>();
        }

        public static IFrom On
        {
            get
            {
                return new FluentApiPhone();
            }
        }

        public ITo From(string number)
        {
            this.from = number;

            return this;
        }

        public ISubject To(string number)
        {
            this.recipients.Add(number);

            return this;
        }

        public ICall WithSubject(string subject)
        {
            this.subject = subject;

            return this;
        }

        public void Call()
        {
            foreach (var to in recipients)
            {
                if (string.IsNullOrEmpty(subject))
                {
                    Console.WriteLine($"Calling {from} -> {to}");
                }
                else
                {
                    Console.WriteLine($"Calling {from} -> {to} : {subject}");
                }
            }
            
        }

       
    }


}
