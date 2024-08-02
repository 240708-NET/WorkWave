using Microsoft.EntityFrameworkCore;
using Models;

namespace Repository
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
