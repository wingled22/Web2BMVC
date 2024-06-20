using System.ComponentModel.DataAnnotations;

namespace Web2BMVC.Models;

public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } =null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

  
    }
