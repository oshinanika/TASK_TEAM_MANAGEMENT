using Microsoft.EntityFrameworkCore;
using TASKSERVICE.Core.Entities;
using TASKSERVICE.Core.Interfaces;

namespace TASKSERVICE.Infrastructure.Context
{
    public class TaskDbContext : DbContext, ITaskDbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }

        public DbSet<TaskItems> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItems>(entity =>
            {
                entity.ToTable("SELISE_TASKS");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Title).HasColumnName("TITLE").HasMaxLength(200);
                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");
                entity.Property(e => e.Status).HasColumnName("STATUS");
                entity.Property(e => e.AssignedToUserId).HasColumnName("ASSIGNED_TO_USER_ID");
                entity.Property(e => e.CreatedByUserId).HasColumnName("CREATED_BY_USER_ID");
                entity.Property(e => e.TeamId).HasColumnName("TEAM_ID");
                entity.Property(e => e.DueDate).HasColumnName("DUE_DATE");
            });
        }
    }

}
