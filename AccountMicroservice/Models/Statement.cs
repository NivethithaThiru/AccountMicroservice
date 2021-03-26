using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountMicroservice.Models
{
    public class Statement
    {
        public string TransactionID { get; set; }
        public int AccountId { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime ValueDate { get; set; }
        //public string Reference { get; set; }
        public double Debit { get; set; }
        public double Credit { get; set; }
        public double BalanceAmount { get; set; }
    }
}