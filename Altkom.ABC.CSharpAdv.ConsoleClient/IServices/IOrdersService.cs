using Altkom.ABC.CSharpAdv.ConsoleClient.Models;
using System;
using System.Collections.Generic;

namespace Altkom.ABC.CSharpAdv.ConsoleClient
{
    public interface IOrdersService : IEntitiesService<Order>
    {
        IEnumerable<Order> Get(DateTime from, DateTime to);        
    }







}
