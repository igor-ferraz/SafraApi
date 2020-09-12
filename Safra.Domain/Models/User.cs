using System;

namespace Safra.Domain.Models
{
    public class User
    {
        public string ClientId { get; set; }
        public string Secret { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public DateTime CreationDate { get; set; }
        public string AccountId { get; set; }
    }
}
