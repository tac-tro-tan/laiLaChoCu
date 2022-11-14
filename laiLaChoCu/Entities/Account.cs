using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace laiLaChoCu.Entities
{
    public class Account
    {
        public Account(string title, string fisrtName, string lastname,string url_Image, string address, string phone, string email, string password)
        {
            this.Title = title;
            this.FisrtName = fisrtName;
            this.Lastname = lastname;
            this.Url_Image = url_Image;
            this.Address = address;
            this.Phone = phone;
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
    }
}
