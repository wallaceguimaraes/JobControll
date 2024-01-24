using api.Models.EntityModel.Jobs;
using api.Models.EntityModel.Projects;
using api.Models.EntityModel.Users;

namespace api.Models.EntityModel.Times
{
    public class Time
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }
        public Job? Job { get; set; }
    }
}