using api.Models.EntityModel.Jobs;
using api.Models.EntityModel.UserProjects;
using api.Models.EntityModel.WorkedTimes;

namespace api.Models.EntityModel.Projects
{
    public class Project
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? LastUpdateAt { get; set; }
        public ICollection<Job>? Jobs { get; set; }
        public ICollection<UserProject>? UserProjects { get; set; }
        public WorkedTime? WorkedTime { get; set; }
    }
}