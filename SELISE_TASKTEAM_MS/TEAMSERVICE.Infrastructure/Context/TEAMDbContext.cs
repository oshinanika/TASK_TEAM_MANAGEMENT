using Microsoft.EntityFrameworkCore;
using TEAMSERVICE.Core.Entities;

namespace TEAMSERVICE.Infrastructure.Context
{
    public class TEAMDbContext : DbContext
    {
        public TEAMDbContext(DbContextOptions<TEAMDbContext> options) : base(options) { }

        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("SELISE_TEAMS");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Name).HasColumnName("NAME").HasMaxLength(100);
                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");
            });
        }
    }
}
