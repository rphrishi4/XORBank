using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankSystem.Models
{
    public class AccountViewModel
    {
        public int AccountNo { get; set; }
        [Required]
        public string AccountType { get; set; }

        public DateTime CreateDate { get; set; }
        [Required]
        public Double Balance { get; set; }
        public string CustomerId { get; set; }

        public string CustomerEmail { get; set; }
        public Customer Customer { get; set; }
    }
}
