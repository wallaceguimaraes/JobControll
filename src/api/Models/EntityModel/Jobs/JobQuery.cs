using api.Models.EntityModel.Jobs;
using Microsoft.EntityFrameworkCore;

namespace api.Models.EntityModel.Projects
{
  public static class JobQuery
  {
    public static IQueryable<Job> WhereId(this IQueryable<Job> jobs, int jobId)
       => jobs.Where(job => job.Id == jobId);
    public static IQueryable<Job> WhereProjectId(this IQueryable<Job> jobs, int projectId)
       => jobs.Where(job => job.ProjectId == projectId);
    public static IQueryable<Job> WhereUserId(this IQueryable<Job> jobs, int userId)
           => jobs.Where(job => job.UserId == userId);

    public static IQueryable<Job> IncludeTimes(this IQueryable<Job> jobs)
       => jobs.Include(job => job.Times);
    public static IQueryable<Job> IncludeWorkedTime(this IQueryable<Job> jobs)
  => jobs.Include(job => job.WorkedTime);

  }
}