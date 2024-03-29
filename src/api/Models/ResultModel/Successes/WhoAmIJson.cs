using api.Models.EntityModel;
using api.Models.EntityModel.Users;
using api.Models.ResultModel.Successes.Employees;
using Microsoft.AspNetCore.Mvc;

namespace api.Models.ResultModel.Successes
{
    public class WhoAmIJson : IActionResult
    {
        public WhoAmIJson(User user)
        {
            User = new UserJson(user);
        }

        public UserJson User { get; set; }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}