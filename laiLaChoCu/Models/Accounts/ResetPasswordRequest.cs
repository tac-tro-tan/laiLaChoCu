using System.ComponentModel.DataAnnotations;

namespace laiLaChoCu.Models.Accounts
{
    public class ResetPasswordRequest
    {
        [Required]
        public string OldPassword { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
