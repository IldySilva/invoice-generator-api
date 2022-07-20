namespace GenerateInvoiceApi.Models
{
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public decimal PriceTotal { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
