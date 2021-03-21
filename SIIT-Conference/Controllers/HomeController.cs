using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SIIT_Conference.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SIIT_Conference.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult DummyStuff()
        {
            return new JsonResult("dummy from the server");
        }


        [HttpPost]
        public IActionResult DummyStuff(string name, string location)
        {
            return new JsonResult($"I got name: {name}, location: {location}");
        }

        [HttpDelete]
        public IActionResult DummyStuff(int id)
        {
            return new JsonResult($"I got id to delete: {id}");
        }

    }
}
