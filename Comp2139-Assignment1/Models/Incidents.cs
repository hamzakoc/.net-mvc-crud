using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comp2139_Assignment1.Models
{
    public class Incidents
    {

        public int IncidentsID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CustomersID { get; set; }
        public Customers Customers { get; set; }
        public int ProductsID { get; set; }
        public Products Products { get; set; }
        public int TechniciansID { get; set; }
        public Technicians Technicians { get; set; }
        public DateTime DateOpened { get; set; }
        public DateTime DateClosed { get; set; }






    }
}
