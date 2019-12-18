using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;


namespace Lad_14_Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            /*

                 Read northwind using entity core 2.1.1

                 Basic LINQ
                 `
                 More advanced LINQ with lambda

            */

            //Nuget - microsoft.entityframeworkcore/.sqlserver/.design -v 2.1.1

            List<Customer> customers = new List<Customer>();
            List<ModifiedCustomer> modifiedCustomers = new List<ModifiedCustomer>();
            List<Product> products = new List<Product>();
            List<Category> categories = new List<Category>();


            using (var db = new Northwind())
            {

                customers = db.Customers.ToList();


                //simple linq from local collection
                // whole dataset is returned (more data)
                // IENUMERABLE ARRAY
                var selectedCustomer = from customer in customers
                                       select customer;

                //Same query over database directly
                //ONLY RETURN ACTUAL DATABASE WE NEED 
                // LAZY LOADING : QUERY ID NOT ACTUALLY EXESUTED 
                //DATA HAS NOT ACTUALLY ARRIVED YET!!
                var selectedCustomer2 = (from customer in db.Customers
                                         where customer.City == "London" || customer.City == "Berlin"
                                         orderby customer.ContactName
                                         select customer).ToList();
                //CREATE CUSTOM OBJECT OUTPUT
                var selectCustomer3 = (from customer in db.Customers
                                       select new
                                       {
                                           Name = customer.ContactName,
                                           Location = customer.City + " " + customer.Country
                                       });

                foreach (var c in selectCustomer3)
                {
                    Console.WriteLine($"{c.Name,-20}{c.Location}");
                }


                printCustomers(selectedCustomer2);


                // Grouping
                // group and list all customers by CITY
                // CITY ... Count(CUSTOMER)
                var selectedCustomers5 =
                    from cust in db.Customers
                    group cust by cust.City into Cities
                    orderby Cities.Count() descending
                    select new
                    {
                        City = Cities.Key,
                        Count = Cities.Count()
                    };
                foreach (var c in selectedCustomers5)
                {
                    Console.WriteLine($"{c.City,-15}{c.Count}");
                }



                // JOIN
                // products with CategoryID => category



                var listofproducts =
                        (from p in db.Products
                         join c in db.Categories
                     on p.CategoryID equals c.CategoryID
                         select new
                         {
                             ID = p.ProductID,
                             Name = p.ProductName,
                             Category = c.CategoryName
                         }).ToList();



                listofproducts.ForEach(p => Console.WriteLine($"{p.ID,-15}{p.Name,-15}{p.Category,15}"));

                Console.WriteLine("\n\n Now Print off the same list but using mush smarter\n" + "'dot' Notation To Join Tables\n");
                //read in products and categories 
                products = db.Products.ToList();
                categories = db.Categories.ToList();
                products.ForEach(p => Console.WriteLine($"{p.ProductID,-15}{p.ProductName,-30}{p.Category.CategoryName}"));

                Console.WriteLine("\n\nList categoties with count of products and sub--list of product names\n");
                categories.ForEach(c =>
                {
                    Console.WriteLine($"{c.CategoryID,-15}{c.CategoryName,-15} has {c.Products.Count} products");
                    // loop within loop 
                    foreach (var p in c.Products)
                    {
                        Console.WriteLine($"\t\t\t\t{p.ProductID,-5}{p.ProductName}");
                    }

                }

                  );
                Console.WriteLine($"\n\nLinq lamda notation\n");
                customers = db.Customers.ToList();
                Console.WriteLine($"Count is {customers.Count}");
                Console.WriteLine($"Count is {db.Customers.Count()}");

                //select ... distinct 
                Console.WriteLine($"\n\nList of cities distinctn\n");
                Console.WriteLine("Using SLECT TO SELECT ONE COLUMN");
                var cityList = db.Customers.Select(c => c.City).Distinct().OrderBy(c => c).ToList();
                cityList.ForEach(city => Console.WriteLine(city));

                Console.WriteLine("\n\nContain(same as SQL LIKE)\n");
                var cityListFilterd = db.Customers.Select(c => c.City).Where(city => city.Contains("o"))
                    .Distinct()
                    .OrderBy(c => c)
                    .ToList();
                cityListFilterd.ForEach(city => Console.WriteLine(city));



            }

            //FORCE DATA  BY PUSHING TO A LIST IE. ToList() OR BY TAKING AGGREGATE eg SUM, Count



        }

        static void printCustomers(List<Customer> customers)
        {
            customers.ForEach(c => Console.WriteLine($"{c.CustomerID,-10}" + $"{c.ContactName,-30}{c.CompanyName,-40}{c.City}"));
        }

        public class ModifiedCustomer
        {
            public string Name { get; set; }

            public string Location { get; set; }

            public ModifiedCustomer(string Name, string Location)
            {
                this.Name = Name;
                this.Location = Location;
            }
        }


    }

     public static class CustomersRead
     {
        public static List<Customer> customers;
        public static List<Product> products;

        public static int PrintCustomer()
        {
            //customers = new List<Customer>();
            
            using (var db = new Northwind())
            {
                

                var selectedCustomer = (from customer in db.Customers
                                        select customer).Count();


                return selectedCustomer;
            }



        }
        public static int PrintCustomer2(string city)
        {
            using (var db = new Northwind())
            {
                customers = db.Customers.ToList();

                if (string.IsNullOrEmpty(city))
                {
                    return db.Customers.Count();
                }
                else
                {
                    return db.Customers.Where(c => c.City == city).Count();
                }
            }
        }

            public static int product()
            {

            
            using (var db = new Northwind())
            {
                products = db.Products.ToList();
                var selectProduct = (from product in products 
                                     where product.CategoryID == 1 
                                     select product).Count();


                return selectProduct;
                
            }
               
                    
            }
     }


    #region DatabaseContextAndClasses
    // connect to database

    public partial class Customer
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public Category()
        {
            this.Products = new List<Product>();
        }
    }

    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; } = 0;
        public short? UnitsInStock { get; set; } = 0;
        public short? UnitsOnOrder { get; set; } = 0;
        public short? ReorderLevel { get; set; } = 0;
        public bool Discontinued { get; set; } = false;
    }

    public class Northwind : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;" + "Initial Catalog=Northwind;" + "Integrated Security = true;" + "MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryName)
                .IsRequired()
                .HasMaxLength(15);

            // define a one-to-many relationship
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category);

            modelBuilder.Entity<Product>()
                .Property(c => c.ProductName)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products);
        }
    }


    #endregion
}


















