using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace laiLaChoCu.Entities
{
    public class Account
    {
        public Account(string title, string fisrtName, string lastname, string address, string phone, string email, string password)
        {
            Title = title;
            FisrtName = fisrtName;
            Lastname = lastname;
            Address = address;
            Phone = phone;
            Email = email;
            Password = password;
        }

        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string FisrtName { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public List<Role> Roles { get; set; }
    }
}
