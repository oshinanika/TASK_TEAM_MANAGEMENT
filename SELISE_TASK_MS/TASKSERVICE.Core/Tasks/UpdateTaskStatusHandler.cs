using MediatR;
using Microsoft.EntityFrameworkCore;
using TASKSERVICE.Core.Interfaces;


namespace TASKSERVICE.Core.Tasks
{
    public class UpdateTaskStatusHandler : IRequestHandler<UpdateTaskStatusCommand, bool>
    {
        private readonly ITaskDbContext _db;

        public UpdateTaskStatusHandler(ITaskDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(UpdateTaskStatusCommand request, CancellationToken cancellationToken)
        {
            var task = await _db.Tasks.FirstOrDefaultAsync(t => t.Id == request.TaskId, cancellationToken);
            if (task == null) return false;

            task.Status = request.Status;
            await _db.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
