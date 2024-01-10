using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.EntityModel.Jobs;

namespace api.Models.Interfaces
{
    public interface IJobService
    {
        Task<(Job job, string error)> CreateJob(Job job);
        Task<bool> CheckJobExisting(int jobId);
    }
}