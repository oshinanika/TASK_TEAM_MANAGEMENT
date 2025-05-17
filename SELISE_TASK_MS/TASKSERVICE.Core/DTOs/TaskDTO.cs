namespace TASKSERVICE.Core.DTOs
{
    public class CreateTaskDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } // "Todo", "InProgress", "Done"
        public Guid AssignedToUserId { get; set; }
        public Guid CreatedByUserId { get; set; }
        public Guid TeamId { get; set; }
        public DateTime DueDate { get; set; }
    }

    public class UpdateTaskStatusDto
    {
        public string Status { get; set; } // Only Employee updates
    }
}
