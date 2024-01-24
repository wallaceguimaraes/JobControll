using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.EntityModel.Jobs;
using api.Models.EntityModel.WorkedTimes;

namespace api.Models.Interfaces
{
    public interface IJobService
    {
        Task<(Job job, string error)> CreateJob(Job job);
        Task<bool> CheckJobExisting(int jobId);
        Task<List<Job>> GetAllJobs(int userId);
        Task<List<Job>> GetJobsByProject(int projectId);
    }
}