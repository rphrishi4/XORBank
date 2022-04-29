using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataLayer.Model
{
    [Table("Account")]
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int AccountNo { get; set; }
        [MaxLength(10)]
        public string AccountType { get; set; }

        public DateTime CreateDate { get; set; }
        public Double Balance{ get; set; }


        [ForeignKey("CustomerID")]
        public string CustomerId { get; set; }
        public Customer Customer{ get; set; }

        public int IsDeleted { get; set; }
    }
}
