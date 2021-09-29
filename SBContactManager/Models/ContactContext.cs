using Microsoft.EntityFrameworkCore;
using SBContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBContactManager.Models
{
    /// <summary>
    /// DB Class
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
            //The ModelBuilder object provides an Entity<Contact> methods that returns an EntityTypeBuilder<Contact> object.
            //EntityTypeBuilder<Contact> object provides a HasData() method that accepts an array of entity/Contact objects.

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Work" },
                new Category { CategoryId = 2, Name = "Friend" },
                new Category { CategoryId = 3, Name = "Relative" },
                new Category { CategoryId = 4, Name = "Other" }
                );

            modelBuilder.Entity<Contact>().HasData(
                    new Contact
                    {
                        ContactId = 1,
                        FirstName = "Brad",
                        LastName = "Pitt",
                        Phone = "555-987-6543",
                        Email = "bradpitt@hotmail.com",
                        CategoryId = 1,
                        DateAdded = DateTime.Now
                    },
                    new Contact
                    {
                        ContactId = 2,
                        FirstName = "David",
                        LastName = "Becham",
                        Phone = "555-456-7890",
                        Email = "David@hotmail.com",
                        CategoryId = 2,
                        DateAdded = DateTime.Now
                    },
                    new Contact
                    {
                        ContactId = 3,
                        FirstName = "Christiano",
                        LastName = "Ronaldo",
                        Phone = "555-123-4597",
                        Email = "Christiano@hotmail.com",
                        CategoryId = 3,
                        DateAdded = DateTime.Now
                    }
                );
        }
    }
}
