using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.EntityModel.Jobs;
using Microsoft.AspNetCore.Mvc;

namespace api.Models.ResultModel.Successes.Jobs
{
    public class JobListJson : IActionResult
    {
        public JobListJson() { }

        public JobListJson(ICollection<Job> jobs)
        {
            Jobs = jobs.Select(j => new JobJson(j)).ToList();
        }

        public ICollection<JobJson> Jobs { get; set; }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}