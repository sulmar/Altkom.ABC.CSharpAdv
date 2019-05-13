using Altkom.ABC.CSharpAdv.ConsoleClient.Models;
using System;
using System.Collections.Generic;

namespace Altkom.ABC.CSharpAdv.ConsoleClient
{
    public interface ICustomersService : IEntitiesService<Customer>
    {
        IEnumerable<Customer> Get(Gender gender);
    }

    public interface IOrdersService : IEntitiesService<Order>
    {
        IEnumerable<Order> Get(DateTime from, DateTime to);        
    }

    public interface IEntitiesService<TEntity>
    {
        IEnumerable<TEntity> Get();
        TEntity Get(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(int id);
    }







}
