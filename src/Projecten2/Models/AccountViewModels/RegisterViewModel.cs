using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projecten2.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Naam")]
        public String Naam { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Voornaam")]
        public String Voornaam { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Organisatie")]
        public String Organisatie { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Straat")]
        public String Straat { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [MaxLength(4)]
        [Display(Name = "Nr")]
        public int Nr { get; set; }


        [DataType(DataType.Text)]
        [MaxLength(4)]
        [Display(Name = "Bus")]
        public String Bus { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        [Display(Name = "Postcode")]
        public int Postcode { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [MinLength(3)]
        [Display(Name = "Plaats")]
        public String Plaats { get; set; }
    }
}
