namespace MediCheck_2._0.Models
{
    public class Stock
    {
        //variable declaration
        public string productID { get; set; }
        public string farmerID { get; set; }
        public string productName { get; set; }
        public DateTime date_added { get; set; } = DateTime.Now;
        public string productType { get; set; }
        public int quantity { get; set; }

        //Empty constructor
        public Stock()
        {
            this.productID = "No ID";
            this.farmerID = "No ID";
            this.productName = "No Name";
            this.date_added = DateTime.Now;
            this.productType = "No type";
            this.quantity = 0;
        }

        //populated constructor
        public Stock(string productID, string farmerID, string productName, DateTime date_added, string productType, int quantity)
        {
            this.productID = productID;
            this.farmerID = farmerID;
            this.productName = productName;
            this.date_added = date_added;
            this.productType = productType;
            this.quantity = quantity;
        }
    }
}
