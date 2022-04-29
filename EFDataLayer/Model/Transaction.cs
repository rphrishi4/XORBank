using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataLayer.Model
{
    [Table("Transaction")]
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }
        [MaxLength(450)]
        
        public int FromAccountNo { get; set; }
        public int ToAccountNo { get; set; }
        public Double FromAccountBalance { get; set; }
        public Double ToAccountBalance { get; set; }
      
        public DateTime TransactionDate { get; set; }
        [MaxLength(450)]
        public Double TransactionAmount { get; set; }
        [MaxLength(20)]
        public string TransactionType { get; set; }
        [MaxLength(450)]
        public string Description { get; set; }







    }
}
