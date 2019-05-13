using Altkom.ABC.CSharpAdv.ConsoleClient.FakeServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Altkom.ABC.CSharpAdv.ConsoleClient
{

    public class FakeCustomersService : ICustomersService
    {
        private readonly ICollection<Customer> customers;

        public FakeCustomersService()
        {
            CustomerFaker customerFaker = new CustomerFaker();

            customers = customerFaker.Generate(100);
        }

        public void Add(Customer customer)
        {
            customers.Add(customer);
        }

        public Customer Get(int id)
        {
            return customers.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Customer> Get()
        {
            return customers;
        }

        public IEnumerable<Customer> Get(Gender gender)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            customers.Remove(Get(id));
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
    


}
