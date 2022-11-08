using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace laiLaChoCu.Entities
{
    public class Role
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<Account> Accounts { get; set; }
    }
}
