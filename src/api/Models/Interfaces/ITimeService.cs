using api.Models.EntityModel.Times;
using api.Models.ViewModel.Times;

namespace api.Models.Interfaces
{
    public interface ITimeService
    {
        Task<(Time time, string error)> CreateTime(Time time, int userId);
        Task<(List<Time> times, string error)> GetTimesByJob(int jobId, int userId);
        Task<(Time time, string error)> UpdateTime(TimeModel model, int timeId, int jobId, int userId);
    }
}