using System;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer;
using System.Collections.Generic;
using System.Linq;


namespace Lab_07_Northwind_SQLite
{
    class Program
    {

        private static List<Customer> Customers = new List<Customer>();

        
        static void Main(string[] args)
        {
            PrintCustomer();
        }

        static void PrintCustomer()
        {
            using (var db = new NorthwindDbContext())
            {
                Customers = db.Customers.ToList();
            }

            Customers.ForEach(c => Console.WriteLine($"{c.CustomerID,-10}{c.CompanyName,-30}{c.ContactName,-40}"));
        }

        class NorthwindDbContext : DbContext
        {
            // Match the table customers
            public DbSet<Customer> Customers { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder builder)
            {

                string connectionString = @"Data Source=(path)C:\Users\FOladiji\Engineering45\WEEK5\SQLite\Northwind.db;";
                builder.UseSqlite(connectionString);

            }

        }

        class Customer
        {
            public string CustomerID { get; set; }

            public string ContactName { get; set; }

            public string CompanyName { get; set; }

            public string City { get; set; }
            public string Country { get; set; }

            //public Customer(int CustomerID, string ContactName, string Comp)
            //{
            //    //this.RabbitID = RabbitID;
            //    this.RabbitName = RabbitName;
            //    this.RabbitAge = RabbitAge;
            //}
        }
    }
}
