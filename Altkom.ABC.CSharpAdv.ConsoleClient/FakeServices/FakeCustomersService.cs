using Altkom.ABC.CSharpAdv.ConsoleClient.FakeServices;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Altkom.ABC.CSharpAdv.ConsoleClient
{

    public class FakeCustomersService : FakeEntitiesService<Customer>, ICustomersService
    {
        

        public IEnumerable<Customer> Get(Gender gender)
        {
            return entities.Where(p => p.Gender == gender);
        }
    }



}
