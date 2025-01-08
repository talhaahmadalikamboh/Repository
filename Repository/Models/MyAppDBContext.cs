using Microsoft.EntityFrameworkCore;

namespace Repository.Models
{
    public class MyAppDBContext : DbContext
    {
        public MyAppDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Prodect1> Prodect1 { get; set; }
    }
}
