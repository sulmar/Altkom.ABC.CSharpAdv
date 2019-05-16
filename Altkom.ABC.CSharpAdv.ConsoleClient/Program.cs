using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.ABC.CSharpAdv.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            CollectionTests.Test();

            GenericTests.Test();

            ExtensionMethodTests.Test();

            DelegateTests.Test();

            LinqTest.Test();

            ReflectionTests.Test();

            FluentApiTest.Test();

            IocTests.Test();

            // ThreadTests.Test();

            // TasksTest.Test();

            // LockTests.Test();

            ConcurrentCollectionTests.Test();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
