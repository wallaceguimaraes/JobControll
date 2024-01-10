using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Extensions.Http;
using api.Filters;
using api.Models.Interfaces;
using api.Models.ResultModel.Errors;
using api.Models.ResultModel.Successes.Jobs;
using api.Models.ViewModel.Jobs;
using api.Results.Errors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/v1/jobs")]
    public class JobController : Controller
    {
        private readonly IJobService _service;

        public JobController(IJobService service)
        {
            _service = service;
        }

        [HttpPost, Auth]
        public async Task<IActionResult> Create([FromBody] JobModel model)
        {
            var whoami = HttpContext.WhoAmI();

            var response = await _service.CreateJob(model.Map(whoami.User.Id));
            if (!string.IsNullOrEmpty(response.error))
            {
                if (response.error.Equals("PROJECT_NOT_FOUND") || response.error.Equals("USER_NOT_FOUND"))
                    return new NotFoundRequestJson(response.error);

                return new UnprocessableEntityJson(response.error);
            }

            return new JobJson(response.job);
        }
    }
}