using BookReadingApp.Application.Interfaces;
using FacadePattern.FacadeInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadingApp.Web.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IEventRepository _eventPageService;
        //public HomeController(IEventRepository eventPageService)
        //{
        //    _eventPageService = eventPageService;
        //}

        private readonly IEventFacade _eventPageService;
        private readonly ILogger _logger;

        public HomeController(IEventFacade eventPageService, ILogger<HomeController> logger)
        {
            _eventPageService = eventPageService;
            _logger = logger;
        }



        public void Logging()
        {
            _logger.LogTrace("This is a trace Log");
            _logger.LogDebug("This is a debug Log");

            _logger.LogInformation("This is a information log");
            _logger.LogWarning("This is a warning log");
            _logger.LogCritical("This is a critical log");
            _logger.LogError("This is the error log");

        }

        [Route("")]
        public async Task<IActionResult> Index()
        {
            var eventList = await _eventPageService.GetEvents();
            return View(eventList);
        }

        [Route("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("customer-support")]

        public IActionResult CustomerSupport()
        {
            return Redirect("https://www.nagarro.com/en/contact-us");
        }
    }
}
