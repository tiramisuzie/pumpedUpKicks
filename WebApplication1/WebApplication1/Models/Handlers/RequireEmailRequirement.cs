using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace PumpedUpKicks.Models.Handlers
{
    public class RequireEmailRequirement : IAuthorizationRequirement
    {
        public RequireEmailRequirement()
        {

        }
    }
}
