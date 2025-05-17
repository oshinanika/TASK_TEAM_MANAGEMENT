namespace TEAMSERVICE.Core.DTO
{
    public class CreateTeamDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class UpdateTeamDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class TeamDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

}
