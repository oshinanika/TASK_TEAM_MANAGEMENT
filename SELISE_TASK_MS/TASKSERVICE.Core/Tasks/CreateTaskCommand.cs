using MediatR;
using TASKSERVICE.Core.DTOs;

namespace TASKSERVICE.Core.Tasks
{
    public record CreateTaskCommand(CreateTaskDto Task) : IRequest<Guid>;
}
