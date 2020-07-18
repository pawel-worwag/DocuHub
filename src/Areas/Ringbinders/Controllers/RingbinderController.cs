using System;
using System.Collections.Generic;
using System.Linq;
using DocuHub.DAL;
using Microsoft.AspNetCore.Mvc;

namespace DocuHub.Areas.RingBinders.Controllers
{
    [Area("Ringbinders")]
    public class RingbinderController:Controller
    {
        private readonly IRingBindersRepository _ringbinders;
        public RingbinderController(IRingBindersRepository ringbinders)
        {
            _ringbinders = ringbinders;
        }

        [HttpGet("/ringbinders")]
        public IActionResult Index()
        {
            return View(_ringbinders.GetAllRingBinders());
        }
    }
}