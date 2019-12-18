using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;


namespace Lab_05_CRUD_App_Raw_SQL
{
    class Program
    {
        
        //to maken it global so that yiu can access it 
        static List<Customer> customers = new List<Customer>();
        static Customer customerUpdated;
       
        static void Main(string[] args)
        {

            string connectingString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Northwind";
            using (var connection = new SqlConnection(connectingString))
            {
                connection.Open();
                Console.WriteLine(connection.State);

                //customerUpdated = AddCustomer(connection);


                //generateRanmdomCustomerID(connection);

                //adding the customer
               // AddCustomer(connection);

                //lsiting the customer

               //updateCustomer(connection,customerUpdated);

                deleteCustomer(connection, "TOM");
                listCustomers(connection);
            }
        }

        static void listCustomers(SqlConnection sqlConnection)
        {
            // get customers
            using (var sqlCommand = new SqlCommand ("SELECT * FROM CUSTOMERS", sqlConnection))
            {
                SqlDataReader sqlReader = sqlCommand.ExecuteReader();
                while (sqlReader.Read())
                {
                    var newCustomer = new Customer()
                    {
                        CustomerID = sqlReader["CustomerID"].ToString(),
                        CompanyName = sqlReader["CompanyName"].ToString(),
                        ContactName = sqlReader["ContactName"].ToString(),
                        City = sqlReader["City"].ToString(),
                        Country = sqlReader["Country"].ToString()


                    };
                    //put into list

                    customers.Add(newCustomer);
                }
            }


            //print list a) foreach

            //foreach(var c in customers)
            //{
            //    Console.WriteLine($"{c.CustomerID}{"  "}{c.ContactName}{ " "}{c.CompanyName}"+ $"{c.City}{" "}{c.Country}");
            //}

            //b) Lambda for each

             Console.WriteLine($"{"CustomerID",-11}{"ContactName",-30}{"CompanyName",-40}" +
               $"{"City",-15}{"Country",-15}");


            customers.ForEach(c => Console.WriteLine($"{c.CustomerID ,-10}{c.ContactName, -30}{c.CompanyName, -40}" + 
                $"{c.City, -15}{c.Country, -15}"));

            

            // print list
        }

        static Customer AddCustomer(SqlConnection sqlConnection)
        {
            var rn = generateRanmdomCustomerID();
            var newCustomer = new Customer()
            {
                CustomerID = "KI12",
                CompanyName = "SpartaC",
                ContactName = "FOW",
                City = "LondonC",
                Country = "UK"
            };
            var sqlString1 = "INSERT INTO CUSTOMERS (CustomerID,CompanyName,ContactName,City,Country)" +
                "VALUES (@CustomerID,@CompanyName,@ContactName, @City,@Conutry)";

            using (var sqlCommand2 = new SqlCommand(sqlString1, sqlConnection))
            {
                // ExecuteNonQuery for ecample not Querying (Reading) but updating data
                // return an INTEGER FROM NUMBER OF RECODES SUCCESSFULLY UPDATED/INSERTED
                // expect 1 = (add 1 customer)
                sqlCommand2.Parameters.AddWithValue("@CustomerID", newCustomer.CustomerID);
                sqlCommand2.Parameters.AddWithValue("@CompanyName", newCustomer.CompanyName);
                sqlCommand2.Parameters.AddWithValue("@ContactName", newCustomer.ContactName);
                sqlCommand2.Parameters.AddWithValue("@City", newCustomer.City);
                sqlCommand2.Parameters.AddWithValue("@Conutry", newCustomer.Country);

                int result = sqlCommand2.ExecuteNonQuery();
                Console.WriteLine($"{result} Updated records added to database");
                if(result ==1)
                {
                    return newCustomer;
                }
            }

            return null;

            //var sqlString = "INSERT INTO CUSTOMERS (CustomerID,CompanyName,ContactName,City,Country)" +
            //                    "VALUES ('FEMI1','Sparta','FO', 'London','UK')";

            //using (var sqlCommand = new SqlCommand(sqlString, sqlConnection))
            //{
            //    // ExecuteNonQuery for ecample not Querying (Reading) but updating data
            //    // return an INTEGER FROM NUMBER OF RECODES SUCCESSFULLY UPDATED/INSERTED
            //    // expect 1 = (add 1 customer)
            //   int affected = sqlCommand.ExecuteNonQuery();
            //    Console.WriteLine($"{affected} new records added to database");
            //}
        }

        static string generateRanmdomCustomerID()
        {

            Random rnd = new Random();

            char[] id = new char[5];
            for (int i = 0; i < id.Length; i++)
            {
                id[i] = Convert.ToChar(rnd.Next(65, 90));
            }
            string s = new String(id);
            return id.ToString();
        }


        //Lets generate out sql command in a more professional way using parameters rather than literal values
        
        static void updateCustomer(SqlConnection sqlConnection, Customer c)
        {
            c.ContactName = "New Name";
            var updateSqlString = $"UPDATE CUSTOMERS SET ContactName= '{c.ContactName}"
                + $"WHERE CustomerID='{c.CustomerID}'";
            using(var sqlCommand = new  SqlCommand(updateSqlString, sqlConnection))
            {
                int aff = sqlCommand.ExecuteNonQuery();
                Console.WriteLine($"{aff} new records added to database");
            }
        }

        static void deleteCustomer(SqlConnection sqlConnection, string customerID)
        {

            var q = string.Format("DELETE FROM CUSTOMERS WHERE CustomerID = '{0}'", customerID);

            using (var sqlCommand = new SqlCommand(q, sqlConnection))
            {
                int aff1 = sqlCommand.ExecuteNonQuery();
                Console.WriteLine($"{aff1} delected");
            }
        }
    }

    class Customer
    {
        public string CustomerID { get; set; }

        public string ContactName { get; set; }

        public string CompanyName { get; set; }

        public string City { get; set; }
        public string Country { get; set; }


    }
}
