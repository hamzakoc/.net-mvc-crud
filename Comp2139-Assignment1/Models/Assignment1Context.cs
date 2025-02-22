using CountryData.Standard;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Comp2139_Assignment1.Models
{
    public class Assignment1Context: DbContext
    {
        public Assignment1Context(DbContextOptions<Assignment1Context> options) : base(options)
        {
        }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Incidents> Incidents { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Registrations> Registrations { get; set; }
        public DbSet<Technicians> Technicians { get; set; }



   


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                    
            var helper = new CountryHelper();
            var data = helper.GetCountryData();   
            var countries = data.Select(c => c.CountryName).ToList();
           
            foreach (var country in countries)
            {
                modelBuilder.Entity<Countries>().HasData(
                new Countries { CountriesID= country});
               
            }

            modelBuilder.Entity<Products>().HasData(
                      new Products { ProductsID = 1, Code = "TRNY10", Name = "Tournament Master 1.0", Price = 4.99 },
                      new Products { ProductsID = 2, Code = "LEAG10", Name = "Leaagur Scheduler 1.0", Price = 4.99 },
                      new Products { ProductsID = 3, Code = "LEAGD10", Name = "Leaagur Scheduler Deluxe1.0", Price = 7.99 },
                      new Products { ProductsID = 4, Code = "DRAFT10", Name = "Draft Manager 1.0", Price = 4.99 },
                      new Products { ProductsID = 5, Code = "TEAM10", Name = "Team Manager 1.0", Price = 4.99 },
                      new Products { ProductsID = 6, Code = "TRNY20", Name = "Tournament Master 2.0", Price = 4.99 },
                      new Products { ProductsID = 7, Code = "DRAFT20", Name = "Tournament Master 1.0", Price = 5.99 },
                      new Products { ProductsID = 8, Code = "TRNY10", Name = "Draft Manager 2.0", Price = 5.99 }

                      );

            modelBuilder.Entity<Technicians>().HasData(
                      new Technicians { TechniciansID = 1, Name = "Alison Diaz", Email = "alison@sportsprosoftware.com", Phone = "800-555-0443" },
                      new Technicians { TechniciansID = 2, Name = "Andrew Wilson", Email = "awilson@sportsprosoftware.com", Phone = "800-555-0449" },
                      new Technicians { TechniciansID = 3, Name = "Gina Fiori", Email = "gfiori@sportsprosoftware.com", Phone = "800-555-0459" },
                      new Technicians { TechniciansID = 4, Name = "Guunter Wendit", Email = "gunter@sportsprosoftware.com", Phone = "800-555-0400" },
                      new Technicians { TechniciansID = 5, Name = "Jason Lee", Email = "alison@sportsprosoftware.com", Phone = "800-555-0444" }
                      );

            modelBuilder.Entity<Customers>().HasData(
                         new Customers { CustomersID = 1, FName = "Kaitlyn", LName = "Anthoni", Email = "kanthoni@pge.com", City = "San Francisco" },
                         new Customers { CustomersID = 2, FName = "Ania", LName = "Irvin", Email = "ania@mm.nidc.com", City = "Washington" },
                         new Customers { CustomersID = 3, FName = "Gonzolo", LName = "Keeton", Email = " ", City = "Mission Viejo"},
                         new Customers { CustomersID = 4, FName = "Anton", LName = "Mauro", Email = "amauro@yahoo.org", City = "Sacramento"},
                         new Customers { CustomersID = 5, FName = "Kendall", LName = "Mayte", Email = "kmayte@fresno.ca.gov", City = "Fresno" },
                         new Customers { CustomersID = 6, FName = "Kenzie", LName = "Quinn", Email = "kenzie@mmma.jobtrak.com", City = "Los Angles" },
                         new Customers { CustomersID = 7, FName = "Marvin", LName = "Quintin", Email = "marvin@expedata.com", City = "Fresno" }
                       );


            modelBuilder.Entity<Incidents>().HasData(
                new Incidents { IncidentsID = 1, Title = "Could not install", CustomersID = 5, ProductsID = 4, TechniciansID=1 },
                new Incidents { IncidentsID = 2, Title = "Could not install", CustomersID = 3, ProductsID = 1, TechniciansID = 2 },
                new Incidents { IncidentsID = 3, Title = "Error importing data", CustomersID = 2, ProductsID = 3, TechniciansID = 3 },
                new Incidents { IncidentsID = 4, Title = "Error launching program", CustomersID = 5, ProductsID = 2, TechniciansID = 4 }

                );

            
            

            modelBuilder.Entity<Registrations>().ToTable("Registrations");



        }


    }
}
