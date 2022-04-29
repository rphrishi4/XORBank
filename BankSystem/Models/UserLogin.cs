using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankSystem .Models
{
    public class UserLogin
    {
        [Display(Name ="Enter UserId")]
        [Required(ErrorMessage ="The Email Is is required")]
        [EmailAddress]
        public string LoginId { get; set; }

        [Required (ErrorMessage ="The password id required")]
        [Display(Name ="Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }
    }
}
