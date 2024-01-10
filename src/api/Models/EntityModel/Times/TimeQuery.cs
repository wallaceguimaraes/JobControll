using Microsoft.EntityFrameworkCore;

namespace api.Models.EntityModel.Times
{
    public static class UserQuery
    {
        public static IQueryable<Time> WhereJobId(this IQueryable<Time> times, int jobId)
            => times.Where(time => time.JobId == jobId);

        public static IQueryable<Time> IncludeJob(this IQueryable<Time> times)
            => times.Include(time => time.Job);

        public static IQueryable<Time> WhereId(this IQueryable<Time> times, int timeId)
            => times.Where(time => time.Id == timeId);

    }
}