using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Lab_04_Connect_to_Raw_sql
{
    class Program
    {
        static void Main(string[] args)
        {
            //@ means take literally what in the following string
            // IE NO 'Escapoing ' of character allowed
            // example @"C:\folder\file" is good
            //  @"C:\\folder\\file" ESCAPING BACKSLASH

            string connectingString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Northwind";
            using (var connection = new SqlConnection(connectingString))
            {
                connection.Open();
                Console.WriteLine(connection.State);

                //READ FROM DATABASE
                using (var sqlCommand = new SqlCommand("SELECT * FROM CUSTOMERS", connection))
                {
                    // CREATE A LOOP TO READ AND ITERRATE AND PARSE DATA 
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    //loop while data present
                    while (reader.Read())
                    {
                        //RETUEN FALSE
                        string CustomerId = reader["CustomerID"].ToString();
                        string ContactName = reader["ContactName"].ToString();
                        Console.WriteLine($"{CustomerId,-15}{ContactName}");
                    }
                }

                var query = "INSERT INTO CUSTOMERS (id,CompanyName) VALUES (@id,@CompanyName)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", "MUTV");
                    command.Parameters.AddWithValue("@CompanyName", "ManUnited");

                    //connection.Open();
                   // int result = command.ExecuteNonQuery();

                }

            }
        }
    }
}
