using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataLayer.Model
{
    [Table("Customer")]
   public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MaxLength(450)]
        public string CustomerId { get; set; }
        [MaxLength(300)]
        public string CustomerName { get; set; }
        [MaxLength(10)]
        public string Gender { get; set; }
       
        public DateTime DateOfBirth { get; set; }
      
        public string MobileNo { get; set; }
        [MaxLength(256)]
        public string EmailId { get; set; }
        [MaxLength(500)]
        public String Address { get; set; }
        [MaxLength(30)]
        public string City { get; set; }
        [MaxLength(30)]
        public string State{ get; set; }
      
        public int Pin { get; set; }

        public int IsDeleted { get; set; }



    }
}
