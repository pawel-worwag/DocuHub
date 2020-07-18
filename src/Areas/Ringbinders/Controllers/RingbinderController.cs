using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace DocuHub.Areas.RingBinders.Controllers
{
    [Area("Ringbinders")]
    public class RingbinderController:Controller
    {
        public RingbinderController()
        {
            
        }

        [HttpGet("/ringbinders")]
        public IActionResult Index()
        {
            return View();
        }
    }
}