using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace PumpedUpKicks.Controllers
{
    public class VipController : Controller
    {
        [Authorize(Policy = "EmailPolicy")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
