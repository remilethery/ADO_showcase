using System;
using System.Configuration;
using System.Data.SqlClient;

namespace NorthwindDB2
{
    internal class ConnectionSQL
    {
        public static SqlConnection GetConnectionSQL()
        {
            // Création d'une nouvelle connexion SQL
            SqlConnection con = new SqlConnection();
            try
            {   
                // Configuration de la connectionString
                con.ConnectionString = ConfigurationManager.ConnectionStrings["NorthwindDB"].ConnectionString;
                // Connexion à la base de données
                con.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return con;

        }

        
    }
}