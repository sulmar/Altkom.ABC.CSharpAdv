using System;

namespace Altkom.ABC.CSharpAdv.ConsoleClient
{
    public class Customer : Base
    {
        public Customer()
        {

        }

        public Customer(int id, string firstName)
        {
            Id = id;
            FirstName = firstName;            
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birhtday { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Pesel { get; set; }
        public bool IsDeleted { get; set; }
    }
    


}
