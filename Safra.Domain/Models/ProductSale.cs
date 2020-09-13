using System;

namespace Safra.Domain.Models
{
    public class ProductSale
    {
        public int ProductId { get; set; }
        public Guid SaleId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public Product ProductReference { get; set; }
    }
}
