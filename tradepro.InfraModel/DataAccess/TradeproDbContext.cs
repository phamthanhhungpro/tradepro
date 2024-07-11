using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace tradepro.InfraModel.DataAccess
{

    public class TradeproDbContext : IdentityDbContext<User,Role,Guid>
    {
        public TradeproDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles {  get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>();
            builder.Entity<Role>();
        }

  
    }
    
}
