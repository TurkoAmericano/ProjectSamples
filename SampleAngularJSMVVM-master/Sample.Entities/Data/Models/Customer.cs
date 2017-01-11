using System;

namespace Sample.Entities.Data.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public  string MiddleName { get; set; }
        public  string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }
}
