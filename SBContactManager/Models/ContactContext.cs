using Microsoft.EntityFrameworkCore;
using SBContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBContactManager.Models
{
    /// <summary>
    /// Contacts is a class that inherits DbContext base class.
    /// DbContext class is the Primary Class for communicating with a Base Class.
    /// </summary>
    public class ContactContext : DbContext
    {
        /// <summary>
        /// Below is a constructor of the main class Contacts.
        /// The constructor below accepts a DbContextOptions object and passes it to the constructor of the base class DbContext.
        /// </summary>
        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        {}
        /// <summary>
        /// The class below represents a collection of a Model classes that maps to the database.
        /// ContactContext class has a Contacts property of DbSet<Contact> type. This peroperty is used by EF Core to create database tables.
        /// </summary>
        public DbSet<Contact> Contacts { get; set; }
        /// ContactContext class has a Contacts property of DbSet<Contact> type. This peroperty is used by EF Core to create database tables.
        public DbSet<Category> Categories { get; set; }

        //Seeding some initial data into the Database that EF Core creates. 
        //Using OnModelCreating() method of DbContext class to override to configure my context.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //The ModelBuilder object provides an Entity<Contact> methods that returns an EntityTypeBuilder<Contact> object.
            //EntityTypeBuilder<Contact> object provides a HasData() method that accepts an array of entity/Contact objects.

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = "W", Name = "Work" },
                new Category { CategoryId = "F", Name = "Friend" },
                new Category { CategoryId = "R", Name = "Relative" }
                );

            modelBuilder.Entity<Contact>().HasData(
                    new Contact
                    {
                        ContactId = 1,
                        FirstName = "Brad",
                        LastName = "Pitt",
                        Phone = 5559876543,
                        Email = "bradpitt@hotmail.com",
                        CategoryId = "W"
                    },
                    new Contact
                    {
                        ContactId = 2,
                        FirstName = "David",
                        LastName = "Becham",
                        Phone = 5554567890,
                        Email = "David@hotmail.com",
                        CategoryId = "F"
                    },
                    new Contact
                    {
                        ContactId = 3,
                        FirstName = "Christiano",
                        LastName = "Ronaldo",
                        Phone = 5551234597,
                        Email = "Christiano@hotmail.com",
                        CategoryId = "R"
                    }
                );
        }
    }
}
