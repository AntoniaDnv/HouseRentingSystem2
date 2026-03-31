using System.ComponentModel.DataAnnotations;

namespace HouseRentingSystem.Models
{
    public class LoginViewModel
    {
        [Required]
        [MaxLength(20,MinimumLength = 3, ErrorMessage ="Invalid Username")]
        public string Username { get; set; }
        [Required]
        [MaxLength(20, MinimumLength = 6, ErrorMessage = "Invalid Password")]
        public string Password { get; set; }
        public string RememberMe { get; set; }
    }
}
