using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PumpedUpKicks.Controllers
{
    [Authorize(Policy = "EmployeeOnly")]
    public class SecretController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}