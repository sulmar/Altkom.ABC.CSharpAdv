using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Altkom.ABC.CSharpAdv.ConsoleClient
{
    public class FakeEntitiesService<TEntity> : IEntitiesService<TEntity>
        where TEntity : Base
    {
        protected readonly ICollection<TEntity> entities;

        public FakeEntitiesService()
        {
            Faker<TEntity> entityFaker = new Faker<TEntity>();

            entities = entityFaker.Generate(100);
        }

        public virtual void Add(TEntity entity)
        {
            entities.Add(entity);
        }

        public virtual IEnumerable<TEntity> Get()
        {
            return entities;
        }

        public virtual TEntity Get(int id)
        {
            return entities.SingleOrDefault(p => p.Id == id);
        }

        public virtual void Remove(int id)
        {
            entities.Remove(Get(id));
        }

        //public void Remove(int id)
        //{
        //    entities.Remove(Get(id));
        //}

        public virtual void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
    


}
