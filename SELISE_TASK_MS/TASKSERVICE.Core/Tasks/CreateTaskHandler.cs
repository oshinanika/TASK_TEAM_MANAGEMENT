using MediatR;
using TASKSERVICE.Core.Entities;
using TASKSERVICE.Core.Interfaces;


namespace TASKSERVICE.Core.Tasks
{
    public class CreateTaskHandler : IRequestHandler<CreateTaskCommand, Guid>
    {
        private readonly ITaskDbContext _context;
        public CreateTaskHandler(ITaskDbContext context) => _context = context;

        public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken ct)
        {
            var task = new TaskItems
            {
                Id = Guid.NewGuid(),
                Title = request.Task.Title,
                Description = request.Task.Description,
                AssignedToUserId = request.Task.AssignedToUserId,
                TeamId = request.Task.TeamId,
                DueDate = request.Task.DueDate,
                Status = "Todo"
            };
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync(ct);
            return task.Id;
        }
    }
}
