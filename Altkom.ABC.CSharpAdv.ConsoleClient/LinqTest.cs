using Altkom.ABC.CSharpAdv.ConsoleClient.FakeServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.ABC.CSharpAdv.ConsoleClient
{
    class LinqTest
    {
        public static void Test()
        {
            QueryableTest();

            GroupByTest();

        }

        private static void GroupByTest()
        {
            CustomerFaker customerFaker = new CustomerFaker();

            IQueryable<Customer> customers = customerFaker.GenerateLazy(100).AsQueryable();

            var groups = customers
                .GroupBy(c => c.Gender)
                .Select( g => new { Gender = g.Key, Qty = g.Count() })
                .ToList();

        }

        private static void QueryableTest()
        {
            CustomerFaker customerFaker = new CustomerFaker();

            IQueryable<Customer> customers = customerFaker.GenerateLazy(100).AsQueryable();

            IQueryable<Customer> females = customers.Where(c => c.Gender == Gender.Female);

            IQueryable<Customer> sortedFemales = customers.OrderBy(c => c.FirstName);


            var query = customers
                    .Where(c => c.Gender == Gender.Female)
                    .Where(c => c.LastName.EndsWith("ski"));


            bool sorted = true;
            bool isFilteredByDescripion = false;

            if (sorted)
            {
                query = query.OrderBy(c => c.FirstName);
            }

            if (isFilteredByDescripion)
            {
                query = query.Where(c => c.Description.Contains("Lorem"));
            }

            IList<Customer> results = sortedFemales.ToList();
        }
    }
}
