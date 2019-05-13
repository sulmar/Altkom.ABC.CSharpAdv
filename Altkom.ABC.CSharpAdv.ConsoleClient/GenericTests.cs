using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.ABC.CSharpAdv.ConsoleClient
{
    public class GenericTests
    {
        public static void Test()
        {
            InterfaceTest();

            PolimorphismTest();

        }

        private static void PolimorphismTest()
        {
            IOrdersService ordersService = new FakeOrdersService();
            ordersService.Remove(0);
        }

        public class CustomersServiceFactory
        {
            public static ICustomersService GetCustomersService()
            {
                return new FakeCustomersService();

                // return new DbCustomersService();

                // return new CsvCustomersService("customers.csv");
            }
        }


        public static void InterfaceTest()
        {
            ICustomersService customersService = CustomersServiceFactory.GetCustomersService();

            // ICustomersService customersService = new DbCustomersService();

            // logic + UI

            var customers = customersService.Get();

            foreach (var customer in customers)
            {
                Console.WriteLine(customer.FirstName);
            }

            // customersService.Add(new Customer(4, "John"));

        }
    }

    public class CsvCustomersService : ICustomersService
    {
        private string filename;
        private char separator;

        public CsvCustomersService(string filename, char separator = '|')
        {
            this.filename = filename;
            this.separator = separator;
        }

        public void Add(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> Get()
        {
            string[] lines = System.IO.File.ReadAllLines(filename);

            ICollection<Customer> customers = new List<Customer>();

            foreach (string line in lines.Skip(1))
            {
                string[] columns = line.Split(separator);

                int customerId = int.Parse(columns[0]);
                string firstName = columns[1];

                Customer customer = new Customer(customerId, firstName);

                customers.Add(customer);
            }

            return customers;
        }

        public IEnumerable<Customer> Get(Gender gender)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }

    public class BedCustomersService
    {
        public IEnumerable<Customer> GetCustomersFromXml()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomersFromDb()
        {
            // exec uspGetCustomers()

            IEnumerable<Customer> customers = new List<Customer>
            {
                new Customer(1, "Marcin"),
                new Customer(2, "Kamil"),
                new Customer(3, "Piotr"),
            };

            return customers;

        }

    }
    


}
