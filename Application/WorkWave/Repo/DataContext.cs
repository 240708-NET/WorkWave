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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // User and Board relationship
        modelBuilder.Entity<User>()
            .HasMany(u => u.Boards)
            .WithMany(b => b.Users)
            .UsingEntity<Dictionary<string, object>>(
                "UserBoard",
                l => l.HasOne<Board>().WithMany().HasForeignKey("BoardID").HasPrincipalKey(nameof(Board.ID)),
                r => r.HasOne<User>().WithMany().HasForeignKey("UserID").HasPrincipalKey(nameof(User.ID)),
                j => j.HasKey("BoardID", "UserID")
            );

        // User and Card relationship
        modelBuilder.Entity<User>()
            .HasMany(u => u.Cards)
            .WithMany(c => c.UsersAssigned)
            .UsingEntity<Dictionary<string, object>>(
                "UserCard",
                l => l.HasOne<Card>().WithMany().HasForeignKey("CardID").HasPrincipalKey(nameof(Card.ID)),
                r => r.HasOne<User>().WithMany().HasForeignKey("UserID").HasPrincipalKey(nameof(User.ID)),
                j => j.HasKey("CardID", "UserID")
            );

        // Board and Section relationship
        modelBuilder.Entity<Section>()
            .HasOne(s => s.Board)
            .WithMany(b => b.Sections)
            //.HasForeignKey(s => s.BoardID)
            .OnDelete(DeleteBehavior.Cascade);

        // Section and Card relationship
        modelBuilder.Entity<Card>()
            .HasOne(c => c.Section)
            .WithMany(s => s.Cards)
            //.HasForeignKey(c => c.SectionID)
            .OnDelete(DeleteBehavior.Cascade);

        // Card and Tag relationship
        modelBuilder.Entity<Card>()
            .HasMany(c => c.Tags)
            .WithMany(t => t.Cards)
            .UsingEntity<Dictionary<string, object>>(
                "CardTag",
                j => j.HasOne<Tag>().WithMany().HasForeignKey("TagID"),
                j => j.HasOne<Card>().WithMany().HasForeignKey("CardID")
            );
    }

    }
}
