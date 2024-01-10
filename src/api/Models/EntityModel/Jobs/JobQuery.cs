using api.Models.EntityModel.Jobs;
using Microsoft.EntityFrameworkCore;

namespace api.Models.EntityModel.Projects
{
  public static class JobQuery
  {
    public static IQueryable<Job> WhereId(this IQueryable<Job> jobs, int jobId)
       => jobs.Where(job => job.Id == jobId);


  }
}