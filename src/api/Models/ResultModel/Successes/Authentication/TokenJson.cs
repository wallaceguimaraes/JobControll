using api.Models.EntityModel.Users;
using Microsoft.AspNetCore.Mvc;

namespace api.ResultModel.Successes.Authentication
{
    public class TokenJson : IActionResult
    {
        public TokenJson() { }

        public TokenJson(string token)
        {
            Token = token;
        }

        public string Token { get; set; }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}