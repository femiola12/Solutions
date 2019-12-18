using System;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer;
using System.Collections.Generic;
using System.Linq;

namespace Lab_06_Rabbit_Create_100
{
    class Program
    {
        public static List<Rabbit> Rabbits = new List<Rabbit>();

        
        static void Main(string[] args)
        {
           // int dbrabbit = Convert.ToInt32(Console.ReadLine());
           // string rabbit

              //  addRabbits();
           // updateRabbitAge();
           //
            PrintRabbits();
           // updateRabbits(dbrabbit);
          //  PrintRabbits();





        }

        static void addRabbits()
        {

            using (var db = new RabbitDbContext())
            {
              
                for (int i = 0; i < 10; i++)
                {
                    var rabbit = new Rabbit("Rabbit" + i, 0);
                    db.Rabbits.Add(rabbit);
                    updateRabbitAge();
                }
                db.SaveChanges();
            }
           
        }

        static void updateRabbitAge()
        {
            using (var db = new RabbitDbContext())
            {
                Rabbits = db.Rabbits.ToList();
                foreach(var age in Rabbits)
                {
                    age.RabbitAge++;
                    db.Rabbits.Update(age);
                    
                }
                db.SaveChanges();

            }
        }

        static void updateRabbits(int rabbitID)
        {
            using (var db = new RabbitDbContext())
            {
                var rabbit = db.Rabbits.Find(rabbitID);
                rabbit.RabbitAge++;
                db.Rabbits.Update(rabbit);
                db.SaveChanges();

            }
        }

        static void PrintRabbits()
        {
           using(var db = new RabbitDbContext())
            {
                Rabbits = db.Rabbits.ToList();

            }

           Rabbits.ForEach(c => Console.WriteLine($"{c.RabbitID,-10}{c.RabbitName,-30}{c.RabbitAge,-40}"));
        }
    }

    

    class Rabbit 
    { 
        public int RabbitID { get; set; }
        public string RabbitName { get; set; }

        public int RabbitAge { get; set; }

        public Rabbit( string RabbitName, int RabbitAge)
        {
            //this.RabbitID = RabbitID;
            this.RabbitName = RabbitName;
            this.RabbitAge = RabbitAge;
        }

    
    }

    class RabbitDbContext: DbContext 
    { 
     // set table
     public DbSet<Rabbit> Rabbits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RabbitDB;";
            builder.UseSqlServer(connectionString);
            
        }
    
    }

    
}
