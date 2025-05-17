using MediatR;

namespace TASKSERVICE.Core.Tasks
{
    public class UpdateTaskStatusCommand : IRequest<bool>
    {
        public Guid TaskId { get; set; }
        public string Status { get; set; } = null!;
    }
}
