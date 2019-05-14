using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.ABC.CSharpAdv.ConsoleClient.FakeServices
{

    // Install-Package Bogus

    class CustomerFaker : Faker<Customer>
    {
        public CustomerFaker()
        {
            StrictMode(true);
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.FirstName, f => f.Person.FirstName);
            RuleFor(p => p.LastName, f => f.Person.LastName);
            RuleFor(p => p.Gender, f => f.PickRandom<Gender>());
            RuleFor(p => p.Birhtday, f => f.Person.DateOfBirth);
            RuleFor(p => p.Email, (f, user) => f.Internet.Email(user.FirstName, user.LastName));
            RuleFor(p => p.Description, f => f.Lorem.Sentence());
            Ignore(p => p.Pesel);
            RuleFor(p => p.IsDeleted, f => f.Random.Bool(0.2f));
        }
    }
}
