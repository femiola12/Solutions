using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab_17_Northwide_Tests
{
    public class Program
    {

        //private static List<Customer> Customers = new List<Customer>();


        static void Main(string[] args)
        {


        }

        


       


        public  class Customers
        {
            public static List<Customer> customers ;

            public static int PrintCustomer()
            {
                customers = new List<Customer>();
                using (var db = new NorthwindEntities())
                {
                    customers = db.Customers.ToList();

                    var selectedCustomer = (from customer in customers
                                            select customer).ToList();

                    foreach (var c in selectedCustomer)
                    {
                         customers.Add(c);
                    }
                    return customers.Count();
                }



            }
        }


    }
}
