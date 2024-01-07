using api.Models.EntityModel.Users;
using api.Models.ResultModel.Successes.Employees;
using api.Models.ServiceModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api.Results.v2.Authentication
{
    public class WhoAmIJson : IActionResult
    {
        public WhoAmIJson() { }

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