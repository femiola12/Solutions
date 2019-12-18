using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;


namespace Lab_23_JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer(1, "Tom", "BAB217");
            var customer2 = new Customer(2, "Mary", "BAB218");
            var cus = new List<Customer>() { customer, customer2 };

            //serialise

            var JSONCustomerList = JsonConvert.SerializeObject(cus);

            Console.WriteLine(JSONCustomerList);

            // stream to file (json)
            File.WriteAllText("data.json", JSONCustomerList);

            var Jsonstring = File.ReadAllText("data.json");

            var customerFromJSON = JsonConvert.DeserializeObject<List<Customer>>(Jsonstring);

            customerFromJSON.ForEach(c => Console.WriteLine($"{c.CustomerID}, {c.CustomerName}"));
            //
        }

        [Serializable]
        public class Customer
        {

            public int CustomerID { get; set; }
            public string CustomerName { get; set; }

            //[NonSerialized]
            private string NINO;


            public Customer(int ID, string Name, string NINO)
            {
                this.CustomerID = ID;
                this.CustomerName = Name;
                this.NINO = NINO;
            }
        }
    }
}
