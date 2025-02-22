using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Comp2139_Assignment1.Models
{
    public class Technicians
    {
        [Required]
        public int TechniciansID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public string Slug =>
                Name?.Replace(' ' , '-').ToLower() + '-' +ToString();


    }
}