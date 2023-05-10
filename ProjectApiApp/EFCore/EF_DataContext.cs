using Microsoft.EntityFrameworkCore;

namespace ProjectApiApp.EFCore
{
    public class EF_DataContext : DbContext
    {    
        public EF_DataContext(DbContextOptions<EF_DataContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name);
                entity.HasOne(x => x.Parent)
                    .WithMany(x => x.SubItems)
                    .HasForeignKey(x => x.ParentId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}

