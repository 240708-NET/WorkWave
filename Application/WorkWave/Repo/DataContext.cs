using Microsoft.EntityFrameworkCore;
using Models;

namespace Repository
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Card> Cards => Set<Card>();
        public DbSet<Board> Boards => Set<Board>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<Section> Sections => Set<Section>();
        
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
