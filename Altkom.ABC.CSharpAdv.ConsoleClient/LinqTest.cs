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
            SetsTest();

            QueryableTest();

            GroupByTest();

        }

        private static void SetsTest()
        {
            IEnumerable<int> numbers = Enumerable.Range(1, 10);

            IEnumerable<int> myNumbers = new List<int> { 5, 7, 21, 30 };

            var common = numbers.Intersect(myNumbers);
            Display(common);

            var except = numbers.Except(myNumbers);
            Display(except);

            var union = numbers.Union(myNumbers);
            Display(union);

            var unionAll = numbers.Concat(myNumbers);
            Display(unionAll);

            var hasAllOver10 = unionAll.All(n => n > 10);

            var hasAnyOver10 = unionAll.Any(n => n > 10);
            var hasAnyOver10b = unionAll.Where(n => n > 10).Any();
        }

        private static void Display(IEnumerable<int> common)
        {
            foreach (var number in common)
            {
                Console.WriteLine(number);
            }
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
