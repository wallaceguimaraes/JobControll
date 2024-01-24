using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.EntityModel.Jobs;
using api.Models.EntityModel.Projects;

namespace api.Models.EntityModel.WorkedTimes
{
    public class WorkedTime
    {
        public WorkedTime()
        {
        }
        public int Id { get; set; }
        public int? ProjectId { get; set; }
        public int? JobId { get; set; }
        public decimal? Hours { get; set; }
        public int? Days { get; set; }
        public int? Months { get; set; }
        public Project Project { get; set; }
        public Job Job { get; set; }
    }
}