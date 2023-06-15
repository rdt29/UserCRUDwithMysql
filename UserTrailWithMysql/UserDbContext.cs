using Microsoft.EntityFrameworkCore;
using UserTrailWithMysql.Entites;

namespace UserTrailWithMysql
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        public DbSet<User> users { get; set; }
        public DbSet<Role> role { get; set; }
        public DbSet<Account> account { get; set; }
    }
}