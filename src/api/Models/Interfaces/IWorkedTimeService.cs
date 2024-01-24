using api.Models.EntityModel.Times;
using api.Models.EntityModel.WorkedTimes;
using api.Models.ViewModel.Times;

namespace api.Models.Interfaces
{
    public interface IWorkedTimeService
    {
        // Task<(Time time, string error)> CreateTime(Time time);
        Task<(WorkedTime worked, string error)> GetWorkedTimeByJob(int jobId);
        Task<(WorkedTime worked, string error)> GetWorkedTimeByProject(int projectId);

        // Task<(Time time, string error)> UpdateTime(TimeModel model, int timeId, int userId);
    }
}