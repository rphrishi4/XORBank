using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Models
{
   public  class Transaction
    {
        public int TransactionId { get; set; }
       
       

        public int FromAccountNo { get; set; }
        public int ToAccountNo { get; set; }
        public double FromAccountBalance { get; set; }
        public int ToAccountBalance { get; set; }


        public DateTime TransactionDate { get; set; }
        
        public Double TransactionAmount { get; set; }

        public string TransactionType { get; set; }
        public string Description { get; set; }
    }
}
