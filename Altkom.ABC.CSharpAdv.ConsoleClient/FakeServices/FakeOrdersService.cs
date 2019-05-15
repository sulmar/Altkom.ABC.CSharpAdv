using Altkom.ABC.CSharpAdv.ConsoleClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Altkom.ABC.CSharpAdv.ConsoleClient
{
    public class FakeOrdersService : FakeEntitiesService<Order>, IOrdersService
    {
        public IEnumerable<Order> Get(DateTime from, DateTime to)
        {
            return entities
                .Where(p => p.OrderDate >= from && p.OrderDate <= to);
        }

        public override void Remove(int id)
        {
            Get(id).IsDeleted = true;
        }
    }

    public class DbOrdersService : FakeOrdersService
    {
        public override void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
    


}
