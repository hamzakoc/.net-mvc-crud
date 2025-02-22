using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Comp2139_Assignment1.Models
{
    public class Products
    {
        [Required]
        public int ProductsID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime ReleaseDate { get; set; }

        public ICollection<Registrations> Registrations { get; set; }

    }
}