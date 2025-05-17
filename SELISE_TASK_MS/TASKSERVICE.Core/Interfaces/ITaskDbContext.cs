using Microsoft.EntityFrameworkCore;
using TASKSERVICE.Core.Entities;

namespace TASKSERVICE.Core.Interfaces
{
    public interface ITaskDbContext
    {
        DbSet<TaskItems> Tasks { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
