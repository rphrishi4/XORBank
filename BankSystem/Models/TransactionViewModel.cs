using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankSystem.Models
{
    public class TransactionViewModel
    {
        public int TransactionId { get; set; }

        public string CustomerId { get; set; }

        public int FromAccountNo { get; set; }
        public int ToAccountNo { get; set; }
        [DataType(DataType.Date)]
        public DateTime FromDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime ToDate { get; set; }
        public Double FromAccountBalance { get; set; }
        public Double ToAccountBalance { get; set; }
        public DateTime TransactionDate { get; set; }

        public Double TransactionAmount { get; set; }

        public string TransactionType { get; set; }
        public string Description { get; set; }

    }
}
