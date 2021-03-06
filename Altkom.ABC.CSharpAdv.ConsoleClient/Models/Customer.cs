﻿using System;

namespace Altkom.ABC.CSharpAdv.ConsoleClient
{
    public class CustomerInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    [Author("Marcin")]
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

        [Visibility(true)]
        public string FirstName { get; set; }
        [Visibility(true)]
        public string LastName { get; set; }
        [Visibility(false)]
        public Gender Gender { get; set; }
        public DateTime Birhtday { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Pesel { get; set; }
        public bool IsDeleted { get; set; }


        public void Send()
        {
            Console.WriteLine("Sent.");
        }

        public void DoWork(string message, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Working...!");
            }
        }

        public decimal Calculate(decimal unitprice, int qty)
        {
            return unitprice * qty;
        }
    }
    


}
