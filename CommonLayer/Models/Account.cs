using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Models
{
    public class Account
    {
        public int AccountNo { get; set; }
       
        public string AccountType { get; set; }

        public DateTime CreateDate { get; set; }
        public Double Balance { get; set; }
        public string CustomerId { get; set; }

        public string CustomerEmail { get; set; }
        public Customer Customer { get; set; }
        public int IsDeleted { get; set; }
    }
}

