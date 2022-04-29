using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankSystem.Models
{
    public class UserPassword
    {
       
        [Display(Name = "Enter Email Id")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "The password id required")]
        [MinLength(5, ErrorMessage = "Password cannot br short")]
        [DataType(DataType.Password)]

        public string OldPassword { get; set; }

        [Required(ErrorMessage = "The password id required")]
        [MinLength(5, ErrorMessage = "Password cannot br short")]
        [DataType(DataType.Password)]

        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirm password does not match")]
        public string ConfirmPassword { get; set; }
    }
}
