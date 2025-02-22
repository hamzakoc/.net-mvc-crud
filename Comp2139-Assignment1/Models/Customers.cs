using System.Collections.Generic;

namespace Comp2139_Assignment1.Models
{
    public class Customers
    {

        public int CustomersID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string CountriesID { get; set; }
        public Countries Countries { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }
               
        public ICollection<Registrations> Registrations { get; set; }
        
    }
}