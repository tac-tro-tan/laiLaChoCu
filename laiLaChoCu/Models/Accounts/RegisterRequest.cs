using System.ComponentModel.DataAnnotations;

namespace laiLaChoCu.Models.Accounts
{
    public class RegisterRequest
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string FisrtName { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Url_Image { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
