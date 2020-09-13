using System.Collections.Generic;

namespace Safra.Domain.Models
{
    public class Account
    {
        public string SchemeName { get; set; }
        public string Identification { get; set; }
        public string Name { get; set; }
        public string SecondaryIdentification { get; set; }
    }

    public class AccountInfo
    {
        public string AccountId { get; set; }
        public string Currency { get; set; }
        public string Nickname { get; set; }
        public Account Account { get; set; }
    }

    public class AccountData
    {
        public List<AccountInfo> Account { get; set; }
    }

    public class Link
    {
        public string Self { get; set; }
    }

    public class BasicAccount
    {
        public AccountData Data { get; set; }
        public Link Links { get; set; }
    }
}
