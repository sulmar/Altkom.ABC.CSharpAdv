using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Altkom.ABC.CSharpAdv.ConsoleClient
{
    class IocTests
    {
        public static void Test()
        {
           AutoFacTest();

           UnityTest();
        }

        private static void UnityTest()
        {
            var container = new UnityContainer();

            container.RegisterType<IUsersService, FakeUsersService>();
            // container.RegisterType<IUsersService, DbUsersService>();
            container.RegisterSingleton<IUsersService, DbUsersService>();

            IUsersService usersService = container.Resolve<IUsersService>();
            IUsersService usersService2 = container.Resolve<IUsersService>();

            if (ReferenceEquals(usersService, usersService2))
            {
                Console.WriteLine("Identyczne");
            }

            User user = new User { Id = 1, FirstName = "Marcin" };

            usersService.Add(user);

            decimal cost = usersService.Calculate(user);

            Console.WriteLine(cost);

            IEnumerable<IUsersService> usersServices = container.ResolveAll<IUsersService>();

        }

        public static void AutoFacTest()    
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<FakeUsersService>().As<IUsersService>();
            builder.RegisterType<DbUsersService>().As<IUsersService>().SingleInstance();
            builder.RegisterType<Connection>();
            builder.RegisterType<MyOptions>();

            IContainer container = builder.Build();

            // IUsersService usersService = new DbUsersService(new Connection());

            IUsersService usersService = container.Resolve<IUsersService>();

            IUsersService usersService2 = container.Resolve<IUsersService>();

            if (ReferenceEquals(usersService, usersService2))
            {
                Console.WriteLine("Identyczne");
            }


            // IEnumerable<IUsersService> usersServices = container.Resolve<IEnumerable<IUsersService>>();

            User user = new User { Id = 1, FirstName = "Marcin" };

            usersService.Add(user);

            decimal cost = usersService.Calculate(user);

            Console.WriteLine(cost);
        }
    }

    

    public class MyOptions
    {
        public int Option1 { get; set; }
        public int Option2 { get; set; }
        public string Option3 { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public interface IUsersService
    {
        void Add(User user);
        decimal Calculate(User user);
    }

    public class FakeUsersService : IUsersService
    {
        private readonly IList<User> users = new List<User>();

        public void Add(User user) => users.Add(user);
        public decimal Calculate(User user) => 100;
    }

    public class Connection
    {
        public MyOptions Options { get; set; }

        public Connection(MyOptions options)
        {
            this.Options = options;
        }

        public void Open()
        {
            Console.WriteLine($"Connect to {Options.Option3}...");
        }
    }

    public class DbUsersService : IUsersService
    {
        private readonly Connection connection;

        public DbUsersService(Connection connection)
        {
            this.connection = connection;
        }

        public void Add(User user)
        {
            this.connection.Open();
        }

        public decimal Calculate(User user)
        {
            return 200;
        }
    }
}
