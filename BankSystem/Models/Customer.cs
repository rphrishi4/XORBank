using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankSystem.Models
{
    public class Customer
    {
        public string CustomerId { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string Gender { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        [Required]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string MobileNo { get; set; }
        [Required]
        public string EmailId { get; set; }
        [Required]
        public String Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public int Pin { get; set; }
    }
}
