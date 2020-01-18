using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDB2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Configurer la connection à NorthWindDb
             => Classe + Méthode de connexion */
          
            // Créer une méthode qui récupére les 20 premiers Customers vivant en France et renvoie une liste
            List<Customer> myList = SQLRequests.GetTwentyFirstFrenchCustomers();
            Console.WriteLine("Affichage des 20 premiers custo vivant en France");
            foreach (Customer custo in myList)
            {
                Console.WriteLine("Customer ID: {0}", custo.CustomerID) ;
                Console.WriteLine("Company Name: {0}", custo.CompanyName); 
                Console.WriteLine("Contact Name: {0}", custo.ContactName);
            }
            Console.ReadKey();


            // Récupérer le résultat de la procédure CustOrderHist pour le customerId BLONP

            Dictionary<string, string> prodList = new Dictionary<string, string>();
            prodList = SQLRequests.GetCustOrderHist("BLONP");

            foreach (KeyValuePair<string, string> kvp in prodList)
            {
                Console.WriteLine("Key = {0}, Value = {1}",
                    kvp.Key, kvp.Value);
            }
            Console.ReadKey();


            // Insérer une nouvelle ligne dans la table Customers
            /* Customer JeanJean = new Customer
            {
                CustomerID = "JEANJ",
                CompanyName = "MaisOui",
                ContactName = "Jean Foutre"
            };
            SQLRequests.AddCustomer(JeanJean);
            */

            // Modifier le pays de cette meme ligne
            // SQLRequests.ModifyCustomer("JEANJ", "Country", "Fronce");

            // GetCustomerById De la classe CustomerRepository
            Customer jeanj = CustomerRepository.GetCustomer("JEANJ");
            Console.WriteLine(
                "Custo ID : {0} ; Company name : {1} ; Contact name : {2}",
                jeanj.CustomerID, jeanj.CompanyName, jeanj.ContactName);

            // GetCustomerByCountry
            Customer jeanj2 = CustomerRepository.GetCustomerByCountry("Fronce");
            Console.WriteLine(
               "Custo ID : {0} ; Company name : {1} ; Contact name : {2}",
               jeanj.CustomerID, jeanj.CompanyName, jeanj.ContactName);

            // ModifyCustomerCity - update la ville du customer
            CustomerRepository.ModifyCustomerCity(jeanj, "ParisTexas");
            Console.ReadKey();

            // DeleteCustomerByName
            CustomerRepository.DeleteCustomerByName("JEANJ");


        }
    }
}
