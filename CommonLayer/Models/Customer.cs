using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Models
{
    public class Customer
    {
       
        public string CustomerId { get; set; }
       
        public string CustomerName { get; set; }
     
        
        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string MobileNo { get; set; }
     
        public string EmailId { get; set; }
       
        public String Address { get; set; }
       
        public string City { get; set; }
      
        public string State { get; set; }

        public int Pin { get; set; }
        public int IsDeleted { get; set; }
    }
}

