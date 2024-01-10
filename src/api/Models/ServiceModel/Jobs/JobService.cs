using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data.Context;
using api.Models.EntityModel.Jobs;
using api.Models.EntityModel.Projects;
using api.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Models.ServiceModel.Jobs
{
    public class JobService : IJobService
    {
        private readonly ApiDbContext? _dbContext;
        private readonly IUserService _userService;
        private readonly IProjectService _projectService;


        public JobService(ApiDbContext dbContext, IUserService userService, IProjectService projectService)
        {
            _dbContext = dbContext;
            _userService = userService;
            _projectService = projectService;
        }

        public Job Job { get; private set; }
        private const string PROJECT_REGISTER_ERROR = "PROJECT_REGISTER_ERROR";
        private const string PROJECT_UPDATE_ERROR = "PROJECT_UPDATE_ERROR";
        private const string PROJECT_NOT_FOUND = "PROJECT_NOT_FOUND";
        private const string PROJECT_NOT_EXISTS = "PROJECT_NOT_EXISTS";
        private const string USER_NOT_FOUND = "USER_NOT_FOUND";


        public async Task<List<Job>> GetAllProjects(int userId)
            => await _dbContext.Jobs
                                        // .IncludeTimes()
                                        // .IncludeUserProject()
                                        // .WhereUserId(userId)
                                        .ToListAsync();
        public async Task<(bool success, Job job, string error)> FindJob(int jobId)
        {
            Job = await _dbContext.Jobs
                                               // .WhereId(projectId)
                                               //    .IncludeTimes()
                                               //    .IncludeUserProject()
                                               .SingleOrDefaultAsync();

            if (Job is null)
                return (false, null, PROJECT_NOT_FOUND);

            return (true, Job, null);
        }

        public async Task<(Job job, string error)> CreateJob(Job model)
        {
            if (!await _projectService.CheckProjectExisting(model.ProjectId))
                return (null, PROJECT_NOT_EXISTS);

            if (!await _userService.CheckUserExisting(model.UserId))
                return (null, USER_NOT_FOUND);

            try
            {
                _dbContext.Jobs.AddRange(model);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                return (null, PROJECT_REGISTER_ERROR);
            }

            return (model, null);
        }

        public async Task<bool> CheckJobExisting(int jobId)
        {
            bool jobExists = await _dbContext.Jobs.WhereId(jobId).AnyAsync();

            return jobExists;
        }
    }
}