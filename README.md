# Przykłady ze szkolenia Programowanie .NET - kurs zaawansowany



## Typy generyczne


### Interfejs generyczny

- Utworzenie interfejsu

IServices.cs

~~~ csharp
public interface IEntitiesService<TEntity>
    {
        IEnumerable<TEntity> Get();
        TEntity Get(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(int id);
    }
~~~

- Zastosowanie
~~~ csharp

public interface ICustomersService : IEntitiesService<Customer>
 {
     IEnumerable<Customer> Get(Gender gender);
 }
 
 ~~~

### Klasa generyczna

~~~ csharp
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

        public virtual TEntity Get(int id) => entities.SingleOrDefault(p => p.Id == id);

        public virtual void Remove(int id) => entities.Remove(Get(id));

        public virtual void Update(TEntity entity) => throw new NotImplementedException();
    }
    
    
~~~ 

Zastosowanie

~~~ csharp
 public class FakeCustomersService : FakeEntitiesService<Customer>, ICustomersService
    {
        public IEnumerable<Customer> Get(Gender gender)
        {
            return entities.Where(p => p.Gender == gender);
        }
    }
~~~ 

 

## Metody rozszerzające

### Utworzenie własnej metody rozszerzającej

~~~ csharp
 public static class DateTimeExtensions
    {
        public static bool IsWeekend(this DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek.Saturday
                || dateTime.DayOfWeek == DayOfWeek.Sunday;
        }

        public static DateTime AddWorkDays(this DateTime dateTime, byte days)
        {
            return dateTime.AddDays(days);
        }
    }
~~~


### Biblioteka FluentDateTime

~~~ powershell
PM> Install-Package FluentDateTime
~~~

~~~ csharp
DateTime.Now - 1.Weeks() - 3.Days() + 14.Minutes();
DateTime.Now + 5.Years();
3.Days().Ago();
2.Days().Since(DateTime.Now);
~~~

https://github.com/FluentDateTime/FluentDateTime
