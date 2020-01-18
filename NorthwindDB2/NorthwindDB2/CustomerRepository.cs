using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDB2
{
    // Créer une classe CustomerRepository
    class CustomerRepository
    {

        // GetCustomerById
        internal static Customer GetCustomer(string customerID)
        {
            Customer myCustomer = new Customer();
            SqlConnection connection = ConnectionSQL.GetConnectionSQL();

            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText =
                        "SELECT *  FROM dbo.Customers WHERE CustomerID=@CustomerID";
                    command.Parameters.AddWithValue("@CustomerID", customerID);
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            myCustomer.CustomerID = dataReader["CustomerID"].ToString();
                            myCustomer.CompanyName = dataReader["CompanyName"].ToString();
                            myCustomer.ContactName = dataReader["ContactName"].ToString();

                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception:" + exc.Message);
            }
            connection.Close();

            return myCustomer;
        }

        // GetCustomersByCountry
        internal static Customer GetCustomerByCountry(string country)
        {
            Customer myCustomer = new Customer();
            SqlConnection connection = ConnectionSQL.GetConnectionSQL();

            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText =
                        "SELECT *  FROM dbo.Customers WHERE Country=@country";
                    command.Parameters.AddWithValue("@country", country);
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            myCustomer.CustomerID = dataReader["CustomerID"].ToString();
                            myCustomer.CompanyName = dataReader["CompanyName"].ToString();
                            myCustomer.ContactName = dataReader["ContactName"].ToString();

                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception:" + exc.Message);
            }
            connection.Close();

            return myCustomer;
        }



        // UpdateCustomerCity
        internal static void ModifyCustomerCity(Customer custo, string city)
        {

            SqlConnection connection = ConnectionSQL.GetConnectionSQL();

            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText =
                        "UPDATE dbo.Customers SET City=@City WHERE CustomerID=@CustomerID";
                    command.Parameters.AddWithValue("@CustomerID", custo.CustomerID);
                    // command.Parameters.AddWithValue("@field", "Country");
                    command.Parameters.AddWithValue("@City", city);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception:" + exc.Message);
            }
            connection.Close();
        }

        // DeleteCustomerByName

        internal static void DeleteCustomerByName(string customerID)
        {
            SqlConnection connection = ConnectionSQL.GetConnectionSQL();

            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText =
                        "DELETE FROM dbo.Customers WHERE CustomerID=@CustomerID";
                    command.Parameters.AddWithValue("@CustomerID", customerID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception:" + exc.Message);
            }
            connection.Close();
        }

    }
}
