﻿using System;

namespace Safra.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ChangeDate { get; set; }
        public string AccountId { get; set; }
    }
}
