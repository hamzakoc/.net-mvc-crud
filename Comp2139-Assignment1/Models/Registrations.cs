using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Comp2139_Assignment1.Models
{
    public class Registrations
    {

        [Required]
        public int RegistrationsID { get; set; }
        public int CustomersID { get; set; }
        public int ProductsID { get; set; }

        public ICollection<Customers> Customers { get; set; }
        public ICollection<Products> Products { get; set; }


    }
}
