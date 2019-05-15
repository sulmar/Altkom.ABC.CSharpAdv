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

        private Faker<TEntity> entityFaker;

        public FakeEntitiesService()
            : this(new Faker<TEntity>())
        {
        }

        public FakeEntitiesService(Faker<TEntity> entityFaker)
        {
            entities = entityFaker.Generate(100);
        }

        public virtual void Add(TEntity entity) => entities.Add(entity);

        public virtual IEnumerable<TEntity> Get() => entities;

        public virtual TEntity Get(int id) => entities.FirstOrDefault(p => p.Id == id);

        public virtual void Remove(int id) => entities.Remove(Get(id));

        public virtual void Update(TEntity entity) => throw new NotImplementedException();

    }
    


}
