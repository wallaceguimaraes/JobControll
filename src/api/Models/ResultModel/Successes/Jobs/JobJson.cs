using api.Models.EntityModel.Jobs;
using Microsoft.AspNetCore.Mvc;

namespace api.Models.ResultModel.Successes.Jobs
{
    public class JobJson : IActionResult
    {
        public JobJson() { }

        public JobJson(Job job)
        {
            Job = job;
        }

        public Job Job { get; set; }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}