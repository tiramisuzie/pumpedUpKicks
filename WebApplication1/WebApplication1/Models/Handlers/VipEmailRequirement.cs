using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace PumpedUpKicks.Models.Handlers
{
    public class VipEmailRequirement : AuthorizationHandler<RequireEmailRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RequireEmailRequirement requirement)
        {
            if (!context.User.HasClaim(x => x.Type == ClaimTypes.Email))
            {
                return Task.CompletedTask;
            }
            var userEmail = context.User.FindFirst(email => email.Type == ClaimTypes.Email).Value;

            if (userEmail.Contains(".vip"))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }

    }
}
