using api.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace api.Extensions.Identity
{
    public static class ClaimsExtensions
    {
        public static string Actor(this IEnumerable<Claim> claims)
        {
            var claim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Actor);
            return claim?.Value;
        }

        public static int UserId(this IEnumerable<Claim> claims)
        {
            var claim = claims.FirstOrDefault(c => c.Type == ApiClaimTypes.UserId);
            var userId = 0;

            Int32.TryParse(claim?.Value, out userId);

            return userId;
        }

        public static string Salt(this IEnumerable<Claim> claims)
        {
            var claim = claims.FirstOrDefault(c => c.Type == ApiClaimTypes.Salt);

            return claim?.Value;
        }
    }
}