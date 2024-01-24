using api.Extensions.Http;
using api.Filters;
using api.Models.Interfaces;
using api.Models.ResultModel.Errors;
using api.Models.ResultModel.Successes.Times;
using api.Models.ViewModel.Times;
using api.Results.Errors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/v1/times")]
    public class TimeController : Controller
    {
        private readonly ITimeService _service;

        public TimeController(ITimeService timeService)
        {
            _service = timeService;
        }

        [HttpPost, Auth]
        public async Task<IActionResult> Create([FromBody] TimeModel model)
        {
            var whoami = HttpContext.WhoAmI();
            var response = await _service.CreateTime(model.Map(), whoami.User.Id);
            if (!string.IsNullOrEmpty(response.error))
            {
                if (response.error.Equals("JOB_NOT_FOUND"))
                    return new NotFoundRequestJson(response.error);

                return new UnprocessableEntityJson(response.error);
            }

            return new TimeJson(response.time);
        }

        [HttpGet, Route("{job_id}"), Auth]
        public async Task<IActionResult> GetTimesByJob([FromRoute] string job_id)
        {
            if (String.IsNullOrEmpty(job_id))
                return new BadRequestJson("Job_id: Required.");

            int id;

            if (!int.TryParse(job_id, out id))
                return new BadRequestJson("Id: Invalid.");

            var whoami = HttpContext.WhoAmI();

            var response = await _service.GetTimesByJob(id, whoami.User.Id);

            if (!String.IsNullOrEmpty(response.error))
                return new NotFoundRequestJson(response.error);

            return new TimeListJson(response.times);
        }

        // Finalize Time
        [HttpPut, Route("{time_id}"), Auth]
        public async Task<IActionResult> UpdateTime([FromBody] TimeModel model, [FromRoute] string time_id)
        {
            if (String.IsNullOrEmpty(time_id))
                return new BadRequestJson("Time_id: Required.");

            int id;

            if (!int.TryParse(time_id, out id))
                return new BadRequestJson("Id: Invalid.");

            var whoami = HttpContext.WhoAmI();

            var response = await _service.UpdateTime(model, id, model.JobId, whoami.User.Id);

            if (!String.IsNullOrEmpty(response.error))
            {
                if (response.error.Equals("JOB_NOT_FOUND") || response.error.Equals("TIME_NOT_FOUND"))
                    return new NotFoundRequestJson(response.error);

                return new UnprocessableEntityJson(response.error);
            }

            return new TimeJson(response.time);
        }

    }
}