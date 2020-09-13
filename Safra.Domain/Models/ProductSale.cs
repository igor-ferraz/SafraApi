namespace Safra.Domain.Models
{
    public class ProductSale
    {
        public int ProductId { get; set; }
        public int SaleId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
