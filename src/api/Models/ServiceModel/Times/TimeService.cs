using api.Data.Context;
using api.Models.EntityModel.Times;
using api.Models.EntityModel.WorkedTimes;
using api.Models.Interfaces;
using api.Models.ViewModel.Times;
using Microsoft.EntityFrameworkCore;

namespace api.Models.ServiceModel.Times
{
    public class TimeService : ITimeService
    {
        private readonly ApiDbContext? _dbContext;
        private readonly IJobService _jobService;
        private readonly IWorkedTimeService _workedService;
        private readonly IProjectService _projectService;


        public TimeService(ApiDbContext dbContext,
        IJobService jobService,
        IWorkedTimeService workedService,
        IProjectService projectService)
        {
            _dbContext = dbContext;
            _jobService = jobService;
            _workedService = workedService;
            _projectService = projectService;
        }

        public Time Time { get; private set; }
        public List<Time> Times { get; private set; }
        private const string TIME_RECORDING_ERROR = "TIME_RECORDING_ERROR";
        private const string TIME_NOT_REGISTERED = "TIME_NOT_REGISTERED";
        private const string TIME_NOT_FOUND = "TIME_NOT_FOUND";
        private const string PROJECT_NOT_FOUND = "PROJECT_NOT_FOUND";
        private const string JOB_NOT_FOUND = "JOB_NOT_FOUND";
        private const string USER_NOT_FOUND = "USER_NOT_FOUND";
        private const string TIME_UPDATE_ERROR = "TIME_UPDATE_ERROR";

        public async Task<(Time time, string error)> CreateTime(Time time, int userId)
        {
            if (!await _jobService.CheckJobExisting(time.JobId))
                return (null, JOB_NOT_FOUND);

            try
            {
                _dbContext.Times.Add(time);

                // get workedTime and calculate
                var result = await _workedService.GetWorkedTimeByJob(time.JobId);

                var workedTime = new WorkedTime();

                if (result.worked == null)
                {
                    workedTime.JobId = time.JobId;
                    _dbContext.WorkedTimes.Add(workedTime);
                }
                else
                {
                    //get time
                    var (times, error) = await GetTimesByJob(time.JobId, userId);

                    var endendTime = times.Where(t => t.EndedAt != null && t.StartedAt == time.StartedAt).SingleOrDefault();

                    GetTime(result.worked, endendTime);
                }

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                return (null, TIME_RECORDING_ERROR);
            }

            return (time, null);
        }

        private void GetTime(WorkedTime workTime, Time time)
        {
            TimeSpan totalElapsedTime = TimeSpan.Zero;
            TimeSpan elapsedTime = time.EndedAt.Value - time.StartedAt;
            totalElapsedTime += elapsedTime;

            decimal totalHours = (decimal)totalElapsedTime.TotalHours;

            if (workTime.Hours == null)
            {
                workTime.Hours = totalHours;
                CalculateTime(workTime);
            }
            else
            {
                workTime.Hours += totalHours;

                CalculateTime(workTime);
            }
        }

        private void CalculateTime(WorkedTime workTime)
        {
            if (workTime.Hours >= 8)
            {
                decimal days = Math.Floor((decimal)workTime.Hours / 8);
                decimal remainingHours = (decimal)workTime.Hours % 8;

                workTime.Days += (int)days;
                workTime.Hours = remainingHours;

                if (days >= 30)
                {
                    decimal months = Math.Floor(days / 30);
                    decimal remainingDays = days % 30.44m;

                    workTime.Months = (int)months;
                    workTime.Days = (int)remainingDays;
                }
            }
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

        public async Task<(Time time, string error)> UpdateTime(TimeModel model, int timeId, int jobId, int userId)
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

                // get workedTime and calculate
                var result = await _workedService.GetWorkedTimeByJob(model.JobId);

                if (result.worked != null)
                {

                    //get time
                    // var (times, error) = await GetTimesByJob(model.JobId, userId);

                    // var endendTime = times.Where(t => t.EndedAt != null && t.StartedAt == model.StartedAt).SingleOrDefault();
                    // var endendTime = times.Where(t => t.EndedAt == null && t.StartedAt == model.StartedAt).SingleOrDefault();

                    GetTime(result.worked, Time);

                    var project = await _projectService.GetProjectByJob(jobId);

                    if (project is null)
                        return (null, PROJECT_NOT_FOUND);

                    var response = await _workedService.GetWorkedTimeByProject(project.Id);
                    var workedTime = new WorkedTime();

                    if (response.worked == null)
                    {
                        workedTime.ProjectId = project.Id;
                        GetTime(workedTime, Time);
                        _dbContext.WorkedTimes.Add(workedTime);
                    }
                    else
                    {
                        GetTime(response.worked, Time);
                    }
                }

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