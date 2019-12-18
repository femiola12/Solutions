using System;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;

namespace Lab_22_Serialization
{
    class Program
    {
        static void Main(string[] args)
        {

            var cust1 = new Customer(1, "james", "BAB123");
            var cust2 = new Customer(2, "mike", "BAB2019");
            var cust3 = new List<Customer>() { cust1, cust2 };

            var formateee = new SoapFormatter();

            using (var stream = new FileStream("infor.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formateee.Serialize(stream, cust3);
            }

            Console.WriteLine(File.OpenRead("infor.xml"));

            var customerXML = new List<Customer>();

            using (var reader = File.OpenRead("infor.xml"))
            {
                customerXML = formateee.Deserialize(reader) as List<Customer>;
            }

            customerXML.ForEach(c => Console.WriteLine($"{c.CustomerID},{c.CustomerName}"));

            // deserialize xml => customer and print
        }
    }


    [Serializable]
    public class Customer
    {
        public int CustomerID { get; set; }

        public string CustomerName { get; set; }

        [NonSerialized]
        public String NINO;

        public Customer(int ID, string Name, string NINO)
        {
            this.CustomerID = ID;
            this.CustomerName = Name;
            this.NINO = NINO;
        }
    }

    
}
