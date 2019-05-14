using System.Collections.Generic;

namespace Altkom.ABC.CSharpAdv.ConsoleClient
{
    public interface ICustomersService : IEntitiesService<Customer>
    {
        IEnumerable<Customer> Get(Gender gender);
    }







}
