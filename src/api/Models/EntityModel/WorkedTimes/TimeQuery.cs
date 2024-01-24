using Microsoft.EntityFrameworkCore;

namespace api.Models.EntityModel.WorkedTimes
{
    public static class WorkedTimeQuery
    {
        public static IQueryable<WorkedTime> WhereJobId(this IQueryable<WorkedTime> workeds, int jobId)
            => workeds.Where(w => w.JobId == jobId);
        public static IQueryable<WorkedTime> WhereProjectId(this IQueryable<WorkedTime> workeds, int projectId)
            => workeds.Where(w => w.ProjectId == projectId);
    }
}