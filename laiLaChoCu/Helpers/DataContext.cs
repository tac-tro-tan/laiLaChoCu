using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static System.Net.Mime.MediaTypeNames;
using System.Data;
using System.Security.Principal;
using laiLaChoCu.Entities;

namespace laiLaChoCu.Helpers
{
    public class DataContext :DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Cart> Carts { get; set; }
        private readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
