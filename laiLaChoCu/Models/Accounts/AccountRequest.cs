using System.ComponentModel.DataAnnotations;

namespace laiLaChoCu.Models.Accounts
{
    public class AccountRequest
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
    }
}
