using System;
using Lab_22_Serialization;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Lab_24_Serliza_Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer(1, "Tom", "BAB217");
            var customer2 = new Customer(2, "Mary", "BAB218");
            var cus = new List<Customer>() { customer, customer2 };


            var formatter = new BinaryFormatter();


            using (var stream = new FileStream("data.bin", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, cus);
            };

            var customer01 = new List<Customer>();

            using (var reader = File.OpenRead("data.bin"))
            {
                 customer01 = formatter.Deserialize(reader) as List<Customer>;
            }

            

        }
    }
}
