using System;
using System.Collections.Generic;

namespace Safra.Domain.Models
{
    public class BalanceAmount
    {
        public string Amount { get; set; }
        public string Currency { get; set; }
    }
    public class CreditLine
    {
        public bool Included { get; set; }
        public string Type { get; set; }
        public BalanceAmount Amount { get; set; }
    }

    public class Balance
    {
        public string AccountId { get; set; }
        public string CreditDebitIndicator { get; set; }
        public string Type { get; set; }
        public DateTime DateTime { get; set; }
        public BalanceAmount Amount { get; set; }
        public List<CreditLine> CreditLine { get; set; }
    }

    public class BalanceData
    {
        public List<Balance> Balance { get; set; }
    }

    public class BalancesResult
    {
        public BalanceData Data { get; set; }
        public Link Links { get; set; }
    }
}
