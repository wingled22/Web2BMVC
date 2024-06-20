using System.ComponentModel.DataAnnotations;

namespace Web2BMVC.Models;

public class RegisterViewModel
    {
        [Required]
         public string? Fullname { get; set; }
         [Required]
        public int? Age { get; set; }
        [Required]
        public string? Address { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
