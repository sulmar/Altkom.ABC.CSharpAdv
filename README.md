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

### Utworzenie klasy generycznej




 

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
