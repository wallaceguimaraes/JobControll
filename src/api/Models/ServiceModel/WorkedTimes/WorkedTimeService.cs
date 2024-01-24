using api.Data.Context;
using api.Models.EntityModel.Times;
using api.Models.EntityModel.WorkedTimes;
using api.Models.Interfaces;
using api.Models.ViewModel.Times;
using Microsoft.EntityFrameworkCore;

namespace api.Models.ServiceModel.WorkedTimes
{
    public class WorkedTimeService : IWorkedTimeService
    {
        private readonly ApiDbContext? _dbContext;
        private readonly IJobService _jobService;


        public WorkedTimeService(ApiDbContext dbContext, IJobService jobService)
        {
            _dbContext = dbContext;
            _jobService = jobService;
        }

        public WorkedTime Worked { get; private set; }
        public List<WorkedTime> Workeds { get; private set; }
        private const string TIME_RECORDING_ERROR = "TIME_RECORDING_ERROR";
        private const string TIME_NOT_REGISTERED = "TIME_NOT_REGISTERED";
        private const string WORKED_TIME_NOT_FOUND = "WORKED_TIME_NOT_FOUND";
        private const string JOB_NOT_FOUND = "JOB_NOT_FOUND";
        private const string USER_NOT_FOUND = "USER_NOT_FOUND";
        private const string TIME_UPDATE_ERROR = "TIME_UPDATE_ERROR";

        public async Task<(WorkedTime worked, string error)> GetWorkedTimeByJob(int jobId)
        {
            Worked = await _dbContext.WorkedTimes.WhereJobId(jobId)
                                                .SingleOrDefaultAsync();

            if (Worked == null)
                return (null, WORKED_TIME_NOT_FOUND);

            return (Worked, null);
        }

        public async Task<(WorkedTime worked, string error)> GetWorkedTimeByProject(int projectId)
        {
            Worked = await _dbContext.WorkedTimes.WhereProjectId(projectId)
                                               .SingleOrDefaultAsync();

            if (Worked == null)
                return (null, WORKED_TIME_NOT_FOUND);

            return (Worked, null);
        }
    }
}