using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDB2
{
    class SQLRequests
    {

        // Créer une méthode qui récupére les 20 premiers Customers 
        // vivant en France et renvoie une liste
        public static List<Customer> GetTwentyFirstFrenchCustomers()
        {
            SqlConnection connection = ConnectionSQL.GetConnectionSQL();
            List<Customer> listOfCustomers = new List<Customer>();

            try
            {
                using (connection)
                {

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "SELECT TOP (20) * FROM Customers WHERE Country=@Country";
                    command.Parameters.AddWithValue("@Country", "France");
                    
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        listOfCustomers.Add(
                            new Customer
                            {
                                CustomerID = dataReader["CustomerID"].ToString(),
                                CompanyName = dataReader["CompanyName"].ToString(),
                                ContactName = dataReader["Contactname"].ToString()
                            } 
                            );
                    }
                    dataReader.Close();
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception:" + exc.Message);
            }
            connection.Close();
            return listOfCustomers;
        }


        // Récupérer le résultat de la procédure CustOrderHist pour le customerId BLONP

        public static Dictionary<string, string> GetCustOrderHist(string customerID)
        {
            Dictionary<string, string> myDict = new Dictionary<string, string>();

            SqlConnection connection = ConnectionSQL.GetConnectionSQL();

            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("CustOrderHist", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CustomerID", customerID);

                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {

                        myDict.Add(
                            dataReader[0].ToString(), dataReader[1].ToString()
                            );
                    }
                    dataReader.Close();
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception:" + exc.Message);
            }
            connection.Close();

            // En provenance de la DB // procédure CustOrderHist
            // ProductName, Total=SUM(Quantity)

            return myDict;
        }

        public static void AddCustomer(Customer customer)
        {

            SqlConnection connection = ConnectionSQL.GetConnectionSQL();

            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText =
                        "INSERT INTO dbo.Customers (CustomerID, CompanyName, ContactName) VALUES (@CustomerID, @CompanyName, @ContactName)";
                    command.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                    command.Parameters.AddWithValue("@CompanyName", customer.CompanyName);
                    command.Parameters.AddWithValue("@ContactName", customer.ContactName);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception:" + exc.Message);
            }
            connection.Close();

        }


        internal static void ModifyCustomer(string customerID, string field, string value)
        {

            SqlConnection connection = ConnectionSQL.GetConnectionSQL();

            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText =
                        "UPDATE dbo.Customers SET Country=@value WHERE CustomerID=@CustomerID";
                    command.Parameters.AddWithValue("@CustomerID", customerID);
                    // command.Parameters.AddWithValue("@field", "Country");
                    command.Parameters.AddWithValue("@value", value);
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
