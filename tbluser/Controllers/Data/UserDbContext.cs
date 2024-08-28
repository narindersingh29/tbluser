using Microsoft.EntityFrameworkCore;
using tbluser.Models.DBEntities;

namespace tbluser.Controllers.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
