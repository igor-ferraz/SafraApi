using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Safra.Domain.Models
{
    public class TransactionAmount
    {
        [JsonPropertyNameAttribute("amount")]
        public string Amount { get; set; }

        [JsonPropertyNameAttribute("currency")]
        public string Currency { get; set; }
    }

    public class TransactionBalance
    {
        [JsonPropertyNameAttribute("amount")]
        public TransactionAmount Amount { get; set; }

        [JsonPropertyNameAttribute("creditDebitIndicator")]
        public string CreditDebitIndicator { get; set; }

        [JsonPropertyNameAttribute("type")]
        public string Type { get; set; }
    }

    public class ProprietaryBankTransactionCode
    {
        [JsonPropertyNameAttribute("code")]
        public string Code { get; set; }

        [JsonPropertyNameAttribute("issuer")]
        public string Issuer { get; set; }
    }

    public class BankTransactionCode
    {
        [JsonPropertyNameAttribute("code")]
        public string Code { get; set; }

        [JsonPropertyNameAttribute("subCode")]
        public string SubCode { get; set; }
    }

    public class Transaction
    {
        [JsonPropertyNameAttribute("accountId")]
        public string AccountId { get; set; }

        [JsonPropertyNameAttribute("transactionId")]
        public string TransactionId { get; set; }

        [JsonPropertyNameAttribute("amount")]
        public TransactionAmount Amount { get; set; }

        [JsonPropertyNameAttribute("creditDebitIndicator")]
        public string CreditDebitIndicator { get; set; }

        [JsonPropertyNameAttribute("status")]
        public string Status { get; set; }

        [JsonPropertyNameAttribute("bookingDateTime")]
        public DateTime BookingDateTime { get; set; }

        [JsonPropertyNameAttribute("valueDateTime")]
        public DateTime ValueDateTime { get; set; }

        [JsonPropertyNameAttribute("transactionInformation")]
        public string TransactionInformation { get; set; }

        [JsonPropertyNameAttribute("bankTransactionCode")]
        public BankTransactionCode BankTransactionCode { get; set; }

        [JsonPropertyNameAttribute("proprietaryBankTransactionCode")]
        public ProprietaryBankTransactionCode ProprietaryBankTransactionCode { get; set; }

        [JsonPropertyNameAttribute("balance")]
        public TransactionBalance Balance { get; set; }
    }

    public class TransactionData
    {
        [JsonPropertyNameAttribute("transaction")]
        public List<Transaction> Transaction { get; set; }
    }

    public class TransactionLink
    {
        [JsonPropertyNameAttribute("self")]
        public string Self { get; set; }
    }

    public class TransactionResult
    {
        [JsonPropertyNameAttribute("data")]
        public TransactionData Data { get; set; }

        [JsonPropertyNameAttribute("links")]
        public TransactionLink Links { get; set; }
    }
}
