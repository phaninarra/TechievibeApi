using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Techievibe.Api.Finance
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string OriginalDescription { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public string AccountName { get; set; }
        public string Labels { get; set; }
        public string Notes { get; set; }
    }

    public class TransactionMap : ClassMap<Transaction>
    {
        public TransactionMap()
        {
            Map(m => m.Date).Name("Date");
            Map(m => m.Description).Name("Description");
            Map(m => m.OriginalDescription).Name("Original Description");
            Map(m => m.Amount).Name("Amount");
            Map(m => m.Type).Name("Transaction Type");
            Map(m => m.Category).Name("Category");
            Map(m => m.AccountName).Name("Account Name");
            Map(m => m.Labels).Name("Labels");
            Map(m => m.Notes).Name("Notes");
        }
    }
}
