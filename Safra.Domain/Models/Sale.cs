using System;
using System.Collections.Generic;
using System.Text;

namespace Safra.Domain.Models
{
    public class Sale
    {
        public Guid Id { get; set; }
        public string AccountId { get; set; }
        public bool AlreadyPaid { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime CreationDate { get; set; }
        public List<ProductSale> Products { get; set; }
    }
}
