using api.Data.Context;
using api.Models.EntityModel.Times;
using api.Models.Interfaces;
using api.Models.ViewModel.Times;
using Microsoft.EntityFrameworkCore;

namespace api.Models.ServiceModel.Times
{
    public class TimeService : ITimeService
    {
        private readonly ApiDbContext? _dbContext;
        private readonly IJobService _jobService;


        public TimeService(ApiDbContext dbContext, IJobService jobService)
        {
            _dbContext = dbContext;
            _jobService = jobService;
        }

        public Time Time { get; private set; }
        public List<Time> Times { get; private set; }
        private const string TIME_RECORDING_ERROR = "TIME_RECORDING_ERROR";
        private const string TIME_NOT_REGISTERED = "TIME_NOT_REGISTERED";
        private const string TIME_NOT_FOUND = "TIME_NOT_FOUND";
        private const string JOB_NOT_FOUND = "JOB_NOT_FOUND";
        private const string USER_NOT_FOUND = "USER_NOT_FOUND";
        private const string TIME_UPDATE_ERROR = "TIME_UPDATE_ERROR";

        public async Task<(Time time, string error)> CreateTime(Time time)
        {
            if (!await _jobService.CheckJobExisting(time.JobId))
                return (null, JOB_NOT_FOUND);

            try
            {
                _dbContext.Times.Add(time);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                return (null, TIME_RECORDING_ERROR);
            }

            return (time, null);
        }

        public async Task<(List<Time> times, string error)> GetTimesByJob(int jobId, int userId)
        {
            Times = await _dbContext.Times.WhereJobId(jobId)
                                          .IncludeJob()
                                          .ToListAsync();
            if (!Times.Any())
                return (null, TIME_NOT_REGISTERED);

            return (Times, null);
        }

        public async Task<(Time time, string error)> UpdateTime(TimeModel model, int timeId, int jobId)
        {
            Time = await _dbContext.Times.WhereId(timeId)
                                         .WhereJobId(jobId)
                                         .SingleOrDefaultAsync();
            if (Time is null)
                return (null, TIME_NOT_FOUND);

            if (!await _jobService.CheckJobExisting(model.JobId))
                return (null, JOB_NOT_FOUND);

            Time = model.Map(Time);

            try
            {
                _dbContext.Times.Update(Time);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                return (null, TIME_UPDATE_ERROR);
            }

            return (Time, null);
        }


    }
}