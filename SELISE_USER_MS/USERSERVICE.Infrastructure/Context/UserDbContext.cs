using Microsoft.EntityFrameworkCore;
using USERSERVICE.Core.Entities;

namespace USERSERVICE.Infrastructure.Context
{
    public class UserDbContext : DbContext
    {
        //inheritance parametered contrustor
        public UserDbContext(DbContextOptions<UserDbContext> options)
         : base(options) { }

        public DbSet<AppUser23456> SELISE_USERS23456 { get; set; }
        // public DbSet<AppUser> PRACTICE_USERS_2 { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser23456>(entity =>
            {
                entity.ToTable("SELISE_USERS");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("ID");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("PASSWORD_HASH");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("ROLE");

                // Seed data
                entity.HasData(
                    new AppUser23456
                    {
                        Id = Guid.NewGuid(),
                        FullName = "Admin User",
                        Email = "admin@demo.com",
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123!"),
                        Role = "Admin"
                    },
                    new AppUser23456
                    {
                        Id = Guid.NewGuid(),
                        FullName = "Manager User",
                        Email = "manager@demo.com",
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("Manager123!"),
                        Role = "Manager"
                    },
                    new AppUser23456
                    {
                        Id = Guid.NewGuid(),
                        FullName = "Employee User",
                        Email = "employee@demo.com",
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("Employee123!"),
                        Role = "Employee"
                    }
                );
            });
        }

    }
}
