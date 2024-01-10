using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.EntityModel.Projects;
using api.Models.EntityModel.Times;
using api.Models.EntityModel.Users;

namespace api.Models.EntityModel.Jobs
{
    public class Job
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? LastUpdateAt { get; set; }
        public User User { get; set; }
        public Project Project { get; set; }
        public ICollection<Time?> Times { get; set; }
    }
}