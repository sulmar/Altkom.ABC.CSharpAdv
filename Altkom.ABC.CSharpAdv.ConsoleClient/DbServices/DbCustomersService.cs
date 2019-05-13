using System;
using System.Collections.Generic;
using System.Linq;

namespace Altkom.ABC.CSharpAdv.ConsoleClient
{
    public class DbCustomersService : ICustomersService
    {
        private IEnumerable<Customer> customers = new List<Customer>
            {
                new Customer(1, "Marcin"),
                new Customer(2, "Kamil"),
                new Customer(3, "Piotr"),
            };

        public Customer Get(int id)
        {
            Console.WriteLine($"SQL: select * from Customers where CustomerId = {id}");
            return customers.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Customer> Get()
        {
            Console.WriteLine("SQL: exec uspGetCustomers");
            return customers;
        }

        public void Add(Customer customer)
        {
            Console.WriteLine("SQL: insert into Customers...");
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> Get(Gender gender)
        {
            throw new NotImplementedException();
        }
    }
    


}
