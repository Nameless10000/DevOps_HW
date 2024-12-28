using DevOps_HW.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevOps_HW
{
    public class AppDbContext(DbContextOptions<AppDbContext> opts) : DbContext(opts)
    {
        public DbSet<User> Users { get; set; }
    }
}
