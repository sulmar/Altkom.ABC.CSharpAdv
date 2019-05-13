# Przykłady ze szkolenia Programowanie .NET - kurs zaawansowany



## Metody rozszerzające

### FluentDateTime

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
