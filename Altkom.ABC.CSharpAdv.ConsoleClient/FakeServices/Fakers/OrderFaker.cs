using Altkom.ABC.CSharpAdv.ConsoleClient.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.ABC.CSharpAdv.ConsoleClient.FakeServices
{
    class OrderFaker : Faker<Order>
    {
        public OrderFaker()
        {
            RuleFor(p => p.Id, f => f.IndexFaker);
        }
    }
}
