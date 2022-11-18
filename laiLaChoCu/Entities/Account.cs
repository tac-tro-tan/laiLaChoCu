using laiLaChoCu.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace laiLaChoCu.Entities
{
    public class Account
    {
        public Account(string title, string fisrtName, string lastname, string address, string phone,string url_Image, string email, string password)
        {
            this.Title = title;
            this.FisrtName = fisrtName;
            this.Lastname = lastname;
            this.Address = address;
            this.Phone = phone;
            this.Url_Image = url_Image;
            this.Email = email;
            this.Password = password;
        }

        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string FisrtName { get; set; }
        public string Lastname { get; set; }
        public string Url_Image { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public List<Role> Roles { get; set; }
        public StatusEnum Status { get; set; }
    }
}
