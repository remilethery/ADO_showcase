namespace NorthwindDB2
{
    internal class Customer
    {

        private string customerID;
        private string companyName;
        private string contactName;

        public string CustomerID { get => customerID; set => customerID = value; }
        public string CompanyName { get => companyName; set => companyName = value; }
        public string ContactName { get => contactName; set => contactName = value; }

    }
}