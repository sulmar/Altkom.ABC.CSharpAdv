using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.ABC.CSharpAdv.ConsoleClient
{
    public class CollectionTests
    {

        public static void Test()
        {
            ListTest();

            StackTest();

            QueueTest();

            DictionaryTest();




        }

        public static void ListTest()
        {
            IEnumerable<int> numbers = new List<int>();

            ICollection<int> numbers2 = new List<int>();
            numbers2.Add(100);

            IList<int> numbers3 = new List<int>() { 1, 2, 3 };
            Console.WriteLine(numbers3[0]);
            
            foreach (int number in numbers)
            {

            }
        }

        public static void StackTest()
        {
            Page page1 = new Page(1, "Step 1");
            Page page2 = new Page(2, "Step 2");
            Page page3 = new Page(3, "Step 3");

            Stack<Page> pages = new Stack<Page>();

            pages.Push(page1);
            Display(pages);

            pages.Push(page2);
            Display(pages);

            pages.Push(page3);
            Display(pages);

            // remove from stack
            Page page = pages.Pop();
            Console.WriteLine(page.Name);

            Display(pages);

            Page currentPage = pages.Peek();
            Console.WriteLine(currentPage.Name);
        }

        public static void QueueTest()
        {
            Queue<Person> queue = new Queue<Person>();

            Person person1 = new Person("Piotr");
            queue.Enqueue(person1);

            Person person2 = new Person("Kamil");
            queue.Enqueue(person2);

            Person person3 = new Person("Marcin");
            queue.Enqueue(person3);

            Display(queue);

            while(queue.Count>0)
            {
                Person person = queue.Dequeue();

                Console.WriteLine(person);

                // Person currentPerson = queue.Peek();

            }
            
            
        }

        public static void DictionaryTest()
        {
            IDictionary<string, int> options = new Dictionary<string, int>();

            options.Add(new KeyValuePair<string, int>("Option1", 10));
            options.Add(new KeyValuePair<string, int>("Option2", 20));
            options.Add(new KeyValuePair<string, int>("Option3", 30));
           // options.Add(new KeyValuePair<string, int>("Option3", 30));

            int option = options["Option2"];

            Console.WriteLine(option);
        }


        // Metoda generyczna
        private static void Display<T>(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static void Display(IEnumerable<Person> persons)
        {
            foreach (var person in persons)
            {
                Console.WriteLine(person.ToString());
            }
        }

        private static void Display(IEnumerable<Page> pages)
        {
            foreach (var page in pages)
            {
                Console.WriteLine(page.ToString());
            }
        }


    }


    public class Device
    {

    }

    public class Person
    {
        public Person(string firstName)
        {
            FirstName = firstName;
        }

        public string FirstName { get; set; }

        public override string ToString()
        {
            return FirstName;
        }
    }

    public class Page
    {
        public Page(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }


        public override string ToString()
        {
            return Name;
        }


    }
}
